# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-SocialMetaTags.ps1.template
# Description	: Add User Control in the SharePoint Delegate Control
# -----------------------------------------------------------------------

Write-Warning "Initializing feature..."

# Activate feature on the root web on the publishing site collection

Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_SRCH_SocialMetaTags]]
