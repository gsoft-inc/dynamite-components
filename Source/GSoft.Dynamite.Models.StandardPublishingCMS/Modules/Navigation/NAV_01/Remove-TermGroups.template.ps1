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

Remove-DSPTermGroup -TermStore $termStore -GroupName "$KeywordsTermGroup"