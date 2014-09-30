# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Catalogs.ps1.template
# Description	: Create catalogs
# -----------------------------------------------------------------------

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$DefaultConfigurationFile = "./Default/Default-Catalogs.xml"

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

Write-Warning "Applying Catalogs configuration..."

# Apply default site columns creation and content types
[xml]$featureXml = Get-Content $ConfigurationFilePath

# Activate features
Initialize-DSPWebFeatures $featureXml $true
