﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Import-TermGroups.ps1.template
# Description	: Import Portal Taxonomy
# -----------------------------------------------------------------------

param([string] $LogFolderPath)

# ------------------------ Log Init -------------------------------------

# Verbose preference
$VerbosePreference ="Continue"

$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $LogFolderPath + "\" + $ScriptName +"_Dynamite_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile
# -----------------------------------------------------------------------

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# Configuration Files
$DefaultNavigationConfigurationFile = "./Default/Default-NavigationTermGroup.xml"
$DefaultRestrictedConfigurationFile = "./Default/Default-RestrictedTermGroup.xml"

$CustomNavigationConfigurationFile = ""
$CustomRestrictedConfigurationFile = ""

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

# Portal Navigation Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site http://intranet.dynamite.com).TermStores[0] -InputFile $NavigationConfigurationFilePath

# Portal Restricted Term Group
Import-SPTerms -ParentTermStore (Get-SPTaxonomySession -Site http://intranet.dynamite.com).TermStores[0] -InputFile $RestrictedConfigurationFilePath

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------
