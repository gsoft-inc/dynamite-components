# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-EventReceivers.template.ps1
# Description	: Attach event receivers
# -----------------------------------------------------------------------

Write-Warning "Applying Event Receivers configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_StandardPublishingCMS_NAV_TargetPagesEventReceivers]]