# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Configuring home page on source label web..."

# Activate feature only on source label web (it will get variated automatically)
[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_DSGN_HomePage]]
}