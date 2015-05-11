# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Fields.ps1.template
# Description	: Create fields
# -----------------------------------------------------------------------

Write-Warning "Applying Fields configuration..."

if(![string]::IsNullOrEmpty("[[DSP_PortalDocsSiteUrl]]"))
{
	# Activate feature on the root web on the docs site collection
	Initialize-DSPFeature -Url [[DSP_PortalDocsSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_Fields]]
}
else 
{
	# Activate feature on the root web on the authoring site collection
	Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_Fields]]
}