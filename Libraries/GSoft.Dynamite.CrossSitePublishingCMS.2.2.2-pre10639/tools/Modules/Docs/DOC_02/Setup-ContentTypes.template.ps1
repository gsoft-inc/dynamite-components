﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

if(![string]::IsNullOrEmpty("[[DSP_PortalDocsSiteUrl]]"))
{
	# Activate feature on the root web on the docs site collection
	Initialize-DSPFeature -Url [[DSP_PortalDocsSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_ContentTypes]]
}
else 
{
	# Activate feature on the root web on the authoring site collection
	Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_ContentTypes]]
}