# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-MetadataFiltreing.ps1.template
# Description	: Activate the SharePoint metadata navigation and filtering
# -----------------------------------------------------------------------

Write-Warning "Activate Metadata and filtering feature configuration..."

# Activate features on source authoring webs
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_SharePoint_MetadataAndFiltering]]"
	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_PUB_MetadataNavigation]]"
	
}

# Activate features on target authoring webs
[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_SharePoint_MetadataAndFiltering]]"
	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_PUB_MetadataNavigation]]"
}
