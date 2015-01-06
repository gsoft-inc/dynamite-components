# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Import-TermGroups.ps1.template
# Description	: Import Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Configuration Files
$DefaultNavigationConfigurationFile = "[[DSP_DEFAULT_PortalNavigationConfigurationFile]]"
$DefaultRestrictedConfigurationFile = "[[DSP_DEFAULT_PortalRestrictedConfigurationFile]]"

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"
$CustomRestrictedConfigurationFile = "[[DSP_CUSTOM_PortalRestrictedConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile
$RestrictedConfigurationFilePath = $CommandDirectory + ".\" + $DefaultRestrictedConfigurationFile

if(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $CustomNavigationConfigurationFile
}

if(![string]::IsNullOrEmpty($CustomRestrictedConfigurationFile))
{
	$RestrictedConfigurationFilePath = $CommandDirectory + ".\" + $CustomRestrictedConfigurationFile
}

# Portal Navigation Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site [[DSP_PortalPublishingHostNamePath]]).TermStores[0] -InputFile $NavigationConfigurationFilePath

# Portal Restricted Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site [[DSP_PortalPublishingHostNamePath]]).TermStores[0] -InputFile $RestrictedConfigurationFilePath