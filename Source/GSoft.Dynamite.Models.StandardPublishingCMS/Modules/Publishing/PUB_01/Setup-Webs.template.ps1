# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Standard Publishing CMS
# File          : Setup-SPWebs.ps1.template
# Description	: Create a SharePoint SPWebs structure
# -----------------------------------------------------------------------

param([switch] $Force=$false)

# Check sub sites settings. We use a custom token for Standard Publishing CMS.
# In the Cross Site Publishing CMS model, root web URLs are defined directly in the token file. They are used after by the Tokens.Common.ps1 logic to get multilingual URLs. 
# I you have 200 subsites to create, this method can't be applied...
$HasSubsites = [System.Convert]::ToBoolean("[[DSP_HasSubsites]]")

if ($Force) {

	# Check the web configuration in the token file
	if ($HasSubsites)
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

		# Creates Webs structure under the root web of the source variation branch (only one web here)
		[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object {

			# Create the new SharePoint Web structure
			$Webs = Import-DSPWebStructure -InputFileName $ConfigurationFilePath -ParentUrl $_
		}
	}

	# Check Multilingual settings
	$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

	if($IsMultilingual)
	{
		$values = @{"Step: " = "#2.1 Setup Webs Variations"}
		New-HeaderDrawing -Values $Values

		# Sync all webs with variations
		$Webs | Foreach-Object {

			Initialize-DSPFeature -Url $_.Url -Id "[[DSP_CommonCMS_LANG_SyncWeb]]"
		}

		# Run the timer job for webs creation
		$webApplication = Get-SPWebApplication "[[DSP_PortalWebAppUrl]]"
		Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication

		$AuthoringUrlsByLabels = [[DSP_AuthoringUrlsByLabels]]

		# Update webs properties for target labels
		$AuthoringUrlsByLabels.Keys | Foreach-Object {

			Import-DSPWebStructure -InputFileName $ConfigurationFilePath -ParentUrl $_ -VariationLabel $AuthoringUrlsByLabels.get_Item($_)
		}
	}
}
else
{
	Write-Warning "'Force' parameter was not specified. Skipping creation..."
}