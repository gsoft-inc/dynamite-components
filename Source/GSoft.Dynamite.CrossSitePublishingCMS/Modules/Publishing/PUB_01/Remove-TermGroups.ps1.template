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

Remove-DSPTermGroup -GroupName "$RestrictedTermGroup"
Remove-DSPTermGroup -GroupName "$NavigationTermGroup"