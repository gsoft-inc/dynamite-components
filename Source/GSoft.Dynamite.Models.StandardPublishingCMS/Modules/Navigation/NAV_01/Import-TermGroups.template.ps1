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
if (![string]::IsNullOrEmpty($TermStoreName) -and !$TermStoreName.StartsWith("[[")) 
{
    $termStore = $taxonomySession | Get-DSPTermStore -Name $TermStoreName
} 
else 
{
    $termStore = $taxonomySession | Get-DSPTermStore -Default
}

if ($termStore -eq $null)
{
    return
}

# Portal Navigation Term Group
Try
{
    Import-SPTerms -ParentTermStore $termStore -InputFile $KeywordsConfigurationFilePath -ErrorAction Stop
    Write-Host "Import successful."
}
Catch
{
    Write-Warning "There was an error in importing Menu term group. $_"
}