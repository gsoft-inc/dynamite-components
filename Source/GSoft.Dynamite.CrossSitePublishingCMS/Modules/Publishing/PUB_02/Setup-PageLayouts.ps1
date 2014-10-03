# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-PageLayouts.ps1.template
# Description	: Create page layouts
# -----------------------------------------------------------------------

Write-Warning "Applying Page Layouts configuration..."

# Activate feature on the root web on the authoring site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id 374b7569-9e11-4ecd-8771-da59be52141e
