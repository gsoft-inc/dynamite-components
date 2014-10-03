# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Catalogs.ps1.template
# Description	: Create catalogs
# -----------------------------------------------------------------------

Write-Warning "Applying Catalogs configuration..."

# Activate features on source sites (if the solution is multilingual). If not there is only one source site
@('http://authoring.dynamite.com/en/rh','http://authoring.dynamite.com/en/com') | Foreach-Object{

	Switch-DSPFeature -Url $_ -Id "04643c76-8b9a-4f70-9df4-7565d76e2e8a"
}
