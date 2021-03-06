﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Controls.ps1.template
# Description	: Deploys controls for the global navigation
# -----------------------------------------------------------------------

Write-Warning "Deploying Controls for the global navigation..."

$FeatureId = "[[DSP_DEFAULT_CrossSitePublishingCMS_NAV_NavigationControl]]"
$CustomFeatureId = "[[DSP_CUSTOM_CrossSitePublishingCMS_NAV_NavigationControl]]"

if(![string]::IsNullOrEmpty($CustomFeatureId))
{
	$FeatureId = $CustomFeatureId
}

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id $FeatureId