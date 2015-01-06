# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

# Activate feature on the root web on the authoring site collection
Switch-DSPFeature -Url http://authoring.dynamite.com  -Id 88d32ecd-2a4c-4cff-ad09-b74ab5aca18c
