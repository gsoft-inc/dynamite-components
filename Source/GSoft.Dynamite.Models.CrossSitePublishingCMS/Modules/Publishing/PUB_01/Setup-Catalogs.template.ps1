﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Catalogs.ps1.template
# Description	: Create catalogs
# -----------------------------------------------------------------------

Write-Warning "Applying Catalogs configuration..."

# Activate features on source sites (if the solution is multilingual). If not there is only one source site
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_PUB_Catalogs]]"
}