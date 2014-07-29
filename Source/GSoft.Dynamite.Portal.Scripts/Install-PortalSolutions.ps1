# --------------------------------------------------------------------------
# Copyright		: GSoft @2014
# Project		: GSoft Dynamite Portal
# File          : Install-PortalSolutions.ps1
# Description	: Adds and deploys all of Portal's WSP solution packages
# --------------------------------------------------------------------------

# Verbose preference
$VerbosePreference ="Continue"

# Unblock files if they're from another computer
gci -Recurse | Unblock-File

Update-DSPTokens -UseHostName

# ------------------------ Log Init -------------------------------------
$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)
$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

# Reset log folder
$LogFolder = $CommandDirectory + "\Logs"
if(!(Test-Path -Path $logFolder )){
    New-Item -ItemType directory -Path $LogFolder
}
Get-ChildItem $LogFolder | Foreach-Object { Remove-Item  $_.FullName -Force }

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $CommandDirectory + "\Logs\" +  $ScriptName   +"_Portal_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile
# -----------------------------------------------------------------------


# ------------------------ Script Body -------------------------------------
# 0- Fix acces denied error for content type deployement
./Cmdlets/Util/Fix-AccesDenied.ps1

# 1- Deploy SharePoint Solutions (Deploy all WSPs - and DLLs to GAC)
./CmdLets/SolutionPackages/Deploy-SPSolutions.ps1

# 2- Restart OWSTIMER (otherwise it will continue to use "stale" DLLs from the old GAC state)
Restart-SPTimer
Write-Host "OWSTimer.exe process restarted locally. In a distributed farm environment, don't forget to restart OWSTimer.exe on ALL servers in the farm (all application servers AND web front-ends) before continuing with Portal setup."
# --------------------------------------------------------------------------


# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------