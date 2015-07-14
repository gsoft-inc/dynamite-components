# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Standard Publishing CMS
# File          : Setup-SPWebs.ps1.template
# Description	: Create a SharePoint SPWebs structure
# -----------------------------------------------------------------------

Param (
        [Parameter(Mandatory=$false)]
        [switch]$Force=$false,

        [Parameter(Mandatory=$false)]
        [switch]$IgnoreWebs=$false
)

# Check sub sites settings. We use a custom token for Standard Publishing CMS.
# In the Cross Site Publishing CMS model, root web URLs are defined directly in the token file. They are used after by the Tokens.Common.ps1 logic to get multilingual URLs. 
# I you have 200 subsites to create, this method can't be applied...
$HasSubsites = [System.Convert]::ToBoolean("[[DSP_HasSubsites]]")

if ($Force) {

    # Check the web configuration in the token file
    if ($HasSubsites)
    {
        if ($IgnoreWebs -eq $false)
        {
            $0 = $myInvocation.MyCommand.Definition
            $CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

            $DefaultConfigurationFile = "[[DSP_DEFAULT_PortalWebsConfigurationFile]]"
            $CustomConfigurationFile = "[[DSP_CUSTOM_PortalWebsConfigurationFile]]"

            $ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

            if(![string]::IsNullOrEmpty($CustomConfigurationFile))
            {
                $ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
            }

            [xml]$webXml = Get-Content $ConfigurationFilePath

            # Creates Webs structure under the root web of the source variation branch (only one web here)
            [[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object {

                # Create the new SharePoint Web structure
                $Webs = Import-DSPWebStructure -InputFileName $ConfigurationFilePath -ParentUrl $_ -Overwrite:$Force
            }	

            # Check Multilingual settings
            $IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

            if($IsMultilingual)
            {
                $values = @{"Step: " = "#2.1 Setup Webs Variations"}
                New-HeaderDrawing -Values $Values

                # Sync all webs with variations
                $Webs | Foreach-Object {

                    Initialize-DSPFeature -Url $_.Url -Id "[[DSP_CommonCMS_LANG_SyncWeb]]"
                }

                # Run the timer job for webs creation
                $Site = Get-SPSite "[[DSP_PortalPublishingSiteUrl]]"
                Wait-SPTimerJob -Name "VariationsSpawnSites" -Site $Site

                # Get variation target labels
                $TargetLabels = {[[DSP_VariationsTargetLabels]]}.Invoke()
                $TargetLabels.Remove("[[DSP_SourceLabel]]")

                # Test if all webs have a peer variation web created
                # ALL webs must have a variation peer for ALL target labels. Throws an error otherwise.
                $Webs | Foreach-Object {

                    # Need to get the updated web with variations settings
                    $CurrentSourceWeb = Get-SPWeb $_.Url
                    $CurrentSourceWebUrl = $CurrentSourceWeb.Url

                    $TargetLabels | ForEach-Object {

                        Write-Host "Test variation peer URL for web '$CurrentSourceWebUrl' for label $_..." -NoNewline							

                        $Web = Get-VariationPeerWeb -SourceWeb $CurrentSourceWeb -Label $_					
                        if ($Web -eq $null)
                        {
                            Write-Host -ForegroundColor red "error!"
                            Write-Error "The variation peer web for '$CurrentSourceWebUrl' doesn't exist! Aborting deployment..."
                        }
                        else
                        {
                            Write-Host -ForegroundColor green "OK!"
                        }
                    }	
                }

                $AuthoringUrlsByLabels = [[DSP_AuthoringUrlsByLabels]]

                # Update webs properties for target labels
                $AuthoringUrlsByLabels.Keys | Foreach-Object {

                    Import-DSPWebStructure -InputFileName $ConfigurationFilePath -ParentUrl $_ -VariationLabel $AuthoringUrlsByLabels.get_Item($_)
                }
            }
        }
        else
        {
            Write-Warning "'IgnoreWebs' parameter was specified. Skipping webs creation..."
        }
    }
}
else
{
    Write-Warning "'Force' parameter was not specified. Skipping creation..."
}