﻿# ******************************************
# Deployment Tokens 
# ******************************************
. ./Solutions/Tokens.Solutions.Default.ps1
. ./Solutions/Tokens.Solutions.Custom.ps1


# ******************************************
# Dynamite Features Guid 
# ******************************************

$DSP_CommonCMS_ContentTypes = "88d32ecd-2a4c-4cff-ad09-b74ab5aca18c"
$DSP_CommonCMS_Fields = "97a3a3ef-5989-46f0-a117-6f489f58a26b"
$DSP_CrossSitePublishingCMS_Catalogs = "04643c76-8b9a-4f70-9df4-7565d76e2e8a"
$DSP_CrossSitePublishingCMS_CatalogsSync = "a8c3d6c0-925b-44b8-a2dc-57d41ebe64c7"
$DSP_CommonCMS_PageLayouts = "374b7569-9e11-4ecd-8771-da59be52141e"
$DSP_CrossSitePublishingCMS_Pages = "c0dbca2d-b477-4d91-bb55-b342f6458221"
$DSP_CrossSitePublishingCMS_ResultSources = "8d99c11b-135e-48e3-ad8f-e04e06d8b654"
$DSP_CommonCMS_SyncWeb = "630a68f6-f722-4ba8-85ba-8daf2f8fcf53"

# ******************************************
# Publishing Module tokens
# ******************************************
. ./Modules/Publishing/Tokens.Publishing.Default.ps1
. ./Modules/Publishing/Tokens.Publishing.Custom.ps1

# ******************************************
# Multilingualism Module tokens
# ******************************************
. ./Modules/Multilingualism/Tokens.Multilingualism.Default.ps1

# ******************************************
# Urls builder
# ******************************************

$DSP_VariationsTargetLabels = "@("
$DSP_AuthoringSourceRootWebUrls = "@("
$DSP_PublishingSourceRootWebUrls = "@("
$DSP_AuthoringTargetRootWebUrls = "@("
$DSP_PublishingTargetRootWebUrls = "@("

if($DSP_IsMultilingual)
{
	# Set the source variation site url for authoring site
	$DSP_PortalAuthoringSourceWebUrl = $DSP_PortalAuthoringHostNamePath + "/" + $DSP_SourceLabel

    $i = 1
	$DSP_VariationsLabels | Foreach-Object{
	    
        $DSP_VariationsTargetLabels += "'" + $_ + "'" + ","
		$label = $_

		# Authoring
		$DSP_PortalAuthoringRootWebs | Foreach-Object{
	
            if($label -eq $DSP_SourceLabel)
            {
               $DSP_AuthoringSourceRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label + "/" + $_ +"'") + ","
            }
            else
            {
               $DSP_AuthoringTargetRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label + "/" + $_ +"'") + ","
            }		
		}   
		
		# Publishing    
		if($label -eq $DSP_SourceLabel)
        {
			$DSP_PublishingSourceRootWebUrls += ("'" + $DSP_PortalPublishingHostNamePath + "/" + $label +"'") + ","
        }
        else
        {
            $DSP_PublishingTargetRootWebUrls += ("'" + $DSP_PortalPublishingHostNamePath + "/" + $label +"'") + ","
        }	            
	}
}
else
{
    $DSP_PortalAuthoringSourceWebUrl = $DSP_PortalAuthoringHostNamePath

	$DSP_PortalAuthoringRootWebs | Foreach-Object{
	
		$DSP_AuthoringSourceRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $_ + "'") + ","
	}	
}


$DSP_AuthoringTargetRootWebUrls = $DSP_AuthoringTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_AuthoringSourceRootWebUrls = $DSP_AuthoringSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingTargetRootWebUrls = $DSP_PublishingTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingSourceRootWebUrls = $DSP_PublishingSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_VariationsTargetLabels = $DSP_VariationsTargetLabels.TrimEnd(",") + ")"
