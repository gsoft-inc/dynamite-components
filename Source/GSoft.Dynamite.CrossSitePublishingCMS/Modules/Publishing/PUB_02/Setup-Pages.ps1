# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Applying Page instances configuration..."

# Activate features on all publishing sites (sources an targets)
@('http://intranet.dynamite.com/fr') | Foreach-Object{

	Switch-DSPFeature -Url $_ -Id c0dbca2d-b477-4d91-bb55-b342f6458221
}

@('http://intranet.dynamite.com/en') | Foreach-Object{

	Switch-DSPFeature -Url $_ -Id c0dbca2d-b477-4d91-bb55-b342f6458221
}
