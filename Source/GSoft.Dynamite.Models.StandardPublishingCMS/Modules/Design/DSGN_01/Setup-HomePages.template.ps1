# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Pages.template.ps1
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Configuring home page on source label web..."

# Activate feature only on source label web (it will get variated automatically)
[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_DSGN_HomePage]]
}