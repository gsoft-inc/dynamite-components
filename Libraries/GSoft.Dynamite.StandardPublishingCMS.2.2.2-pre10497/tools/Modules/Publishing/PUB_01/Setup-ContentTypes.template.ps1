# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-ContentTypes.template.ps1
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_PUB_ContentTypes]]