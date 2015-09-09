# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Standard Publishing CMS
# File          : Setup-ListSync.ps1.template
# Description	: Configure variations connection between source and target lists
# -----------------------------------------------------------------------

Write-Warning "Applying Lists Synchronization..."

# Activate features on source sites (if the solution is multilingual).
[[DSP_AuthoringSourceRootWebUrls]] | Foreach-Object{

	Initialize-DSPFeature -Url $_ -Id "[[DSP_CommonCMS_LANG_SyncLists]]"
}
