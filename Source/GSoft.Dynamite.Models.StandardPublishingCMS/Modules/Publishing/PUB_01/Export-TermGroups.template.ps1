# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Export-TermGroups.template.ps1
# Description	: Export Portal Taxonomy
# -----------------------------------------------------------------------

# Define parameters
Param (
        [Parameter(Mandatory=$false)]
        [string]$CurrentNavigationExportFile
)

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Configuration Files
$DefaultNavigationConfigurationFile = "[[DSP_DEFAULT_PortalNavigationConfigurationFile]]"

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile

if(![string]::IsNullOrEmpty($CurrentNavigationExportFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + "\" + $CurrentNavigationExportFile
}
elseif(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
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