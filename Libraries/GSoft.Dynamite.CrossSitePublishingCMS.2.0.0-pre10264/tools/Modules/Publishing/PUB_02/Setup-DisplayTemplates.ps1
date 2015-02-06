# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-DisplayTemplates.ps1.template
# Description	: Create display templates
# -----------------------------------------------------------------------

Write-Warning "Applying Display Templates configuration..."

$CustomDisplayTemplatesFeatureId = "[[DSP_CUSTOM_CrossSitePublishingCMS_PUB_DisplayTemplates]]"

# Deploys custom display templates before.
if(![string]::IsNullOrEmpty($CustomDisplayTemplatesFeatureId))
{
	Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id $CustomDisplayTemplatesFeatureId
}

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CrossSitePublishingCMS_PUB_DisplayTemplates]]

