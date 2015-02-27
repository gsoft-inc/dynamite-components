# ------------------------------------------------------------------------------
# Custom Script
#
# This script adjusts the Variations Propagate List Items timer job to 5 minutes
# ------------------------------------------------------------------------------

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