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

#./Solutions/Deploy-Solutions.ps1

# ********** PUBLISHING MODULE ********** #

##### US 01
./Modules/Publishing/US01/Install-US01.ps1 $LogFolderPath

# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------