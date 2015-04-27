# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-ManagedProperties.ps1.template
# Description	: Create search managed properties
# -----------------------------------------------------------------------

Write-Warning "Starting search crawl..."
Start-DSPContentSourceCrawl -ContentSourceName "[[DSP_SearchContentSourceName]]" -SearchServiceApplicationName "[[DSP_SearchServiceApplicationName]]" -FullCrawl | Wait-DSPContentSourceCrawl

Write-Warning "Applying Search Managed Properties configuration..."

# Activate feature on the root web on the authoring site collection
Initialize-DSPFeature -Url [[DSP_PortalAuthoringSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_MIG_ManagedProperties]]

Write-Warning "Starting yet another search crawl... now that the managed properties are created."
Start-DSPContentSourceCrawl -ContentSourceName "[[DSP_SearchContentSourceName]]" -SearchServiceApplicationName "[[DSP_SearchServiceApplicationName]]" -FullCrawl | Wait-DSPContentSourceCrawl