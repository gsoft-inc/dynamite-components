# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Permissions.template.ps1
# Description	: Set SharePoint Permissions
# -----------------------------------------------------------------------

# You can send in a -Force parameter to delete all existing sites.
# Otherwise, if any of the sites already exists, the configuration
# setup will abort.
param([switch] $Force=$false)

# Verbose preference
$VerbosePreference ="Continue"

# Define working directory
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)


$DefaultConfigurationFile = "[[DSP_DEFAULT_PortalPermissionsConfigurationFile]]"
$CustomConfigurationFile = "[[DSP_CUSTOM_PortalPermissionsConfigurationFile]]"

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
}

Write-Warning "Applying Permissions configuration..."

Set-DSPWebPermissions $ConfigurationFilePath 