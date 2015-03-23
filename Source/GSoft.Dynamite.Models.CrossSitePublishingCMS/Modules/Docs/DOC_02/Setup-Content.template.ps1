# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Content.ps1.template
# Description	: Import Content into catalogs
# -----------------------------------------------------------------------

param([string]$LogFolderPath)

# Configure Reports files

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

if ([string]::IsNullOrEmpty($LogFolderPath))
{
	$LogFolderPath = $CommandDirectory
}

# -----------------------------------------------------------------------
# TOKENS SETTINGS
# -----------------------------------------------------------------------

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
$SourceLabel ="[[DSP_SourceLabel]]"

### IMAGES CONFIGURATION

$DefaultImagesFolder = "[[DSP_DEFAULT_ImagesSourceFolder]]"
$CustomImagesFolder = "[[DSP_CUSTOM_ImagesSourceFolder]]"

### EXCEL IMPORT FILES CONFIGURATION

$DefaultExcelFilesFolder = "[[DSP_DEFAULT_ExcelFilesSourceFolder]]"
$CustomExcelFilesFolder = "[[DSP_CUSTOM_ExcelFilesSourceFolder]]"

### SHAREGATE TEMPLATE CONFIGURATION

$DefaultPropertyTemplateFile = "[[DSP_DEFAULT_PropertyTemplateFile]]"
$CustomPropertyTemplateFile = "[[DSP_CUSTOM_PropertyTemplateFile]]"

$DefaultPropertyTemplateName = "[[DSP_DEFAULT_PropertyTemplateName]]"
$CustomPropertyTemplateName = "[[DSP_CUSTOM_PropertyTemplateName]]"

### CATALOGS MAPPINGS

$CustomCatalogsTitles = "[[DSP_CUSTOM_CatalogTitles]]"

$ImagesConfigurationFolder = $CommandDirectory  + $DefaultImagesFolder
$DefaultExcelConfigurationFolder = $CommandDirectory + $DefaultExcelFilesFolder
$DefaultPropertyTemplateFile = $CommandDirectory + $DefaultPropertyTemplateFile

if(![string]::IsNullOrEmpty($CustomImagesFolder))
{
	$ImagesConfigurationFolder = $CommandDirectory + $CustomImagesFolder
}

if(![string]::IsNullOrEmpty($CustomExcelFilesFolder))
{
	$DefaultExcelConfigurationFolder = $CommandDirectory + $CustomExcelFilesFolder
}

if(![string]::IsNullOrEmpty($CustomPropertyTemplateFile))
{
	$DefaultPropertyTemplateFile = $CommandDirectory + $CustomPropertyTemplateFile
	$DefaultPropertyTemplateName = $CustomPropertyTemplateName
}

$CurrentExcelConfigurationFolder = $DefaultExcelConfigurationFolder

# If the solution is multilingual then the source folder corresponds to the default variation label folder
if ($IsMultilingual)
{
	$CurrentExcelConfigurationFolder = $DefaultExcelConfigurationFolder + "/" + $SourceLabel
}

# -----------------------------------------------------------------------
# SHAREGATE SETTINGS
# -----------------------------------------------------------------------

# Create Copy Settings
$copySettings = New-CopySettings -OnContentItemExists Overwrite

# -----------------------------------------------------------------------
# PROCESS IMAGES
# -----------------------------------------------------------------------

Write-Warning "Importing images..."

$CustomDestinationSite = "[[DSP_PortalAuthoringSiteUrl]]"
$UploadPicturesInDocCenter = [System.Convert]::ToBoolean("[[DSP_UploadPicturesInDocCenter]]")

if(![string]::IsNullOrEmpty("[[DSP_PortalDocCenterHostNamePath]]") -and $UploadPicturesInDocCenter)
{
	$CustomDestinationSite = "[[DSP_PortalDocCenterHostNamePath]]"
}

# Add Images to site collection images
$imagelist = Connect-Site -Url $CustomDestinationSite| Get-List -Name "[[DSP_PictureLibraryName]]"
Import-Document -DestinationList $imagelist -SourceFolder $ImagesConfigurationFolder | Export-Report -Path ($LogFolderPath + "\Images_ImportReport") -Overwrite

# -----------------------------------------------------------------------
# PROCESS EXCEL FILES
# -----------------------------------------------------------------------

# Only import data in root authoring webs because of variations syncing
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object { 

	$CurrentAuthoringWeb = $_

	$Catalogs = [[DSP_CUSTOM_CatalogTitles]]
	
	if($Catalogs.Count -eq 0)
	{
		$Catalogs = [[DSP_DEFAULT_CatalogTitles]]
	}

	# Excel Files
	$Catalogs.Keys | Foreach-Object {
	
		$CurrentFileName = $_
		$CatalogDisplayNames = $Catalogs.Item($_)
	
		$CatalogDisplayNames | Foreach-Object {

			$CurrentCatalogName = $_

			# Get a fake random list (not needed in the procedure because we use an Excel file but needed for the cmdlet)
			$srcList = Connect-Site -Url [[DSP_PortalAuthoringSiteUrl]] | Get-List | Where-Object {$_.BaseType -eq "List"} | Select -First 1

			$dstList = Connect-Site -Url $CurrentAuthoringWeb | Get-List -Name $CurrentCatalogName

			if($dstList -ne $null)
			{
				# Trick to get the exact mappings settings for the list
				$mappingSettings = Get-PropertyMapping -SourceList $dstList -DestinationList $dstList 
				# Add custom key (internal unique ID)
				$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source DynamiteInternalId -Destination DynamiteInternalId -Key
				# Remove previous key
				$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Created -Destination Created
				$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Title -Destination Title

				# Get the specified file according to the default folder
				$file = Get-ChildItem -Path $CurrentExcelConfigurationFolder | Where-Object {$_.Name -eq $CurrentFileName}
				if ($file -ne $null)
				{		
					Write-Warning "Importing data into catalog $CurrentCatalogName in web $CurrentAuthoringWeb..."
					Copy-Content -SourceList $srcList -DestinationList $dstList -ExcelFilePath $file.FullName -MappingSettings $mappingSettings -CopySettings $copySettings | Export-Report -Path ($LogFolderPath + "\" + $CurrentCatalogName + "_ImportReport") -Overwrite
				}
			}
			else
			{
				Write-Warning "Unable to find the catalog with name $CurrentCatalogName in web $CurrentAuthoringWeb...Skipping..."
			}
		}
	}
}

if($IsMultilingual)
{
	# We don't need to sync manually items because we force the "Approved" status which automatically fires variations event receiver 
	# Sync item with timer job
	$WebApplication = Get-SPWebApplication "[[DSP_PortalWebAppUrl]]"
	Wait-SPTimerJob -Name "VariationsPropagateListItem" -WebApplication $WebApplication
	Write-Warning "Waiting for 'VariationsPropagateListItem' timer job to finish..."
	Start-Sleep -Seconds 15

	# Excel Files
	$Catalogs.Keys | Foreach-Object {
	
		$CurrentFileName = $_
		$CatalogDisplayNames = $Catalogs.Item($_)

		# Update items on target webs
		$TargetUrls = [[DSP_AuthoringUrlsByLabels]]

		$TargetUrls.Keys | Foreach-Object { 
	
			$CurrentAuthoringWeb = $_
			$Currentlabel =$TargetUrls.Item($_)

			if ($Currentlabel -ne $SourceLabel)
			{
				# Get the configuration folder according to the label of the current site
				$CurrentExcelConfigurationFolder = $DefaultExcelConfigurationFolder + "/" + $Currentlabel

				$CatalogDisplayNames | Foreach-Object {

					$CurrentCatalogName = $_

					$dstList = Connect-Site -Url $CurrentAuthoringWeb | Get-List -Name $CurrentCatalogName

					if($dstList -ne $null)
					{
						# Trick to get the exact mappings settings for the list
						$mappingSettings = Get-PropertyMapping -SourceList $dstList -DestinationList $dstList 
						# Add custom key (internal unique ID)
						$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source DynamiteInternalId -Destination DynamiteInternalId -Key
						# Remove previous key (add the title)
						$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Created -Destination Created
						$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Title -Destination Title

						# Import Custom Template for the "Content Association Key" 
						Import-PropertyTemplate -Path $DefaultPropertyTemplateFile -List $dstList

						# Get the specified file according to the default folder
						$file = Get-ChildItem -Path $CurrentExcelConfigurationFolder | Where-Object {$_.Name -eq $CurrentFileName}
						if ($file -ne $null)
						{		
							Write-Warning "Importing data into catalog $CurrentCatalogName in web $CurrentAuthoringWeb..."
							Copy-Content -SourceList $srcList -DestinationList $dstList -TemplateName $DefaultPropertyTemplateName -ExcelFilePath $file.FullName -MappingSettings $mappingSettings -CopySettings $copySettings | Export-Report -Path ($LogFolderPath + "\" + $CurrentCatalogName + "_" +  $Currentlabel + "_ImportReport") -Overwrite
						}
					}
					else
					{
						Write-Warning "Unable to find the catalog with name $CurrentCatalogName in web $CurrentAuthoringWeb...Skipping..."
					}
				}
			}
		}
	}
}


