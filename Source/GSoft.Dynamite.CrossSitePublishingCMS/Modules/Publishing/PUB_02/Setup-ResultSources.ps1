# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ResultSources.ps1.template
# Description	: Create search result sources
# -----------------------------------------------------------------------

Write-Warning "Applying Result Sources configuration..."

# Activate feature on the root web on the authoring site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id 8d99c11b-135e-48e3-ad8f-e04e06d8b654
