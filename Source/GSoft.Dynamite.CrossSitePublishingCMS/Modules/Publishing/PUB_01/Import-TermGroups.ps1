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
$DefaultNavigationConfigurationFile = "./Default/Default-NavigationTermGroup.xml"
$DefaultRestrictedConfigurationFile = "./Default/Default-RestrictedTermGroup.xml"

$CustomNavigationConfigurationFile = ""
$CustomRestrictedConfigurationFile = ""

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
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site http://intranet.dynamite.com).TermStores[0] -InputFile $NavigationConfigurationFilePath

# Portal Restricted Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site http://intranet.dynamite.com).TermStores[0] -InputFile $RestrictedConfigurationFilePath
