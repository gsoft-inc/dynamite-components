# -----------------------------------------------------------------------
# Copyright     : GSoft @2015
# Model         : Cross Site Publishing CMS
# File          : Setup-DocLibraries.template.ps1
# Description   : Create catalogs
# -----------------------------------------------------------------------

Write-Warning "Creating document libraries..."

# Activates a feature creating document libraries on different webs in the docs site collection
if($DSP_PortalDocumentCenterWebs)
{
    $DSP_PortalDocumentCenterWebs | Foreach-Object {
    $webUrl = "[[DSP_PortalDocsSiteUrl]]" + $_
    Initialize-DSPFeature -Url $webUrl -Id [[DSP_CrossSitePublishingCMS_DOC_Lists]]
}