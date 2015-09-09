# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-ImageRenditions.ps1.template
# Description	: Create Image renditions configuration
# -----------------------------------------------------------------------

Write-Warning "Applying Image Renditions configuration..."

$UploadPicturesInDocCenter = [System.Convert]::ToBoolean("[[DSP_UploadPicturesInDocCenter]]")
if(![string]::IsNullOrEmpty("[[DSP_PortalDocsSiteUrl]]") -and $UploadPicturesInDocCenter)
{
	# Activate feature on the root web on the docs site collection
	Initialize-DSPFeature -Url [[DSP_PortalDocsSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_ImageRenditions]]
}
else 
{
	# Activate feature on the root web on the authoring site collection
	Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_DOC_ImageRenditions]]
}