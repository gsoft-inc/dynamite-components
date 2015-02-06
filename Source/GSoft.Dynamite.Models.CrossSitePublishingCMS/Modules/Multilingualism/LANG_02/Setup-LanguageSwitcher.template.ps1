# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-LanguageSwitcher.ps1.template
# Description	: Enable the Language Switcher
# -----------------------------------------------------------------------

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

if($IsMultilingual)
{
	Write-Warning "Applying Catalogs Synchronization..."

	# Activate features on source sites (if the solution is multilingual).
	[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LanguageSwitcher]]"
	}

    # Activate features on target sites (if the solution is multilingual). If not there is only one source site
	[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LanguageSwitcher]]"
	}
}

