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
. ./Modules/Navigation/Tokens.Navigation.Custom.ps1

# ******************************************
# Design Module tokens
# ******************************************
. ./Modules/Design/Tokens.Design.Default.ps1
. ./Modules/Design/Tokens.Design.Custom.ps1

# ******************************************
# Docs Module tokens
# ******************************************
. ./Modules/Docs/Tokens.Docs.Default.ps1
. ./Modules/Docs/Tokens.Docs.Custom.ps1

# ******************************************
# Lifecycle Module tokens
# ******************************************
. ./Modules/LifeCycle/Tokens.LifeCycle.Default.ps1

# ******************************************
# Search Module tokens
# ******************************************
. ./Modules/Search/Tokens.Search.Default.ps1

# ******************************************
# Urls builder
# ******************************************

$DSP_VariationsTargetLabels = "@("
$DSP_AuthoringSourceRootWebUrls = "@("
$DSP_PublishingSourceRootWebUrls = "@("
$DSP_AuthoringTargetRootWebUrls = "@("
$DSP_PublishingTargetRootWebUrls = "@("

# Hash table of site url mappings between Authoring and Publishing
$DSP_CrossSiteMappings = "@{"

# Hash table of urls by label
$DSP_AuthoringUrlsByLabels = "@{"

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

		# Publishing
		$PublishingCurrentUrl = ("'" + $DSP_PortalPublishingHostNamePath + "/" + $label +"'")
		    
		if($label -eq $DSP_SourceLabel)
        {
			
			$DSP_PublishingSourceRootWebUrls +=  $PublishingCurrentUrl + ","
        }
        else
        {
            $DSP_PublishingTargetRootWebUrls += $PublishingCurrentUrl + ","
        }	

		# Authoring
		if ($DSP_HasSubWebs)
		{
			# Means there is at least one sub web
			$DSP_PortalAuthoringRootWebs | Foreach-Object{

				$AuthoringCurrentUrl = ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label + "/" + $_ +"'")
	
				if($label -eq $DSP_SourceLabel)
				{
				   $DSP_AuthoringSourceRootWebUrls += $AuthoringCurrentUrl + ","
				}
				else
				{
				   $DSP_AuthoringTargetRootWebUrls += $AuthoringCurrentUrl + ","
				}		

				# Add the source labels mapping
				$DSP_CrossSiteMappings += ( $AuthoringCurrentUrl + "=" + $PublishingCurrentUrl + ";" )		

				# Add the URL for the current label
				$DSP_AuthoringUrlsByLabels += ( $AuthoringCurrentUrl + "=" + "'" + $label + "'" + ";" )
			}   
		}
		else
		{
			$AuthoringCurrentUrl = ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $label +"'")

			if($label -eq $DSP_SourceLabel)
			{
				$DSP_AuthoringSourceRootWebUrls += $AuthoringCurrentUrl + ","
			}
			else
			{
				$DSP_AuthoringTargetRootWebUrls += $AuthoringCurrentUrl + ","
			}
			
			# Add the source labels mapping
			$DSP_CrossSiteMappings += ( $AuthoringCurrentUrl + "=" + $PublishingCurrentUrl + ";" )			
			
			# Add the URL for the current label
			$DSP_AuthoringUrlsByLabels += ( $AuthoringCurrentUrl + "=" + "'" + $label + "'" + ";" )
		}	            
	}
}
else
{
    $DSP_PortalAuthoringSourceWebUrl = $DSP_PortalAuthoringHostNamePath

	# Publishing
	$PublishingCurrentUrl = ("'" + $DSP_PortalPublishingHostNamePath + "'")

	$DSP_PublishingSourceRootWebUrls += $PublishingCurrentUrl

	if ($DSP_HasSubWebs)
	{
		# Means there is at least one sub web
		$DSP_PortalAuthoringRootWebs | Foreach-Object{

			$AuthoringCurrentUrl = ("'" + $DSP_PortalAuthoringHostNamePath + "/" + $_ + "'")
	
			$DSP_AuthoringSourceRootWebUrls += $AuthoringCurrentUrl + ","

			# Add the source labels mapping
			$DSP_CrossSiteMappings += ( $AuthoringCurrentUrl + "=" + $PublishingCurrentUrl + ";" )	

			# Add the URL for the current label
			$DSP_AuthoringUrlsByLabels += ( $AuthoringCurrentUrl + "=" + "'" + $label + "'" + ";" )
		}
	}
	else
	{
		$AuthoringCurrentUrl = ("'" + $DSP_PortalAuthoringHostNamePath + "'")

		$DSP_AuthoringSourceRootWebUrls += $AuthoringCurrentUrl

		# Add the source labels mapping
		$DSP_CrossSiteMappings += ( $AuthoringCurrentUrl + "=" + $PublishingCurrentUrl + ";" )
		
		# Add the URL for the current label
		$DSP_AuthoringUrlsByLabels += ( $AuthoringCurrentUrl + "=" + "'" + $label + "'" + ";" )
	}
}

$DSP_AuthoringTargetRootWebUrls = $DSP_AuthoringTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_AuthoringSourceRootWebUrls = $DSP_AuthoringSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingTargetRootWebUrls = $DSP_PublishingTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingSourceRootWebUrls = $DSP_PublishingSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_VariationsTargetLabels = $DSP_VariationsTargetLabels.TrimEnd(",") + ")"
$DSP_CrossSiteMappings = $DSP_CrossSiteMappings.TrimEnd(";") + "}"
$DSP_AuthoringUrlsByLabels = $DSP_AuthoringUrlsByLabels.TrimEnd(";") + "}"
