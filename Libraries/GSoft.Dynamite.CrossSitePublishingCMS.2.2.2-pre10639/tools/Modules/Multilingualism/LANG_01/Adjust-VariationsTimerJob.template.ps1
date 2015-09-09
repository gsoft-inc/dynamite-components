# ------------------------------------------------------------------------------------------------------------
# Copyright		  : GSoft @2015
# Model  		    : Cross Site Publishing CMS
# File          : Adjust-VariationsTimerJob.template.ps1
# Description	  : This script adjusts the Variations Propagate List Items timer job (default to every 5 minutes)
# ------------------------------------------------------------------------------------------------------------

$webApp = "[[DSP_PortalWebAppUrl]]"
$defaultTimerSchedule = "[[DSP_DEFAULT_VariationTimerJobFrequence]]"
$customTimerSchedule = "[[DSP_CUSTOM_VariationTimerJobFrequence]]"
$timerJob = "VariationsPropagateListItem"

$timerSchedule = $defaultTimerSchedule

if(![string]::IsNullOrEmpty($customTimerSchedule))
{
	$timerSchedule = $customTimerSchedule
}

Get-SPTimerJob -WebApplication $webApp | where Name -eq $timerJob | Set-SPTimerJob -Schedule $timerSchedule