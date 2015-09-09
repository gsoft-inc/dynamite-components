# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-LanguageSwitcher.ps1.template
# Description	: Enable the Language Switcher
# -----------------------------------------------------------------------


Write-Warning "Activate the language switcher..."

# Activate the language switcher all webs
Get-SPSite "[[DSP_PortalPublishingSiteUrl]]" | Get-SPWeb -Limit ALL | ForEach-Object { Initialize-DSPFeature -Url $_.Url -Id "[[DSP_CommonCMS_LANG_LanguageSwitcher]]" }