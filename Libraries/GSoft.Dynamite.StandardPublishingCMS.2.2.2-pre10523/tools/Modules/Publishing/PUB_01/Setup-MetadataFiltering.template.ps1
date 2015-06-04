# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-MetadataFiltreing.template.ps1
# Description	: Activate the SharePoint metadata navigation and filtering
# -----------------------------------------------------------------------

Write-Warning "Activate Metadata and filtering feature configuration..."

# Activate features on source authoring webs
[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

	# SharePoint base feature
	Initialize-DSPFeature -Url $_ -Id "[[DSP_SharePoint_MetadataAndFiltering]]"

	# Standard CMS Publishing feature applies only on the Pages library
	Initialize-DSPFeature -Url $_ -Id "[[DSP_StandardPublishingCMS_PUB_MetadataNavigation]]"
	
}

# Activate features on target authoring webs
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_SharePoint_MetadataAndFiltering]]"
	Initialize-DSPFeature -Url $_ -Id "[[DSP_StandardPublishingCMS_PUB_MetadataNavigation]]"
}