# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ResultSources.ps1.template
# Description	: Create search result sources
# -----------------------------------------------------------------------

Write-Warning "Applying Result Sources configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_PUB_ResultSources]]

Write-Warning "Opening up the search REST API to anonymous users..."

Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_PUB_SearchRESTAnonymous]]

