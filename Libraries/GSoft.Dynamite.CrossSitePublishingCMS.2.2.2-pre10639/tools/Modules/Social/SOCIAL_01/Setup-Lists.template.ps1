# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Setup-Lists.ps1.template
# Description	: Setup discussion lists
# -----------------------------------------------------------------------

Write-Warning "Applying discussion lists configuration..."

# Activate features on all publishing sites (sources an targets)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_SOCIAL_DiscussionListsFeatureId]]
}

[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_CommonCMS_SOCIAL_DiscussionListsFeatureId]]
}

