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
	Write-Warning "Activate the language switcher..."

	# Activate features on all authoring sites (sources an targets)
	@('http://authoring.dynamite.com/en') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}

	@('http://authoring.dynamite.com/fr') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}

	
	# Activate features on all publishing sites (sources an targets)
	@('http://intranet.dynamite.com/fr') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}

	@('http://intranet.dynamite.com/en') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "43ac6c19-8306-4fc0-a920-842739971342"
	}
}

