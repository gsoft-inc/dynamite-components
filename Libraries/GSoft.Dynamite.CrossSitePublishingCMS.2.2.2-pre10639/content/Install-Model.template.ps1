<#
.SYNOPSIS
	Installs the cross-site publishing model.
	
.DESCRIPTION
	Installs solution packages and modules for this model.
#>

# ********** PRE-FLIGHT CHECK ********** #
# Unblock files if they're from another computer
Get-ChildItem -Recurse | Unblock-File

# Stop on first error
$ErrorActionPreference = "Stop"

# Solutions deployment check
if (-not (Test-DSPDeployedSolutions -SolutionsConfigurationFilePath "$(Get-Location)\Solutions\Default\Default-Solutions.xml")) { 
	Write-Error -Message "Solutions defined in '.\Solutions\Default\Default-Solutions.xml' are not correctly deployed."
}
if (Test-Path -Path "$(Get-Location)\Solutions\Custom\Custom-Solutions.xml") {
	if (-not (Test-DSPDeployedSolutions -SolutionsConfigurationFilePath "$(Get-Location)\Solutions\Custom\Custom-Solutions.xml")) { 
		Write-Error -Message "Solutions defined in '.\Solutions\Default\Custom-Solutions.xml' are not correctly deployed."
	}
}

# Check if Sharegate is installed
if ((Get-Module | where { $_.Name -eq "Sharegate" }).Count -ne 1) {
	Write-Error -Message "Sharegate PowerShell module is not correctly installed."
}

# TODO: Nice to have a check on which service locator is loaded into the GAC

# ********** START LOGGING ********** #
Start-DSPLogging -commandName "Install-Model" -folder ((Get-Location).Path + "\Logs")
$header = @{"Solution Model: " = "[CrossSitePublishingCMS]";}
New-HeaderDrawing -Values $header

try {
	#region ********** PUBLISHING MODULE ********** #
	.\Modules\Publishing\PUB_01\Install-PUB01.ps1
	.\Modules\Publishing\PUB_02\Install-PUB02.ps1
	.\Modules\Publishing\PUB_03\Install-PUB03.ps1
	#endregion

	#region ********** NAVIGATION MODULE ********** #
	.\Modules\Navigation\NAV_01\Install-NAV01.ps1
	.\Modules\Navigation\NAV_02\Install-NAV02.ps1
	.\Modules\Navigation\NAV_05\Install-NAV05.ps1
	#endregion

	#region ********** DOCUMENT MANAGEMENT MODULE ********** #
	.\Modules\Docs\DOC_01\Install-DOC01.ps1
	.\Modules\Docs\DOC_02\Install-DOC02.ps1
	#endregion

	#region ********** LIFE CYCLE MODULE ********** #
	.\Modules\Lifecycle\LFCL_01\Install-LFCL01.ps1
	#endregion

	#region ********** DESIGN MODULE ********** #
	.\Modules\Design\DSGN_01\Install-DSGN01.ps1
	#endregion

	#region ********** MULTILINGUALISM MODULE ********** #
	# Check Multilingual settings
	$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
	if($IsMultilingual)
	{
		# Why LANG02 before LANG01?
		.\Modules\Multilingualism\LANG_02\Install-LANG02.ps1
		.\Modules\Multilingualism\LANG_01\Install-LANG01.ps1
		.\Modules\Multilingualism\LANG_03\Install-LANG03.ps1
	}
	#endregion

	#region ********** SEARCH MODULE ********** #
	.\Modules\Search\SRCH_02\Install-SRCH02.ps1

	$EnableCustomSEOFeature = $false
	[System.Boolean]::TryParse("[[DSP_EnableSEOFields]]", [ref]$EnableCustomSEOFeature)
	if($EnableCustomSEOFeature)
	{
		.\Modules\Search\SRCH_03\Install-SRCH03.ps1
	}
	#endregion

	#region ********** SOCIAL MODULE ********** #
	$EnableSocial = $false
	[System.Boolean]::TryParse("[[DSP_EnableSocialModule]]", [ref]$EnableSocial)
	if($EnableSocial)
	{
		.\Modules\Social\SOCIAL_01\Install-SOCIAL01.ps1
	}
	#endregion

	#region ********** TARGETING MODULE ********** #
	$EnableTargeting = $false
	[System.Boolean]::TryParse("[[DSP_EnableTargeting]]", [ref]$EnableTargeting)
	if($EnableTargeting)
	{
		.\Modules\Targeting\TARGET_01\Install-TARGET01.ps1
		.\Modules\Targeting\TARGET_02\Install-TARGET02.ps1
		.\Modules\Targeting\TARGET_03\Install-TARGET03.ps1
	}
	#endregion

	#region ********** MIGRATION MODULE ********** #
	# Notes: We need to import content after all content types were created
	.\Modules\Migration\MIG_01\Install-MIG01.ps1

    # Very important to import reusable contents after solution content to allow a control of the ID sequence
    .\Modules\Publishing\PUB_04\Install-PUB04.ps1
	#endregion

	#region ********** POST DEPLOYMENT SCRIPTS ********** #
	.\Execute-PostDeploymentScript.ps1
	#endregion
} catch {
    # Output error for logging to catch it
	$_ | Out-String
	throw
} finally {
	# ********** STOP LOGGING ********** #
	Stop-DSPLogging
}


