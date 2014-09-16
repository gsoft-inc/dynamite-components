# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Export-TermGroups.ps1.template
# Description	: Export Portal Taxonomy
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

# Taxonomy Settings
$DefautNavigationtermGroup = "[[DSP_DEFAULT_PortalNavigationTermGroup]]"
$DefautRestrictedtermGroup = "[[DSP_DEFAULT_PortalRestrictedTermGroup]]"

$CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"
$CustomRestrictedTermGroup = "[[DSP_CUSTOM_PortalRestrictedTermGroup]]"

$NavigationTermGroup = $DefautNavigationtermGroup
$RestrictedTermGroup = $DefautRestrictedtermGroup

if(![string]::IsNullOrEmpty($CustomNavigationTermGroup))
{
	$NavigationTermGroup = $CustomNavigationTermGroup
}

if(![string]::IsNullOrEmpty($CustomRestrictedTermGroup))
{
	$RestrictedTermGroup = $CustomRestrictedTermGroup
}

# Portal Navigation Term Group
Export-SPTerms -Group (Get-SPTaxonomySession -Site "[[DSP_PortalPublishingHostNamePath]]").TermStores[0].Groups[$NavigationTermGroup] -OutputFile $NavigationConfigurationFilePath

# Portal Restricted Term Group
Export-SPTerms -Group (Get-SPTaxonomySession -Site "[[DSP_PortalPublishingHostNamePath]]").TermStores[0].Groups[$RestrictedTermGroup] -OutputFile $RestrictedConfigurationFilePath
