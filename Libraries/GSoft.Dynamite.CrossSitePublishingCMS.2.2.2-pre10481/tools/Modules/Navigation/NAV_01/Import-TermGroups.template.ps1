# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Import-TermGroups.ps1.template
# Description	: Import Portal Taxonomy
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

# Portal Keywords Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site [[DSP_PortalPublishingSiteUrl]]).TermStores[0] -InputFile $KeywordsConfigurationFilePath