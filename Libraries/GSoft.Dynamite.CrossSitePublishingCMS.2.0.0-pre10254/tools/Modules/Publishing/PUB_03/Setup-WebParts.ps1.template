# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-WebParts.ps1.template
# Description	: Create Web Parts
# -----------------------------------------------------------------------

Write-Warning "Applying Web Parts configuration..."

$CustomWebPartsFeatureId = "[[DSP_CUSTOM_CrossSitePublishingCMS_PUB_WebParts]]"

# Deploys custom display templates before.
if(![string]::IsNullOrEmpty($CustomWebPartsFeatureId))
{
	Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id $CustomWebPartsFeatureId
}

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingHostNamePath]]  -Id [[DSP_CommonCMS_PUB_WebParts]]