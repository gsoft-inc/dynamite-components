# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Lists.template.ps1
# Description	: Setup pages library
# -----------------------------------------------------------------------

Write-Warning "Applying Pages Library configuration..."

# Activate features on all publishing sites (source an targets)

Write-Warning "Applying Pages Library configuration..."

# Activate features on all publishing sites (source an targets)

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_Lists]]
}

[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_PUB_Lists]]
}