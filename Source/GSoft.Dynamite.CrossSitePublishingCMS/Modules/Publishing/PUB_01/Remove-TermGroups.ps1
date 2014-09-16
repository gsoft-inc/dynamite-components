# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Remove-TermGroups.ps1.template
# Description	: Remove Portal Taxonomy
# -----------------------------------------------------------------------

param([string] $LogFolderPath)

# ------------------------ Log Init -------------------------------------

$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $LogFolderPath + "\" + $ScriptName +"_Dynamite_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Taxonomy Settings
$DefautNavigationtermGroup = "Portal - Navigation"
$DefautRestrictedtermGroup = "Portal - Restricted"

$CustomNavigationTermGroup = ""
$CustomRestrictedTermGroup = ""

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

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------
