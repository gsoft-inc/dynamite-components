# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-EventReceivers.ps1.template
# Description	: Attach event receivers
# -----------------------------------------------------------------------

Write-Warning "Applying Event Receivers configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringHostNamePath]]  -Id [[DSP_CrossSitePublishingCMS_NAV_BrowsableItemsEventReceivers]]