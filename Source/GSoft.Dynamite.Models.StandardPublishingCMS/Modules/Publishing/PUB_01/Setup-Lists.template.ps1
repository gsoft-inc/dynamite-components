# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Lists.template.ps1
# Description	: Setup pages library
# -----------------------------------------------------------------------

Write-Warning "Applying Pages Library configuration..."


# Activate features on all publishing sites (source an targets)
Get-SPSite "[[DSP_PortalPublishingSiteUrl]]" | Get-SPWeb -Limit ALL | ForEach-Object { Initialize-DSPFeature -Url $_.Url -Id "[[DSP_CommonCMS_PUB_Lists]]" }