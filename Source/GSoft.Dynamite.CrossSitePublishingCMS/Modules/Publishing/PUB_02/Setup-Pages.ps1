# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Applying Page instances configuration..."

# Activate feature on the root web on the authoring site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id c0dbca2d-b477-4d91-bb55-b342f6458221
