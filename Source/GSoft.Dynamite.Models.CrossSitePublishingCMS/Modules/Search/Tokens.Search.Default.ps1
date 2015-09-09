# ============================================
# SEARCH MODULE FEATURES
# ============================================

$DSP_CrossSitePublishingCMS_SRCH_GoogleAnalyticsTracking = "08e93dfc-0383-4172-8493-89b04cf3fb04"
$DSP_CrossSitePublishingCMS_SRCH_Fields = "4dc166d1-08ab-4c34-a939-e12d05ad111e"
$DSP_CrossSitePublishingCMS_SRCH_ContentTypes = "da2b1eb0-fd1e-47b8-af13-cc7656a65015"
$DSP_CrossSitePublishingCMS_SRCH_EventReceivers = "7090b1b7-f268-4393-bbbd-3416cdc3c8d6"
$DSP_CrossSitePublishing_SRCH_SocialMetaTags = "3c4ecc61-9c84-4927-9603-1b66b72cb0c7"

# If the DSP_GoogleAnalyticsUA hasn't been set, defaut to null
if ((Get-Variable -Name "DSP_GoogleAnalyticsUA" -ErrorAction Ignore) -eq $null) { 
	$DSP_GoogleAnalyticsUA = $null
}