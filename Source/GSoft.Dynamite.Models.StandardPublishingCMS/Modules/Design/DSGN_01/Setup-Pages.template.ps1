# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Pages.template.ps1
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Configuring home pages..."

# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_HomePages]]
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_HomePages]]
}