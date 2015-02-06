# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ReusableContent.ps1.template
# Description	: Create Reusable Content
# -----------------------------------------------------------------------

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_PUB_ReusableContent]]
