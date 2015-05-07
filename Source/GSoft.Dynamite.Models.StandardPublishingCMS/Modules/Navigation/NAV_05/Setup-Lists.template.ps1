# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-Lists.template.ps1
# Description	: Setup pages library
# -----------------------------------------------------------------------

Write-Warning "Applying Pages Library configuration..."

# Only apply the open term creation on the source authoring webs in the content pages list
[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id [[DSP_StandardPublishingCMS_NAV_PagesLibraryList]]
}