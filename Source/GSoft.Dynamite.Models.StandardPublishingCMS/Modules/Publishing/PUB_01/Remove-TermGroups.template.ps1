# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Remove-TermGroups.template.ps1
# Description	: Remove Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Taxonomy Settings
$TermStoreName = "[[DSP_TermStoreName]]"

$DefautNavigationtermGroup = "[[DSP_DEFAULT_PortalNavigationTermGroup]]"

$CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"

$NavigationTermGroup = $DefautNavigationtermGroup

if (![string]::IsNullOrEmpty($CustomNavigationTermGroup))
{
	$NavigationTermGroup = $CustomNavigationTermGroup
}

$site = Get-SPSite "[[DSP_PortalPublishingSiteUrl]]"
if ($site -eq $null)
{
	return
}

$taxonomySession = $site | Get-DSPTaxonomySession
if ($taxonomySession -eq $null)
{
	return
}

$termStore = $null
if (![string]::IsNullOrEmpty($TermStoreName) -and !$TermStoreName.StartsWith("[[")) {
    $termStore = $taxonomySession | Get-DSPTermStore -Name $TermStoreName
} else {
    $termStore = $taxonomySession | Get-DSPTermStore -Default
}

if ($termStore -eq $null)
{
	return
}

Remove-DSPTermGroup -TermStore $termStore -GroupName "$NavigationTermGroup"