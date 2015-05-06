# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-EventReceivers.ps1.template
# Description	: Attach event receivers
# -----------------------------------------------------------------------

Write-Warning "Applying Event Receivers configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_NAV_BrowsableItemsEventReceivers]]

# Common CMS hook to add nav-related event receivers to any CT you like on the publishing site 
# (by default the INavigationEventReceivers config is empty)
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_NAV_EventReceivers]]