# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Pages.ps1.template
# Description	: Create page instances
# -----------------------------------------------------------------------

# TODO: Setup-Pages activates a CrossSitePublishingCMS feature, which makes little to no sense.
# Figure out a way to refactor this into a CommonCMS feature or do these setup steps only as part of
# your plugin project.

#Write-Warning "Applying Page instances configuration (with Home Pages)..."

## Activate features on all publishing sites (sources an targets)
#[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

#	Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_PUB_ItemPages]]
#}

#[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

#	Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_PUB_ItemPages]]
#}