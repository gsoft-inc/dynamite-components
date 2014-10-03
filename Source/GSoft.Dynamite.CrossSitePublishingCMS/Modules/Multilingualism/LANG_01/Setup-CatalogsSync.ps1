# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-CatalogsSync.ps1.template
# Description	: Synchronize catalogs
# -----------------------------------------------------------------------

# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("True")

if($IsMultilingual)
{
	Write-Warning "Applying Catalogs Synchronization..."

	# Activate features on source sites (if the solution is multilingual).
	@('http://authoring.dynamite.com/en/rh','http://authoring.dynamite.com/en/com') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "a8c3d6c0-925b-44b8-a2dc-57d41ebe64c7"
	}

	# Sync lists with timer job
	$webApplication = Get-SPWebApplication "http://franck-vm2013/"
	Wait-SPTimerJob -Name "VariationsSpawnSites" -WebApplication $webApplication
	Write-Warning "Waiting for 'VariationsSpawnSites' timer job to finish..."
	Start-Sleep -Seconds 30

	# Activate features on target sites (if the solution is multilingual). If not there is only one source site
	@('http://authoring.dynamite.com/fr/rh','http://authoring.dynamite.com/fr/com') | Foreach-Object{

		Switch-DSPFeature -Url $_ -Id "04643c76-8b9a-4f70-9df4-7565d76e2e8a"
	}
}

