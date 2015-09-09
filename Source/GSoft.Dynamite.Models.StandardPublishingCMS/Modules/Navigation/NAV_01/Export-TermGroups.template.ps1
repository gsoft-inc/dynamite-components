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

# Export Navigation Term Group
Try
{
    if ($termStore.Groups[$KeywordsTermGroup] -ne $null)
    {
        Export-SPTerms -Group $termStore.Groups[$KeywordsTermGroup] -OutputFile $ExportFilePath -ErrorAction Stop
        Write-Host "Export successful."
    }
    else
    {
        Write-Warning "Navigation term group $KeywordsTermGroup doesn't exist. No export done."
    }	
}
Catch
{
    Write-Warning "$_ No export done."
}