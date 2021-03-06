﻿																									  # -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-CatalogConnections.ps1.template
# Description	: Create catalog connections
# -----------------------------------------------------------------------

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

# If the solution is not multilingual we create catalog connections. Otherwise, catalog connections will be made AFTER catalog synchronisation [LANG_02]
if($IsMultilingual -eq $false)
{
	Write-Warning "Starting search crawl..."
	Start-DSPContentSourceCrawl -ContentSourceName "[[DSP_SearchContentSourceName]]" -SearchServiceApplicationName "[[DSP_SearchServiceApplicationName]]" -FullCrawl | Wait-DSPContentSourceCrawl

	Write-Warning "Applying Catalog Connections configuration..."

	$HashTable = [[DSP_CrossSiteMappings]]

	$HashTable.Keys | Foreach-Object { 

		# Activate feature on each authoring webs
		Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_NAV_CatalogConnections]]
	}
}