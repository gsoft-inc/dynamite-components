# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-MasterPage.ps1.template
# Description	: Install Master Page
# -----------------------------------------------------------------------

Write-Warning "Applying Publishing MasterPage..."

# Activate features on publishing site collection.
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id "[[DSP_CommonCMS_MasterPage]]"