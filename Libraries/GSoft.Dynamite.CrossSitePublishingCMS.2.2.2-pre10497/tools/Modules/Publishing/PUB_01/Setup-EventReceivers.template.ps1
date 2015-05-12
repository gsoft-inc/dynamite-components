# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-EventReceivers.ps1.template
# Description	: Attach event receivers
# -----------------------------------------------------------------------

Write-Warning "Applying Event Receivers configuration..."

# Activate feature on the root web on the publishing site collection (Before Page instances creation)
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_LANG_EventReceivers]]
