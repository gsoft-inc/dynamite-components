﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-SPWebs.ps1.template
# Description	: Create a SharePoint SPWebs structure
# -----------------------------------------------------------------------

param([string] $LogFolderPath)

# ------------------------ Log Init -------------------------------------

$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $LogFolderPath + "\" + $ScriptName +"_Dynamite_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile
# -----------------------------------------------------------------------

# Verbose preference
$VerbosePreference ="Continue"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$DefaultConfigurationFile = "./Default/Default-Webs.xml"
$CustomConfigurationFile = ""

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
}

[xml]$webXml = Get-Content $ConfigurationFilePath

# Create the new SharePoint Web structure
New-DSPWebXml -Webs $webXml.Webs -ParentUrl "http://authoring.dynamite.com" -UseParentTopNav -Overwrite

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------
