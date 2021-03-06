﻿# -----------------------------------------------------------------------
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

# Store the term store name in the root web property bags
$termStoreName = "[[DSP_TermStoreName]]"
if ([string]::IsNullOrEmpty($termStoreName) -eq $false)
{
	Set-DSPWebProperty -Url "[[DSP_PortalPublishingSiteUrl]]" -Key "TermStoreName" -Value $termStoreName
	Set-DSPWebProperty -Url "[[DSP_PortalAuthoringSiteUrl]]" -Key "TermStoreName" -Value $termStoreName
	Set-DSPWebProperty -Url "[[DSP_PortalDocsSiteUrl]]" -Key "TermStoreName" -Value $termStoreName
}

# If multilingual is configured, activate the variation hierarchie features on authoring and publishing sites
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
if($IsMultilingual)
{
	$values = @{"Step: " = "#1.1 Setup Sites Variations"}
	New-HeaderDrawing -Values $Values

	Write-Warning "Applying Site Variations configuration..."

	# Activate feature on the root web on the authoring site collection
	Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]] -Id [[DSP_CommonCMS_LANG_CreateVariationsHierarchies]]
	
	# Avoid duplicate web variations sync if publishing site is also authoring site
	if ("[[DSP_PortalAuthoringSiteUrl]]".CompareTo("[[DSP_PortalPublishingSiteUrl]]") -ne 0) {
		# Activate feature on the root web on the publishing site collection
		Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id [[DSP_CommonCMS_LANG_CreateVariationsHierarchies]]
	}
}



