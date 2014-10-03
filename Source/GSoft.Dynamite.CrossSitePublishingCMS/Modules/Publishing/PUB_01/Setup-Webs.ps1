# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-SPWebs.ps1.template
# Description	: Create a SharePoint SPWebs structure
# -----------------------------------------------------------------------

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$DefaultConfigurationFile = "./Default/Default-Webs.xml"
$CustomConfigurationFile = ""

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
}

[xml]$webXml = Get-Content $ConfigurationFilePath

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("True")

# Create the new SharePoint Web structure
New-DSPWebXml -Webs $webXml.Webs -ParentUrl "http://authoring.dynamite.com/en" -UseParentTopNav -Overwrite

if($IsMultilingual)
{
	Write-Warning "Applying Variations configuration..."

	# Activate features on source sites - Authoring side
	@('http://authoring.dynamite.com/en/rh','http://authoring.dynamite.com/en/com') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "630a68f6-f722-4ba8-85ba-8daf2f8fcf53"
	}

	# Activate features on source sites - Publishing side
	@('http://intranet.dynamite.com/en') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "630a68f6-f722-4ba8-85ba-8daf2f8fcf53"
	}

	$webApplication = Get-SPWebApplication "http://franck-vm2013/"
	Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication
}
