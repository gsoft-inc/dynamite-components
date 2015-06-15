# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-Catalogs.ps1.template
# Description	: Create catalogs
# -----------------------------------------------------------------------

Write-Warning "Applying Catalogs configuration..."

# Activate feature on the root web of the source authoring site collection(s)
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

    Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_TARGET_Catalogs]]
}

# Activate feature on the root web of the target authoring site collection(s)
[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

    Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_TARGET_Catalogs]]
}