# -------------------------------------------------------------------------------
# Copyright     : GSoft @2015
# Model         : Cross Site Publishing CMS
# File          : Setup-Webs.template.ps1
# Description   : Create a SharePoint SPWebs structure for the documents center
# -------------------------------------------------------------------------------

# Check the web configuration
if ([System.Convert]::ToBoolean("[[DSP_DocCenterHasSubWebs]]"))
{
    $0 = $myInvocation.MyCommand.Definition
    $CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

    $ConfigurationFile = "[[DSP_CUSTOM_DocCenterWebsConfigFile]]"

    if(![string]::IsNullOrEmpty($ConfigurationFile))
    {
        $ConfigurationFilePath = $CommandDirectory + ".\" + $ConfigurationFile

        [xml]$webXml = Get-Content $ConfigurationFilePath

        # Create the new SharePoint Web structure
        New-DSPWebXml -Webs $webXml.Webs -ParentUrl "[[DSP_PortalDocsSiteUrl]]" -UseParentTopNav -Overwrite
    } 
    else 
    {
        Write-Warning "No xml configuration file of sub-webs found. Skipping creation process."
    }
}