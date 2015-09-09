# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-LanguageSwitcher.ps1.template
# Description	: Enable the Language Switcher
# -----------------------------------------------------------------------


Write-Warning "Activate the language switcher..."

# Activate features on all authoring sites (sources and targets)
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_LanguageSwitcher]]"
}

[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_LanguageSwitcher]]"
}

	
# Activate features on all publishing sites (sources and targets) - but avoid duplicate activations if publishing site == authoring site
if ("[[DSP_AuthoringSourceRootWebUrls]]".CompareTo("[[DSP_PublishingSourceRootWebUrls]]") -ne 0) {
	[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

		Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_LanguageSwitcher]]"
	}
}

if ("[[DSP_AuthoringTargetRootWebUrls]]".CompareTo("[[DSP_PublishingTargetRootWebUrls]]") -ne 0) {
	[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

		Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_LanguageSwitcher]]"
	}
}


