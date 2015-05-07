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

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile

if(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $CustomNavigationConfigurationFile
}

# Portal Navigation Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site [[DSP_PortalPublishingHostNamePath]]).TermStores[0] -InputFile $NavigationConfigurationFilePath
