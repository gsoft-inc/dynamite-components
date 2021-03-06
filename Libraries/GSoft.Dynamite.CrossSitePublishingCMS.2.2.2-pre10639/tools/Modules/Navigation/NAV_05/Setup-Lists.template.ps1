﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Lists.ps1.template
# Description	: Setup pages library
# -----------------------------------------------------------------------

Write-Warning "Applying Pages Library configuration..."

# Only apply the open term creation on the source authoring webs in the content pages list
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_NAV_ContentPagesList]]
}

