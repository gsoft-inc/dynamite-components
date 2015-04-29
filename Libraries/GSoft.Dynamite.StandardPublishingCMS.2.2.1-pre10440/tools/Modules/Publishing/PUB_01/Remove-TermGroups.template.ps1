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

$CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"

$NavigationTermGroup = $DefautNavigationtermGroup

if(![string]::IsNullOrEmpty($CustomNavigationTermGroup))
{
	$NavigationTermGroup = $CustomNavigationTermGroup
}

Remove-DSPTermGroup -GroupName "$NavigationTermGroup"