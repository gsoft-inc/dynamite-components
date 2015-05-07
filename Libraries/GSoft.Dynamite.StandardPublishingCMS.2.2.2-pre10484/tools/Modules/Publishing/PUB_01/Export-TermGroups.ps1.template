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

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile

if(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $CustomNavigationConfigurationFile
}

# Taxonomy Settings
$DefautNavigationtermGroup = "[[DSP_DEFAULT_PortalNavigationTermGroup]]"

$CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"

$NavigationTermGroup = $DefautNavigationtermGroup

if(![string]::IsNullOrEmpty($CustomNavigationTermGroup))
{
	$NavigationTermGroup = $CustomNavigationTermGroup
}

# Portal Navigation Term Group
Export-SPTerms -Group (Get-SPTaxonomySession -Site "[[DSP_PortalPublishingHostNamePath]]").TermStores[0].Groups[$NavigationTermGroup] -OutputFile $NavigationConfigurationFilePath