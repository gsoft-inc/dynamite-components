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
$IsMultilingual = [System.Convert]::ToBoolean("False")

$ParentWebUrl = "http://authoring.dynamite.com"

if($IsMultilingual)
{
	# Create webs under the source label root site
	$ParentWebUrl += "/" + "en"
}

# Create the new SharePoint Web structure
New-DSPWebXml -Webs $webXml.Webs -ParentUrl $ParentWebUrl -UseParentTopNav -Overwrite | ForEach-Object{
	if($IsMultilingual)
	{
		$Web = $_
		$DSP_TargetLabels | ForEach-Object {

			# Sync webs for all taget labels
			Sync-DSPWeb -SourceWeb $Web -LabelToSync $_
		}

		$webApplication = Get-SPWebApplication "http://franck-vm2013/"
		Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication
	}
}
