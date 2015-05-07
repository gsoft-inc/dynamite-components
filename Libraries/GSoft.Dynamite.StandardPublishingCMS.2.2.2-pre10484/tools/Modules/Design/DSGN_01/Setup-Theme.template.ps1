# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Theme.ps1.template
# Description	: Install Theme And logo 
# -----------------------------------------------------------------------

Write-Warning "Applying JS Imports on Publishing site..."

# Activate features on publishing site collection.
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id "[[DSP_CommonCMS_JavascriptImports]]"

Write-Warning "Applying Publishing Theme..."

# Activate features on publishing site collection.
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]] -Id "[[DSP_CommonCMS_Theme]]"