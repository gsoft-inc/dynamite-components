﻿# Verbose preference
$VerbosePreference ="Continue"

# Unblock files if they're from another computer
gci -Recurse | Unblock-File

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

# ********** LOG INIT ********** #

$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

$LogFolderPath = ((Get-Location).Path + "\Logs")

if(!(Test-Path -Path $LogFolderPath)){
	New-Item -ItemType directory -Path $LogFolderPath
}
else
{
	# Reset the log folder
	Get-ChildItem $LogFolderPath | Foreach-Object { Remove-Item  $_.FullName -Force }
}

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $LogFolderPath + "\" + $ScriptName +"_Dynamite_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile

# ******** SOLUTIONS DEPLOYMENT ********* #

#./Solutions/Copy-Solutions.ps1

if ([System.Convert]::ToBoolean("True"))
{
    ./Solutions/Deploy-Solutions.ps1 [[DSP_IsDistributedEnvironment]]
}

$values = @{"Solution Model: " = "[CrossSitePublishingCMS]";}
New-HeaderDrawing -Values $Values

# ********** PUBLISHING MODULE ********** #

##### PUB 01
$Script = $CommandDirectory + "\Modules\Publishing\PUB_01\Install-PUB01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### PUB 02
$Script = $CommandDirectory + "\Modules\Publishing\PUB_02\Install-PUB02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### PUB 03
$Script = $CommandDirectory + "\Modules\Publishing\PUB_03\Install-PUB03.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** NAVIGATION MODULE ********** #

##### NAV 01
$Script = $CommandDirectory + "\Modules\Navigation\NAV_01\Install-NAV01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### NAV 02
$Script = $CommandDirectory + "\Modules\Navigation\NAV_02\Install-NAV02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

##### NAV 05
$Script = $CommandDirectory + "\Modules\Navigation\NAV_05\Install-NAV05.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** LIFE CYCLE MODULE ********** #

##### LFCL 01
$Script = $CommandDirectory + "\Modules\LifeCycle\LFCL_01\Install-LFCL01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** DESIGN MODULE ********** #

##### DSGN 01
$Script = $CommandDirectory + "\Modules\Design\DSGN_01\Install-DSGN01.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** MULTILINGUALISM MODULE ********** #

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

# ********** DOCUMENT MANAGEMENT MODULE ********** #
# Notes: We need to import content after all content types were created

##### DOC 02
$Script = $CommandDirectory + "\Modules\Docs\DOC_02\Install-DOC02.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** POST DEPLOYMENT SCRIPTS ********** #
$Script = $CommandDirectory + "/Execute-PostDeploymentScript.ps1"
Start-Process PowerShell -ArgumentList $Script, $LogFolderPath -Wait

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
