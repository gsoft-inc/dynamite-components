# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-ResultSources.ps1.template
# Description	: Create and configure result sources
# -----------------------------------------------------------------------

Write-Warning "Applying Result Sources configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_TARGET_ResultSources]]
