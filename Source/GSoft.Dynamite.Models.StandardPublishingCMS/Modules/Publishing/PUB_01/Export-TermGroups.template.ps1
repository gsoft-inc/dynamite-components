# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Export-TermGroups.template.ps1
# Description	: Export Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

#Prepare backup file
$BackupFolder = "$CommandDirectory\termgroups-backups"
if (!(Test-Path $BackupFolder)) 
{
	New-Item $BackupFolder -type directory
}

$DateStamp = (Get-Date -Format s) -replace ':', '.'
$ExportFilePath = "$BackupFolder\termgroup-navigation-$DateStamp.xml"

# Taxonomy Settings
$TermStoreName = "[[DSP_TermStoreName]]"

$DefautNavigationtermGroup = "[[DSP_DEFAULT_PortalNavigationTermGroup]]"

$CustomNavigationTermGroup = "[[DSP_CUSTOM_PortalNavigationTermGroup]]"

$NavigationTermGroup = $DefautNavigationtermGroup

if (![string]::IsNullOrEmpty($CustomNavigationTermGroup))
{
	$NavigationTermGroup = $CustomNavigationTermGroup
}

$site = Get-SPSite "[[DSP_PortalPublishingHostNamePath]]"
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

# Portal Navigation Term Group
Try
{
    if ($termStore.Groups[$NavigationTermGroup] -ne $null)
    {
        Export-SPTerms -Group $termStore.Groups[$NavigationTermGroup] -OutputFile $ExportFilePath -ErrorAction Stop
        Write-Host "Export successful."
    }
    else
    {
        Write-Warning "Navigation term group $NavigationTermGroup doesn't exist. No export done."
    }
}
Catch
{
    Write-Warning "$_ No export done."
}