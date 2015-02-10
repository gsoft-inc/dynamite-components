# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ImageRenditions.ps1.template
# Description	: Create Image renditions configuration
# -----------------------------------------------------------------------

Write-Warning "Applying Image Renditions configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringHostNamePath]]  -Id [[DSP_CrossSitePublishingCMS_DOC_ImageRenditions]]