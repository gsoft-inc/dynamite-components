# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-LanguageSwitcher.ps1.template
# Description	: Enable the Language Switcher
# -----------------------------------------------------------------------

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("True")

if($IsMultilingual)
{
	Write-Warning "Applying Catalogs Synchronization..."

	# Activate features on source sites (if the solution is multilingual).
	@('http://authoring.dynamite.com/en') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}

    # Activate features on target sites (if the solution is multilingual). If not there is only one source site
	@('http://authoring.dynamite.com/fr') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}
}

