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
# Navigation Module tokens
# ******************************************
. ./Modules/Navigation/Tokens.Navigation.Default.ps1
. ./Modules/Navigation/Tokens.Navigation.Custom.ps1

# ******************************************
# Urls builder
# ******************************************

$DSP_VariationsTargetLabels = "@("
$DSP_PublishingSourceRootWebUrls = "@("
$DSP_PublishingTargetRootWebUrls = "@("

if($DSP_IsMultilingual)
{
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
	}
}
else
{
	# Publishing
	$PublishingCurrentUrl = ("'" + $DSP_PortalPublishingHostNamePath + "'")

	$DSP_PublishingSourceRootWebUrls += $PublishingCurrentUrl
}

$DSP_PublishingTargetRootWebUrls = $DSP_PublishingTargetRootWebUrls.TrimEnd(",") + ")"
$DSP_PublishingSourceRootWebUrls = $DSP_PublishingSourceRootWebUrls.TrimEnd(",") + ")"
$DSP_VariationsTargetLabels = $DSP_VariationsTargetLabels.TrimEnd(",") + ")"