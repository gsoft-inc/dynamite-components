# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_SRCH_ContentTypes]]