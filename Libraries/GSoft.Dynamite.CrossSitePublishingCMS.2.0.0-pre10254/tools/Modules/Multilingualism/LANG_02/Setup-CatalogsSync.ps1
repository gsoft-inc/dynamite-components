# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-CatalogsSync.ps1.template
# Description	: Synchronize catalogs
# -----------------------------------------------------------------------

Write-Warning "Applying Catalogs Synchronization..."

# Activate features on source sites (if the solution is multilingual).
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_LANG_CatalogsSync]]"
}

# Sync lists with timer job
$webApplication = Get-SPWebApplication "[[DSP_PortalWebAppUrl]]"
Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication
Write-Warning "Waiting for 'VariationsSpawnSites' timer job to finish..."
Start-Sleep -Seconds 60

# Activate features on target sites (if the solution is multilingual). If not there is only one source site
[[DSP_AuthoringTargetRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CrossSitePublishingCMS_PUB_Catalogs]]"
}
