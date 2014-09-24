# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
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

$DefaultConfigurationFile = "./Default/Default-Pages.xml"

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

Write-Warning "Applying Pages configuration..."

# Apply default site columns creation and content types
[xml]$featureXml = Get-Content $ConfigurationFilePath

# Activate features
Initialize-DSPWebFeatures $featureXml $true

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------
