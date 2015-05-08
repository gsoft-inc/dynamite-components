# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Fields.template.ps1
# Description	: Create fields
# -----------------------------------------------------------------------

Write-Warning "Applying Fields configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_PUB_Fields]]

