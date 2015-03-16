# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-SocialMetaTags.ps1.template
# Description	: Add User Control in the SharePoint Delegate Control
# -----------------------------------------------------------------------

Write-Warning "Initializing feature..."

# Activate feature on the root web on the publishing site collection

$CustomFeatureId = "[[DSP_Custom_CrossSitePublishingCMS_SRCH_SocialMetaTags]]"

if (![string]::IsNullOrEmpty($CustomFeatureId)) {
    Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id $CustomFeatureId
}
else
{
	Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_SRCH_Fields]]
}