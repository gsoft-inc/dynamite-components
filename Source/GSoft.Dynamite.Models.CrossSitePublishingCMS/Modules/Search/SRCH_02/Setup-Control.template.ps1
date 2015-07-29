# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Control.template.ps1
# Description	: Add the control containing the Google Id Tracker in the additional page head
# -----------------------------------------------------------------------

$DefaultGoogleTrackerFeatureId = "[[DSP_CrossSitePublishingCMS_SRCH_GoogleAnalyticsTracking]]"

if(![string]::IsNullOrEmpty("[[DSP_GoogleAnalyticsUA]]"))
{
	$values = @{"Step: " = "#2 Enable the feature"}
	New-HeaderDrawing -Values $Values

	Write-Warning "Applying Control configuration..."
	Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id $DefaultGoogleTrackerFeatureId
}
