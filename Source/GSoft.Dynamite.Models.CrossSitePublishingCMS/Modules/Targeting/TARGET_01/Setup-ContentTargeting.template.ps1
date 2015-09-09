# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying content targeting configuration..."

# Activate feature on all the authoring source variation labels
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{
	Initialize-DSPFeature -Url $_  -Id [[DSP_CrossSitePublishingCMS_TARGET_Auth_ContentTargeting]]
}

# Activate feature on all the authoring target variation labels
[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_  -Id [[DSP_CrossSitePublishingCMS_TARGET_Auth_ContentTargeting]]
}

if(![string]::IsNullOrEmpty("[[DSP_PortalDocsSiteUrl]]"))
{
	# Activate feature on the root web on the docs site collection
	Initialize-DSPFeature -Url [[DSP_PortalDocsSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_TARGET_Docs_ContentTargeting]]
}