# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_PUB_ContentTypes]]