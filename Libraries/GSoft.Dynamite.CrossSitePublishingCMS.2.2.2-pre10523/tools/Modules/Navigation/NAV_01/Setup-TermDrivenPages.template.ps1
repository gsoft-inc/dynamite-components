# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-TermDrivenPages.ps1.template
# Description	: Set up the term driven pages configuration
# -----------------------------------------------------------------------

Write-Warning "Applying Term Driven Pages configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_NAV_TermDrivenPages]]