# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ResultTypes.ps1.template
# Description	: Create search result types
# -----------------------------------------------------------------------

Write-Warning "Applying Result Types configuration..."

# Activate feature on the root web on the publishing site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id 990b925b-fe6e-41ea-ae6a-3011308a303e
