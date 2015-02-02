# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-LanguageSwitcher.ps1.template
# Description	: Enable the Language Switcher
# -----------------------------------------------------------------------


Write-Warning "Activate the language switcher..."

# Activate features on all authoring sites (sources an targets)
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LANG_LanguageSwitcher]]"
}

[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LANG_LanguageSwitcher]]"
}

	
# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LANG_LanguageSwitcher]]"
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LANG_LanguageSwitcher]]"
}


