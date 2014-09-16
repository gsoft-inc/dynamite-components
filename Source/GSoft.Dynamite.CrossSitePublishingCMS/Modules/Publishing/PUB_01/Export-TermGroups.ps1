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

# Taxonomy Settings
$DefautNavigationtermGroup = "Portal - Navigation"
$DefautRestrictedtermGroup = "Portal - Restricted"

$CustomNavigationTermGroup = ""
$CustomRestrictedTermGroup = ""

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
Export-SPTerms -Group (Get-SPTaxonomySession -Site "http://intranet.dynamite.com").TermStores[0].Groups[$NavigationTermGroup] -OutputFile $NavigationConfigurationFilePath

# Portal Restricted Term Group
Export-SPTerms -Group (Get-SPTaxonomySession -Site "http://intranet.dynamite.com").TermStores[0].Groups[$RestrictedTermGroup] -OutputFile $RestrictedConfigurationFilePath
