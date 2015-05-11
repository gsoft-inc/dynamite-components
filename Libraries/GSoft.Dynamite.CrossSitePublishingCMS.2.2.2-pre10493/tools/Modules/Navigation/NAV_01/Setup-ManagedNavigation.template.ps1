# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ManagedNavigation.ps1.template
# Description	: Setup managed navigation
# -----------------------------------------------------------------------

Write-Warning "Applying managed navigation configuration..."

# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_NAV_TaxonomyManagedNavigation]]
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_NAV_TaxonomyManagedNavigation]]
}

