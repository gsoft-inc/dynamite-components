# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Remove-TermGroups.ps1.template
# Description	: Remove Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Taxonomy Settings
$TermStoreName = "[[DSP_TermStoreName]]"

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

# Open taxonomy session on correct term store
$site = Get-SPSite "[[DSP_PortalPublishingHostNamePath]]"
if($site -eq $null)
{
	return
}

$taxonomySession = $site | Get-DSPTaxonomySession
if($taxonomySession -eq $null)
{
	return
}

$termStore = $null
if (![string]::IsNullOrEmpty($TermStoreName) -and !$TermStoreName.StartsWith("[[")) {
    $termStore = $taxonomySession | Get-DSPTermStore -Name $TermStoreName
} else {
    $termStore = $taxonomySession | Get-DSPTermStore -Default
}

if($termStore -eq $null)
{
	return
}

Remove-DSPTermGroup -TermStore $termStore -GroupName "$RestrictedTermGroup"
Remove-DSPTermGroup -TermStore $termStore -GroupName "$NavigationTermGroup"