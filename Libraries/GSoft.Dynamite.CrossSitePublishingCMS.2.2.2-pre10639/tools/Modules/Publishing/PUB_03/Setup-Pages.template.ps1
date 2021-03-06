﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
# -----------------------------------------------------------------------

Write-Warning "Applying Page instances configuration..."

# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_PUB_CategoryPages]]
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_PUB_CategoryPages]]
}