# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-Content.ps1.template
# Description	: Import Content into SharePoint
# -----------------------------------------------------------------------

param([string]$LogFolderPath)

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

if ([string]::IsNullOrEmpty($LogFolderPath))
{
	$LogFolderPath = $CommandDirectory
}

# Script to fix file ACLs for bug fix with Sharegate import
$AclScript = $CommandDirectory + "\Restore-AclInheritance.ps1" 


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

    # Custom property mapping settings
	$MappingSettings = New-MappingSettings 

	# Remove default keys
	Remove-PropertyMapping -MappingSettings $MappingSettings -Destination Title
	Remove-PropertyMapping -MappingSettings $MappingSettings -Destination Created

	# Add custom keys
	Set-PropertyMapping -MappingSettings $MappingSettings -Source DynamiteContentAssociationKey -Destination DynamiteContentAssociationKey -Key

    return $MappingSettings
}

function Wait-VariationSyncTimerJob {

	# We don't need to sync manually items because we force the "Approved" status which automatically fires variations event receiver 
	# Sync item with timer job
	$WebApplication = Get-SPWebApplication "[[DSP_PortalWebAppUrl]]"
	Wait-SPTimerJob -Name "VariationsPropagateListItem" -WebApplication $WebApplication
	Write-Warning "Waiting for 'VariationsPropagateListItem' timer job to finish..."
	Start-Sleep -Seconds 15
}


# ******************************************
# Configure folder to URL mappings
# ******************************************
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
$SourceLabel ="[[DSP_SourceLabel]]"

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
if ($DSP_MigrationDataConfigurationScript -eq $null) {
    $DSP_MigrationDataConfigurationScript = ".\Default\Configure-MigrationData.ps1"
}
    
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

    # Fix ACLs before importing data
    & $AclScript -folderPath $fromFolder

    Import-DSPData -FromFolder $fromFolder -ToUrl $toUrl -LogFolder $LogFolderPath
}

# ******************************************
# If multilingual, sync and the process target label data
# ******************************************
if($IsMultilingual) {

    # Wait for variations to sync data to target label(s)
    Wait-VariationSyncTimerJob

    # Get Sharegate custom property mappings
    $MappingSettings = Get-CustomPropertyMappings

    # Defines mappings keys for variation targets
    $TargetMappingKeys = $DSP_MigrationFolderMappings.Keys | where { $_.ToUpperInvariant().Contains("TARGETS") }
    $TargetMappingKeys | ForEach-Object {
        $FromFolder = Get-FullPath -Path $_
        $ToUrl = $DSP_MigrationFolderMappings[$_]

        # Fix ACLs before importing data
        & $AclScript -folderPath $FromFolder

        Import-DSPData -FromFolder $FromFolder -ToUrl $ToUrl -LogFolder $LogFolderPath -MappingSettings $MappingSettings
    }
}