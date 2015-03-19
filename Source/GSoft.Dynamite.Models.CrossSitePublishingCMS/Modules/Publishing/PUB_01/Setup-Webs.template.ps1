# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-SPWebs.ps1.template
# Description	: Create a SharePoint SPWebs structure
# -----------------------------------------------------------------------

# Check the web configuration
if ([System.Convert]::ToBoolean("[[DSP_HasSubWebs]]"))
{
	$0 = $myInvocation.MyCommand.Definition
	$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

	$DefaultConfigurationFile = "[[DSP_DEFAULT_PortalWebsConfigurationFile]]"
	$CustomConfigurationFile = "[[DSP_CUSTOM_PortalWebsConfigurationFile]]"

	$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile

	if(![string]::IsNullOrEmpty($CustomConfigurationFile))
	{
		$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
	}

	[xml]$webXml = Get-Content $ConfigurationFilePath

	# Create the new SharePoint Web structure
	New-DSPWebXml -Webs $webXml.Webs -ParentUrl "[[DSP_PortalAuthoringSourceWebUrl]]" -UseParentTopNav -Overwrite
}

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

if($IsMultilingual)
{
	$values = @{"Step: " = "#2.1 Setup Webs Variations"}
	New-HeaderDrawing -Values $Values

	Write-Warning "Applying Web Variations configuration..."

	# Activate features on source sites - Authoring side
	[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

		Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_SyncWeb]]"
	}

	# Activate features on source sites - Publishing side
	[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object{

		Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_SyncWeb]]"
	}

	$webApplication = Get-SPWebApplication "[[DSP_PortalWebAppUrl]]"
	Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication
}