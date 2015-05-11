# -----------------------------------------------------------------------
# Copyright     : GSoft @2015
# Model         : Cross Site Publishing CMS
# File          : Setup-Permissions.template.ps1
# Description   : Set SharePoint Permissions for the webs of the documents center
# -----------------------------------------------------------------------

if ([System.Convert]::ToBoolean("[[DSP_DocCenterHasSubWebs]]"))
{
    # Define working directory
    $0 = $myInvocation.MyCommand.Definition
    $CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

    $ConfigurationFile = "[[DSP_CUSTOM_DocCenterPermissionsConfigFile]]"

    if(![string]::IsNullOrEmpty($ConfigurationFile))
    {
        $ConfigurationFilePath = $CommandDirectory + ".\" + $ConfigurationFile

        [xml]$permissionsXml = Get-Content $ConfigurationFilePath

        # Setup permissions on the webs
        Write-Warning "Applying Permissions configuration..."
        Set-DSPWebPermissions $ConfigurationFilePath 
    } 
    else 
    {
        Write-Warning "No xml configuration file of permissions found. Skipping permissions setup."
    }
}