# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-JavascriptImports.ps1.template
# Description	: Install Javascript Imports
# -----------------------------------------------------------------------

Write-Warning "Applying JS Imports on Publishing site..."

# Activate features on publishing site collection.
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id "[[DSP_CommonCMS_JavascriptImports]]"