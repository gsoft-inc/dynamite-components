# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-ProfileProperties.ps1.template
# Description	: Create and configures user profile properties
# -----------------------------------------------------------------------

Write-Warning "User profile property configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_TARGET_ProfileProperties]]

