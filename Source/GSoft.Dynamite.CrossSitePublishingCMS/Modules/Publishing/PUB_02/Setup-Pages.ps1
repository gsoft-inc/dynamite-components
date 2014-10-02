# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
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
