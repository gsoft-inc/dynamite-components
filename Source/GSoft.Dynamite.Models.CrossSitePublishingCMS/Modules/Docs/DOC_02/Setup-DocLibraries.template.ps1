# -----------------------------------------------------------------------
# Copyright     : GSoft @2015
# Model         : Cross Site Publishing CMS
# File          : Setup-DocLibraries.template.ps1
# Description   : Create catalogs
# -----------------------------------------------------------------------

Write-Warning "Creating document libraries..."

$urlArray = [[DSP_PortalDocumentCenterWebs]]

# Activates a feature creating document libraries on different webs in the docs site collection
if($urlArray.Length -gt 0)
{
    $urlArray | Foreach-Object {
        $webUrl = "[[DSP_PortalDocsSiteUrl]]" + $_
        Initialize-DSPFeature -Url $webUrl -Id [[DSP_CrossSitePublishingCMS_DOC_Lists]]
    }
}