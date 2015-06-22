# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Import-TermGroups.template.ps1
# Description	: Import Portal Taxonomy
# -----------------------------------------------------------------------

# Define parameters
Param (
        [Parameter(Mandatory=$false)]
        [string]$CurrentNavigationImportFile
)

$UseDefaultTermGroups = "[[DSP_UseDefaultTermGroups]]"

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Configuration Files
$DefaultNavigationConfigurationFile = "[[DSP_DEFAULT_PortalNavigationConfigurationFile]]"

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile

if(!$UseDefaultTermGroups && ![string]::IsNullOrEmpty($CurrentNavigationImportFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + "\" + $CurrentNavigationImportFile
}
elseif(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $CustomNavigationConfigurationFile
}

# Portal Navigation Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site [[DSP_PortalPublishingHostNamePath]]).TermStores[0] -InputFile $NavigationConfigurationFilePath
