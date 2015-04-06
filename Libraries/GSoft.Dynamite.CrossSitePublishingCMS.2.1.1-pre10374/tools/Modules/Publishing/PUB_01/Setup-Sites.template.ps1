# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Sites.ps1.template
# Description	: Create a SharePoint SPSites structure
# -----------------------------------------------------------------------

# You can send in a -Force parameter to delete all existing sites.
# Otherwise, if any of the sites already exists, the configuration
# setup will abort.
param([switch] $Force=$false)

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$DefaultConfigurationFile = "[[DSP_DEFAULT_PortalSitesConfigurationFile]]"
$CustomConfigurationFile = "[[DSP_CUSTOM_PortalSitesConfigurationFile]]"
$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

# If custom configuration file is defined, use it instead of the default
if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
}

# If force parameter is true, remove the previous SharePoint structure
if ($Force) {
	Remove-DSPStructure $ConfigurationFilePath
}

# Create the new SharePoint site structure
New-DSPStructure $ConfigurationFilePath

# If multilingual is configured, activate the variation hierarchie features on authoring and publishing sites
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
if($IsMultilingual)
{
	$values = @{"Step: " = "#1.1 Setup Sites Variations"}
	New-HeaderDrawing -Values $Values

	Write-Warning "Applying Site Variations configuration..."

	# Activate feature on the root web on the authoring site collection
	Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CommonCMS_LANG_CreateVariationsHierarchies]]

	# Activate feature on the root web on the publishing site collection
	Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_LANG_CreateVariationsHierarchies]]
}



