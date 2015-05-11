# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ContentTypes.ps1.template
# Description	: Create content types structure
# -----------------------------------------------------------------------

Write-Warning "Applying Content Types configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CommonCMS_PUB_ContentTypes]]

# Avoid duplicate activation if publishing site is also authoring site
if ("[[DSP_PortalAuthoringSiteUrl]]".CompareTo("[[DSP_PortalPublishingSiteUrl]]") -ne 0) {
	# Activate feature on the root web on the publishing site collection
	Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_PUB_ContentTypes]]
}

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_LANG_ContentTypes]]