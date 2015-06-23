# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Sites.template.ps1
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

if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
}

if ($Force) {

	# Remove the previous SharePoint structure
	Remove-DSPStructure $ConfigurationFilePath

	# Create the new SharePoint structure
	New-DSPStructure $ConfigurationFilePath
	
	# FIRST THING TO DO ONCE SITE COLLECTIONS ARE CREATED:
	# Configure Service Locator assembly name preference (if left un-initialized, the default FallbackServiceLocator will be used - 
	# or, if found, the first DLL matching *ServiceLocator.DLL in the GAC will be used)
	$assemblyName = "[[DSP_ServiceLocatorAssemblyName]]"
	if ([string]::IsNullOrEmpty($assemblyName) -eq $false)
	{
		# assume that the same service locator should be used on authoring and publishing site collections
		Set-DSPWebProperty -Url "[[DSP_PortalPublishingSiteUrl]]" -Key "ServiceLocatorAssemblyName" -Value $assemblyName
		Set-DSPWebProperty -Url "[[DSP_PortalAuthoringSiteUrl]]" -Key "ServiceLocatorAssemblyName" -Value $assemblyName
		Set-DSPWebProperty -Url "[[DSP_PortalDocsSiteUrl]]" -Key "ServiceLocatorAssemblyName" -Value $assemblyName
	}

	# Check Multilingual settings
	$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

	if($IsMultilingual)
	{
		$values = @{"Step: " = "#1.1 Setup Sites Variations"}
		New-HeaderDrawing -Values $Values

		Write-Warning "Applying Site Variations configuration..."

		# Activate feature on the root web on the publishing site collection
		Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_LANG_CreateVariationsHierarchies]]
	}
}
else
{
	Write-Warning "'Force' parameter was not specified. Skipping creation..."
}
