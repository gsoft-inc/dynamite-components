# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Lists.ps1.template
# Description	: Setup pages library
# -----------------------------------------------------------------------

Write-Warning "Applying Pages Library configuration..."

# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_Lists ]]
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_Lists ]]
}

