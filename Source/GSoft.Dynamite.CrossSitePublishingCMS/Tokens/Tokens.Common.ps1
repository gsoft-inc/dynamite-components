# ******************************************
# Deployment Tokens 
# ******************************************
. ./Solutions/Tokens.Solutions.Default.ps1
. ./Solutions/Tokens.Solutions.Custom.ps1


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
# Navigation Module tokens
# ******************************************
. ./Modules/Navigation/Tokens.Navigation.Default.ps1

# ******************************************
# Design Module tokens
# ******************************************
. ./Modules/Design/Tokens.Design.Default.ps1

# ******************************************
# Urls builder
# ******************************************

$DSP_VariationsTargetLabels = "@("
$DSP_AuthoringSourceRootWebUrls = "@("
$DSP_PublishingSourceRootWebUrls = "@("
$DSP_AuthoringTargetRootWebUrls = "@("
$DSP_PublishingTargetRootWebUrls = "@("

# Check if there is sub webs configuration
$DSP_HasSubWebs = $false
if($DSP_PortalAuthoringRootWebs.Length -gt 0)
{
	$DSP_HasSubWebs = $true
}

if($DSP_IsMultilingual)
{
	# Set the source variation site url for authoring site
	$DSP_PortalAuthoringSourceWebUrl = $DSP_PortalAuthoringHostNamePath + "/" + $DSP_SourceLabel

    $i = 1
	$DSP_VariationsLabels | Foreach-Object{
	    
        $DSP_VariationsTargetLabels += "'" + $_ + "'" + ","
		$label = $_

		# Authoring
		if ($DSP_HasSubWebs)
		{
			# Means there is at least one sub web
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
		}
		else
		{
			if($label -eq $DSP_SourceLabel)
			{
				$DSP_AuthoringSourceRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label +"'") + ","
			}
			else
			{
				$DSP_AuthoringTargetRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label +"'") + ","
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

	if ($DSP_HasSubWebs)
	{
		# Means there is at least one sub web
		$DSP_PortalAuthoringRootWebs | Foreach-Object{
	
			$DSP_AuthoringSourceRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $_ + "'") + ","
		}
	}
	else
	{
		$DSP_AuthoringSourceRootWebUrls += ("'" + $DSP_PortalAuthoringHostNamePath + "'")
	}
}


$DSP_AuthoringTargetRootWebUrls = $DSP_AuthoringTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_AuthoringSourceRootWebUrls = $DSP_AuthoringSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingTargetRootWebUrls = $DSP_PublishingTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingSourceRootWebUrls = $DSP_PublishingSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_VariationsTargetLabels = $DSP_VariationsTargetLabels.TrimEnd(",") + ")"
