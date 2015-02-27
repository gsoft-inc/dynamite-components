# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ResultTypes.ps1.template
# Description	: Create search result types
# -----------------------------------------------------------------------

Write-Warning "Applying Result Types configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_PUB_ResultTypes]]