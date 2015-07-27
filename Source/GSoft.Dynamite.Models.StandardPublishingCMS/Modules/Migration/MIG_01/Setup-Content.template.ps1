# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Standard Publishing CMS
# File          : Setup-Content.ps1.template
# Description	: Import Content into SharePoint (from Excel or from an existing site)
# -----------------------------------------------------------------------


[CmdletBinding(DefaultParameterSetName="ExcelRepository")]

Param
(
    [Parameter(Mandatory=$false)]
    [string]$LogFolderPath,

    [Parameter(Mandatory=$false)]
    [Parameter(ParameterSetName = "ExcelRepository")]
    [switch]$FromExcel=$true,

    [Parameter(Mandatory=$false)]
    [Parameter(ParameterSetName = "SiteRepository")]
    [switch]$FromSite,

    [Parameter(Mandatory=$false)]
    [switch]$ImportSource,

    [Parameter(Mandatory=$false)]
    [switch]$ImportTargets  
)

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

if ([string]::IsNullOrEmpty($LogFolderPath))
{
	$LogFolderPath = $CommandDirectory
}

# ******************************************
# Local utility methods
# ******************************************
function Get-FullPath {
    param(
		[Parameter(Mandatory=$true)]
        [string]$Path)

    if ([System.IO.Path]::IsPathRooted($Path) -ne $true) {
        if ($Path.StartsWith(".\")) {
            $Path = $path.Replace(".\", ($CommandDirectory + "\"))
        } else {
            $Path = Join-Path -Path $CommandDirectory -ChildPath $Path
        }
    }

    return $Path;
}

function Get-CustomPropertyMappings {
    param(
		[Parameter(Mandatory=$true)]
        [string]$PropertyDisplayName,

        [Parameter(Mandatory=$true)]
        $MappingSettings       
    )

	# Remove default keys
	Remove-PropertyMapping -MappingSettings $MappingSettings -Destination Title | Out-Null
	Remove-PropertyMapping -MappingSettings $MappingSettings -Destination Created | Out-Null

	# Add custom keys
	Set-PropertyMapping -MappingSettings $MappingSettings -Source $PropertyDisplayName -Destination $PropertyDisplayName -Key | Out-Null

    return $MappingSettings
}

function Get-CustomContentTypeMappings {
    param(
		[Parameter(Mandatory=$true)]
        [hashtable]$ContentTypesMappings,

        [Parameter(Mandatory=$true)]
        $MappingSettings       
    )

    # Build content types mappings
    $ContentTypesMappings.Keys | ForEach-Object {
    
        $MappingSettings = Set-ContentTypeMapping -MappingSettings $MappingSettings -Source $_ -Destination $ContentTypesMappings.Get_Item($_)
    }

    return $MappingSettings
}

function Wait-VariationSyncTimerJob {

	# We don't need to sync manually items because we force the "Approved" status which automatically fires variations event receiver 
	# Sync item with timer job
	$Site = Get-SPSite "[[DSP_PortalPublishingHostNamePath]]"
	Write-Warning "Waiting for 'VariationsPropagateListItem' timer job to finish..."
	Wait-SPTimerJob -Name "VariationsPropagateListItem" -Site $Site

	# Sync pages with timer job
	Write-Warning "Waiting for 'VariationsPropagatePage' timer job to finish..."
	Wait-SPTimerJob -Name "VariationsPropagatePage" -Site $Site
	Start-Sleep -Seconds 15
}

# ******************************************
# Configure common parameters
# ******************************************
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
$SourceLabel ="[[DSP_SourceLabel]]"
$DSP_MigrationAssociationKeys = [[DSP_MigrationAssociationKeys]]

# Content Types
$DSP_MigrationSourceContentTypeMappings = [[DSP_MigrationSourceContentTypeMappings]]
$DSP_MigrationTargetContentTypeMappings = [[DSP_MigrationTargetContentTypeMappings]]

# Multithreading configuration
$DSP_MigrationThreadNumber = [[DSP_MigrationThreadNumber]]

# Do some logic to determine which labels to process
$ProcessSourceContent = $false
$ProcessTargetContent = $false
$ExecuteIntermediateScript = $false

if (($ImportSource.IsPresent -and $ImportTargets.IsPresent) -or ((-not $ImportSource.IsPresent) -and (-not $ImportTargets.IsPresent)))
{
    $ProcessSourceContent = $true
    $ProcessTargetContent = $true
    $ExecuteIntermediateScript = $true
}
else
{
    if ($ImportSource.IsPresent -and (-not $ImportTargets.IsPresent))
    {
        $ProcessSourceContent = $true
    }
    else
    {
        if ((-not $ImportSource.IsPresent) -and $ImportTargets.IsPresent)
        {
            $ProcessTargetContent = $true
        }
    }
}

# --------------------------------- SOURCE LABEL ------------------------------- #
if ($ProcessSourceContent)
{
    # ******************************************
    # Import from Excel
    # ******************************************
    if ($FromExcel.IsPresent)
    {
        # Chech Restore ACL inheritance token
        $RestoreAclInheritance = [System.Convert]::ToBoolean("[[DSP_RestoreAclInheritance]]")
    
        $DSP_MigrationFolderMappings = [[DSP_MigrationFolderMappings]]

        # If not already defined, create default folder to URL mappings
        if($DSP_MigrationFolderMappings -eq $null) {
            $DSP_MigrationFolderMappings = [Ordered]@{ ".\Default\Default (english only)" = "[[DSP_PortalAuthoringSiteUrl]]" }

            # If the solution is multilingual then the source folder corresponds to the default variation label folder
            if ($IsMultilingual) {
	            $DSP_MigrationFolderMappings = [Ordered]@{ 
                ".\Default\Multilingual\Root" = "[[DSP_PortalAuthoringSiteUrl]]";
                ".\Default\Multilingual\Source" = "[[DSP_PortalAuthoringSiteUrl]]/[[DSP_SourceLabel]]" }

                [[DSP_VariationsTargetLabels]] |  Foreach-Object {
                    if ($_ -ne "[[DSP_SourceLabel]]") {
                        $FromFolder = (".\Default\Multilingual\Targets\" + $_)
                        $ToUrl = ("[[DSP_PortalAuthoringSiteUrl]]/" + $_)
                
                        $DSP_MigrationFolderMappings.Add($FromFolder, $ToUrl)
                    }
                }
            }
        }

        # ******************************************
        # Configure migration data before import
        # ******************************************
        $DSP_MigrationDataConfigurationScript = "[[DSP_MigrationDataConfigurationScript]]"
        $DSP_MigrationFolderMappings.Keys | ForEach-Object {
            $Folder = Get-FullPath -Path $_
            $ConfigurationScript = Get-FullPath -Path $DSP_MigrationDataConfigurationScript
            & $ConfigurationScript -FolderPath $Folder
        }

        # ******************************************
        # Import "non-variation" data
        # ******************************************
        # Defines mappings keys for "non-variation" content and variation targets
        $mappingKeys = $DSP_MigrationFolderMappings.Keys | where { -not $_.ToUpperInvariant().Contains("TARGETS") }
        $mappingKeys | ForEach-Object {
            $fromFolder = Get-FullPath -Path $_
            $toUrl = $DSP_MigrationFolderMappings[$_]

            if ($RestoreAclInheritance)
            {
                # Script to fix file ACLs for bug fix with Sharegate import
                $AclScript = $CommandDirectory + "\Restore-AclInheritance.ps1" 

                Write-Warning "Restore ACL inheritance on folder '$fromFolder'..."
                # Fix ACLs before importing data
                & $AclScript -folderPath $fromFolder
            }

            if ($_.ToUpperInvariant().Contains("SOURCE")) {

                # Custom property mapping settings
	            $MappingSettings = New-MappingSettings 

		        # Configure mapping settings for keys
	            $MappingSettings = Get-CustomPropertyMappings -MappingSetting $MappingSettings -PropertyDisplayName $DSP_MigrationAssociationKeys[$SourceLabel]

                # Configure mappings settings for content types
                if ($DSP_MigrationSourceContentTypeMappings.Count -gt 0)
                {
                    $MappingSettings = Get-CustomContentTypeMappings -MappingSetting $MappingSettings -ContentTypesMappings $DSP_MigrationSourceContentTypeMappings
                }

		        # Configure property settings
		        $DSP_MigrationDataMappingsFile = Get-FullPath -Path "[[DSP_MigrationDataSourceMappings]]"
		        $DSP_MigrationDataMappingsName = "[[DSP_MigrationDataSourceMappingsName]]"

                Import-DSPData -FromFolder $fromFolder -ToUrl $toUrl -LogFolder $LogFolderPath -MappingSettings $MappingSettings -PropertyTemplateFile $DSP_MigrationDataMappingsFile -TemplateName $DSP_MigrationDataMappingsName -ThreadNumberPerWeb $DSP_MigrationThreadNumber -ThreadNumberPerList $DSP_MigrationThreadNumber
            } else {
                Import-DSPData -FromFolder $fromFolder -ToUrl $toUrl -LogFolder $LogFolderPath -ThreadNumberPerWeb $DSP_MigrationThreadNumber -ThreadNumberPerList $DSP_MigrationThreadNumber
            }
        }
    }

    # ******************************************
    # Import from existing site
    # ******************************************
    if ($FromSite.IsPresent)
    {
        $DSP_MigrationSourceSiteMappings = [[DSP_MigrationSourceSiteMapping]]

        if ($DSP_MigrationSourceSiteMappings.Count -gt 0)
        {
            # Get List Names 
            $ListNames = [[DSP_MigrationListNames]]

            # Custom property mapping settings
	        $MappingSettings = New-MappingSettings 

		    # Configure mapping settings for keys
	        $MappingSettings = Get-CustomPropertyMappings -MappingSetting $MappingSettings -PropertyDisplayName $DSP_MigrationAssociationKeys[$SourceLabel]

            # Configure mappings settings for content types
            if ($DSP_MigrationSourceContentTypeMappings.Count -gt 0)
            {
                $MappingSettings = Get-CustomContentTypeMappings -MappingSetting $MappingSettings -ContentTypesMappings $DSP_MigrationSourceContentTypeMappings
            }

		    # Configure property settings
		    $DSP_MigrationDataMappingsFile = Get-FullPath -Path "[[DSP_MigrationDataSourceMappings]]"
		    $DSP_MigrationDataMappingsName = "[[DSP_MigrationDataSourceMappingsName]]"

            $DSP_MigrationSourceSiteMappings.Keys | ForEach-Object {

                Copy-DSPData -FromUrl $_ -ToUrl $DSP_MigrationSourceSiteMappings.Get_Item($_) -ListNames $ListNames -IncludeChildren -LogFolder $LogFolderPath -MappingSettings $MappingSettings -PropertyTemplateFile $DSP_MigrationDataMappingsFile -TemplateName $DSP_MigrationDataMappingsName -ThreadNumberPerWeb $DSP_MigrationThreadNumber -ThreadNumberPerList $DSP_MigrationThreadNumber
            }
        }
        else
        {
            Write-Warning "No source site mapping found. Check your token file and set the 'DSP_MigrationSourceSiteMapping' variable"
        }
    }
}

# --------------------------------- TARGET LABELS ------------------------------- #
if ($ProcessTargetContent)
{
    # ******************************************
    # If multilingual, sync and the process target label data
    # ******************************************
    if($IsMultilingual) {


        if ($ExecuteIntermediateScript)
        {
            # Wait for variations to sync data to target label(s)
            Wait-VariationSyncTimerJob

            # Execute intermediate steps if specified
            $DSP_MigrationDataIntermediateScript = "[[DSP_MigrationDataIntermediateScript]]"
            $IntermediateScript = Get-FullPath -Path $DSP_MigrationDataIntermediateScript
            if (Test-Path $IntermediateScript)
            {
                Write-Warning "Executing intermediate script '$IntermediateScript'..."
                & $IntermediateScript
            }
        }

        if ($FromExcel.IsPresent)
        {
            $DSP_MigrationFolderMappings = [[DSP_MigrationFolderMappings]]

            # Defines mappings keys for variation targets
            $TargetMappingKeys = $DSP_MigrationFolderMappings.Keys | where { $_.ToUpperInvariant().Contains("TARGETS") }
            $TargetMappingKeys | ForEach-Object {
                $FromFolder = Get-FullPath -Path $_
                $ToUrl = $DSP_MigrationFolderMappings[$_]

                if ($RestoreAclInheritance)
                {
                    Write-Warning "Restore ACL inheritance on folder '$fromFolder'..."
                    # Fix ACLs before importing data
                    & $AclScript -folderPath $fromFolder
                }

                # Get target label language to determine what association key display name to use
                $IndexOfTargetLanguage = $FromFolder.LastIndexOf("\") + 1
                $TargetLabelLanguage = $FromFolder.Substring($IndexOfTargetLanguage)

                # Custom property mapping settings
	            $MappingSettings = New-MappingSettings

		        # Configure mapping settings
	            $MappingSettings = Get-CustomPropertyMappings -MappingSetting $MappingSettings -PropertyDisplayName $DSP_MigrationAssociationKeys[$TargetLabelLanguage]

                # Configure mappings settings for content types
                if ($DSP_MigrationTargetContentTypeMappings.Count -gt 0)
                {
                    $MappingSettings = Get-CustomContentTypeMappings -MappingSetting $MappingSettings -ContentTypesMappings $DSP_MigrationTargetContentTypeMappings
                }

		        # Configure property settings
		        $DSP_MigrationDataMappingsFile = Get-FullPath -Path "[[DSP_MigrationDataTargetMappings]]"
		        $DSP_MigrationDataMappingsName = "[[DSP_MigrationDataTargetMappingsName]]"

		        # Import data
                Import-DSPData -FromFolder $FromFolder -ToUrl $ToUrl -LogFolder $LogFolderPath -MappingSettings $MappingSettings -PropertyTemplateFile $DSP_MigrationDataMappingsFile -TemplateName $DSP_MigrationDataMappingsName -ThreadNumberPerWeb $DSP_MigrationThreadNumber -ThreadNumberPerList $DSP_MigrationThreadNumber
            }
        }

        if ($FromSite.IsPresent)
        {
            $DSP_MigrationTargetSiteMappings = [[DSP_MigrationTargetSiteMappings]]

            if ($DSP_MigrationTargetSiteMappings.Count -gt 0)
            {
                # Get List Names 
                $ListNames = [[DSP_MigrationListNames]]

                # Custom property mapping settings
	            $MappingSettings = New-MappingSettings 

		        # Configure mapping settings for keys
	            $MappingSettings = Get-CustomPropertyMappings -MappingSetting $MappingSettings -PropertyDisplayName $DSP_MigrationAssociationKeys[$SourceLabel]

                # Configure mappings settings for content types
                if ($DSP_MigrationTargetContentTypeMappings.Count -gt 0)
                {
                    $MappingSettings = Get-CustomContentTypeMappings -MappingSetting $MappingSettings -ContentTypesMappings $DSP_MigrationTargetContentTypeMappings
                }

		        # Configure property settings
		        $DSP_MigrationDataMappingsFile = Get-FullPath -Path "[[DSP_MigrationDataTargetMappings]]"
		        $DSP_MigrationDataMappingsName = "[[DSP_MigrationDataTargetMappingsName]]"

                $DSP_MigrationTargetSiteMappings.Keys | ForEach-Object {

                    Copy-DSPData -FromUrl $_ -ToUrl $DSP_MigrationTargetSiteMappings.Get_Item($_) -ListNames  $ListNames -IncludeChildren -LogFolder $LogFolderPath -MappingSettings $MappingSettings -PropertyTemplateFile $DSP_MigrationDataMappingsFile -TemplateName $DSP_MigrationDataMappingsName -ThreadNumberPerWeb $DSP_MigrationThreadNumber -ThreadNumberPerList $DSP_MigrationThreadNumber
                }
            }
            else
            {
                Write-Warning "No targets site mappings found. Check your token file and set the 'DSP_MigrationTargetSiteMappings' variable"
            }
        }
    }
}

$values = @{"Migration" = "Summary"}
New-HeaderDrawing -Values $Values

# Migration summary
Write-Host -ForegroundColor Green "-----------------------------------------------------------------------------------"
Write-Host -ForegroundColor Green "Successes" 
Write-Host -ForegroundColor Green "-----------------------------------------------------------------------------------"
Find-DSPExcelFiles -Folder $LogFolderPath -Columns "Status" -Patterns "Success" -WorksheetName Data

Write-Host -ForegroundColor Yellow "-----------------------------------------------------------------------------------"
Write-Host -ForegroundColor Yellow "Warnings" 
Write-Host -ForegroundColor Yellow "-----------------------------------------------------------------------------------"
Find-DSPExcelFiles -Folder $LogFolderPath -Columns "Status" -Patterns "Warning" -WorksheetName Data

Write-Host -ForegroundColor Red "-----------------------------------------------------------------------------------"
Write-Host -ForegroundColor Red "Errors" 
Write-Host -ForegroundColor Red "-----------------------------------------------------------------------------------"
Find-DSPExcelFiles -Folder $LogFolderPath -Columns "Status" -Patterns "Error" -WorksheetName Data