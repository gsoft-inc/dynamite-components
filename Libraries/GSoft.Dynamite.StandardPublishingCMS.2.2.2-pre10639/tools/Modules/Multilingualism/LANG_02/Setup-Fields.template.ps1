# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Fields.ps1.template
# Description	: Create fields
# -----------------------------------------------------------------------

Write-Warning "Applying Fields configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id [[DSP_CommonCMS_LANG_Fields]]