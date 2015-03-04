# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-PropertyBag.template.ps1
# Description	: Setup Property Bag Mappings
# -----------------------------------------------------------------------

$GoogleAnalyticsKey = "GSOFT_DYNAMITE_GOOGLE_ANALYTICS_TRACKING_ID"
$GoogleAnalyticsKeyValue = "[[DSP_GoogleAnalyticsUA]]"

if(![string]::IsNullOrEmpty($GoogleAnalyticsKeyValue))
{
	Set-DSPWebProperty -Url [[DSP_PortalPublishingSiteUrl]] -Key $GoogleAnalyticsKey -Value $GoogleAnalyticsKeyValue
}