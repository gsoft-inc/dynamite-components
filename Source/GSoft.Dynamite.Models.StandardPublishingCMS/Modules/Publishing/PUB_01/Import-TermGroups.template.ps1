# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Import-TermGroups.template.ps1
# Description	: Import Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Configuration Files
$DefaultNavigationConfigurationFile = "[[DSP_DEFAULT_PortalNavigationConfigurationFile]]"
$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile

if (![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + "\" + $CustomNavigationConfigurationFile
}

$site = Get-SPSite "[[DSP_PortalPublishingHostNamePath]]"
if ($site -eq $null)
{
	return
}

$taxonomySession = $site | Get-DSPTaxonomySession
if ($taxonomySession -eq $null)
{
	return
}

$termStore = $taxonomySession | Get-DSPTermStore -Default
if ($termStore -eq $null)
{
	return
}

# Portal Navigation Term Group
Try
{
    Import-SPTerms -ParentTermStore $termStore -InputFile $NavigationConfigurationFilePath -ErrorAction Stop
    Write-Host "Import successful."
}
Catch
{
    Write-Warning "$_ No import done."
}