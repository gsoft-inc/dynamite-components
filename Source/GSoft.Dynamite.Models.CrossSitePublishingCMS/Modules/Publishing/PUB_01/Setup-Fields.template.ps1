﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Fields.ps1.template
# Description	: Create fields
# -----------------------------------------------------------------------

Write-Warning "Applying Fields configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CommonCMS_PUB_Fields]]

# Avoid duplicate activation if publishing site is also authoring site
if ("[[DSP_PortalAuthoringSiteUrl]]".CompareTo("[[DSP_PortalPublishingSiteUrl]]") -ne 0) {
	# Activate feature on the root web on the publishing site collection
	Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_PUB_Fields]]
}

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_LANG_Fields]]

