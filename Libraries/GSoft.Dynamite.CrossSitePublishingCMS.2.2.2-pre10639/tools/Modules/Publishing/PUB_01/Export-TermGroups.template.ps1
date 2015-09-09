# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Export-TermGroups.ps1.template
# Description	: Export Portal Taxonomy
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

#Prepare backup file
$BackupFolder = "$CommandDirectory\termgroups-backups"
if(!(Test-Path $BackupFolder)) 
{
	New-Item $BackupFolder -type directory
}

$DateStamp = (Get-Date -Format s) -replace ':', '.'
$NavExportFilePath = "$BackupFolder\termgroup-navigation-$DateStamp.xml"
$RestrictedExportFilePath = "$BackupFolder\termgroup-restricted-$DateStamp.xml"

# Configuration Files
$DefaultNavigationConfigurationFile = "[[DSP_DEFAULT_PortalNavigationConfigurationFile]]"
$DefaultRestrictedConfigurationFile = "[[DSP_DEFAULT_PortalRestrictedConfigurationFile]]"

$CustomNavigationConfigurationFile = "[[DSP_CUSTOM_PortalNavigationConfigurationFile]]"
$CustomRestrictedConfigurationFile = "[[DSP_CUSTOM_PortalRestrictedConfigurationFile]]"

$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $DefaultNavigationConfigurationFile
$RestrictedConfigurationFilePath = $CommandDirectory + ".\" + $DefaultRestrictedConfigurationFile

if(![string]::IsNullOrEmpty($CustomNavigationConfigurationFile))
{
	$NavigationConfigurationFilePath = $CommandDirectory + ".\" + $CustomNavigationConfigurationFile
}

if(![string]::IsNullOrEmpty($CustomRestrictedConfigurationFile))
{
	$RestrictedConfigurationFilePath = $CommandDirectory + ".\" + $CustomRestrictedConfigurationFile
}

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

$site = Get-SPSite "[[DSP_PortalPublishingSiteUrl]]"
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

# Portal Navigation Term Group
Try
{
    Export-SPTerms -Group $termStore.Groups[$NavigationTermGroup] -OutputFile $NavExportFilePath -ErrorAction Stop
}
Catch
{
    Write-Warning "$_ No export done for navigation term group."
}

# Portal Restricted Term Group
Try
{
    Export-SPTerms -Group $termStore.Groups[$RestrictedTermGroup] -OutputFile $RestrictedExportFilePath -ErrorAction Stop
}
Catch
{
    Write-Warning "$_ No export done for restricted term group."
}