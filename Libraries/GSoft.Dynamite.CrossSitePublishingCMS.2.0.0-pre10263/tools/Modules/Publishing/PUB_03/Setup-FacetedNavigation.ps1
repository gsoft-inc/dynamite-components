# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-FacetedNavigation.ps1.template
# Description	: Setup faceted navigation
# -----------------------------------------------------------------------

Write-Warning "Applying Faceted navigation configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CrossSitePublishingCMS_PUB_FacetedNavigation]]
