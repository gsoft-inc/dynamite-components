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
$DefautKeywordstermGroup = "[[DSP_DEFAULT_PortalKeywordsTermGroup]]"

$CustomKeywordsTermGroup = "[[DSP_CUSTOM_PortalKeywordsTermGroup]]"

$KeywordsTermGroup = $DefautKeywordstermGroup

if(![string]::IsNullOrEmpty($CustomKeywordsTermGroup))
{
	$KeywordsTermGroup = $CustomKeywordsTermGroup
}

Remove-DSPTermGroup -GroupName "$KeywordsTermGroup"
