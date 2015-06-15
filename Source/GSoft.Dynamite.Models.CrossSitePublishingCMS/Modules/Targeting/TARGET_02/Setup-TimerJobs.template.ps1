# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-TimerJobs.ps1.template
# Description	: Create and configure timer jobs
# -----------------------------------------------------------------------

Write-Warning "Applying Timer Job configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_TARGET_TimerJobs]]

