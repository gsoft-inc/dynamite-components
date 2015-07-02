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
$DefaultKeywordsConfigurationFile = "[[DSP_DEFAULT_PortalKeywordsConfigurationFile]]"

$CustomKeywordsConfigurationFile = "[[DSP_CUSTOM_PortalKeywordsConfigurationFile]]"

$KeywordsConfigurationFilePath = $CommandDirectory + ".\" + $DefaultKeywordsConfigurationFile

if(![string]::IsNullOrEmpty($CustomKeywordsConfigurationFile))
{
	$KeywordsConfigurationFilePath = $CommandDirectory + ".\" + $CustomKeywordsConfigurationFile
}

# Taxonomy Settings
$DefautKeywordstermGroup = "[[DSP_DEFAULT_PortalKeywordsTermGroup]]"

$CustomKeywordsTermGroup = "[[DSP_CUSTOM_PortalKeywordsTermGroup]]"

$KeywordsTermGroup = $DefautKeywordstermGroup

if(![string]::IsNullOrEmpty($CustomKeywordsTermGroup))
{
	$KeywordsTermGroup = $CustomKeywordsTermGroup
}

# Portal Keywords Term Group
Try
{
    Export-SPTerms -Group (Get-SPTaxonomySession -Site "[[DSP_PortalPublishingSiteUrl]]").TermStores[0].Groups[$KeywordsTermGroup] -OutputFile $KeywordsConfigurationFilePath
}
Catch
{
    Write-Warning "$_ No export done."
}