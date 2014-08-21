# Verbose preference
$VerbosePreference ="Continue"

# Unblock files if they're from another computer
gci -Recurse | Unblock-File

Update-DSPTokens -UseHostName

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

./Solutions/Copy-Solutions.ps1

./Solutions/Deploy-Solutions.ps1

# ********** PUBLISHING MODULE ********** #

# ----------------------------------------
# US01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

##### STEP 1: CREATE STRUCTURE

./Modules/Publishing/US01/Setup-Sites.ps1 -Force

$Script = './Modules/Publishing/US01/Setup-Webs.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

##### STEP 2: CATEGORIZE CONTENTS

$Script = './Modules/Publishing/US01/Remove-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = './Modules/Publishing/US01/Import-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = './Modules/Publishing/US01/Setup-ContentTypes.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------