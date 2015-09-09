# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-PageLayouts.template.ps1
# Description	: Create page layouts
# -----------------------------------------------------------------------

Write-Warning "Applying Page Layouts configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CommonCMS_PUB_PageLayouts]]