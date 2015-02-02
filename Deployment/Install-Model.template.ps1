# -----------------------------------------
#.SYNOPSIS
# Installs the cross-site publishing model.
#
# .DESCRIPTION
# Installs solution packages and modules for this model.
# -----------------------------------------

# ********** PRE-FLIGHT CHECK ********** #
# Unblock files if they're from another computer
Get-ChildItem -Recurse | Unblock-File

# ********** START LOGGING ********** #
Start-DSPLogging -commandName "Install-Model" -folder ((Get-Location).Path + "\Logs")

# ******** SOLUTIONS DEPLOYMENT ********* #
if ([System.Convert]::ToBoolean("[[DSP_DeploySolutions]]"))
{
    ./Solutions/Deploy-Solutions.ps1 [[DSP_IsDistributedEnvironment]]
}

$header = @{"Solution Model: " = "[CrossSitePublishingCMS]";}
New-HeaderDrawing -Values $header

#region ********** PUBLISHING MODULE ********** #
##### PUB 01
$Script = $CommandDirectory + "\Modules\Publishing\PUB_01\Install-PUB01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### PUB 02
$Script = $CommandDirectory + "\Modules\Publishing\PUB_02\Install-PUB02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### PUB 03
$Script = $CommandDirectory + "\Modules\Publishing\PUB_03\Install-PUB03.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

#region ********** NAVIGATION MODULE ********** #
##### NAV 01
$Script = $CommandDirectory + "\Modules\Navigation\NAV_01\Install-NAV01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### NAV 02
$Script = $CommandDirectory + "\Modules\Navigation\NAV_02\Install-NAV02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### NAV 05
$Script = $CommandDirectory + "\Modules\Navigation\NAV_05\Install-NAV05.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

#region ********** LIFE CYCLE MODULE ********** #
##### LFCL 01
$Script = $CommandDirectory + "\Modules\LifeCycle\LFCL_01\Install-LFCL01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

#region ********** DESIGN MODULE ********** #
##### DSGN 01
$Script = $CommandDirectory + "\Modules\Design\DSGN_01\Install-DSGN01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

#region ********** MULTILINGUALISM MODULE ********** #
# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")

if($IsMultilingual)
{
	##### LANG 02
	$Script = $CommandDirectory + "\Modules\Multilingualism\LANG_02\Install-LANG02.ps1"
	Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

	##### LANG 01
	$Script = $CommandDirectory + "\Modules\Multilingualism\LANG_01\Install-LANG01.ps1"
	Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

	##### LANG 03
	$Script = $CommandDirectory + "\Modules\Multilingualism\LANG_03\Install-LANG03.ps1"
	Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
}
#endregion

#region ********** DOCUMENT MANAGEMENT MODULE ********** #
# Notes: We need to import content after all content types were created

##### DOC 02
$Script = $CommandDirectory + "\Modules\Docs\DOC_02\Install-DOC02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

#region ********** POST DEPLOYMENT SCRIPTS ********** #
$Script = $CommandDirectory + "/Execute-PostDeploymentScript.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait
#endregion

# ********** STOP LOGGING ********** #
Stop-DSPLogging
