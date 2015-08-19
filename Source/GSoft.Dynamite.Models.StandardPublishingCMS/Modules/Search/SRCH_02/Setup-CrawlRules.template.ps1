# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Standard Publishing CMS
# File          : Setup-CrawlRules.template.ps1
# Description	: Add the crawl rule to exclude all aspx pages in the sharepoint search service.
# -----------------------------------------------------------------------

$SearchApplicationName = "[[DSP_SearchServiceApplicationName]]"
$ExcludeAspxFromSearchIndex = $false
[System.Boolean]::TryParse("[[DSP_ExcludeAspxFromSearchIndex]]", [ref]$ExcludeAspxFromSearchIndex)

if($ExcludeAspxFromSearchIndex)
{
	if((Get-SPEnterpriseSearchCrawlRule -SearchApplication $SearchApplicationName -Identity "http://*aspx" -EA SilentlyContinue))
	{
		Remove-SPEnterpriseSearchCrawlRule -SearchApplication $SearchApplicationName -Identity http://*aspx -confirm:$false
	}
	New-SPEnterpriseSearchCrawlRule -SearchApplication $SearchApplicationName -Path “http://*aspx” -CrawlAsHttp 1 -Type ExclusionRule
}
