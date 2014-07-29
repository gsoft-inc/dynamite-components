# ----------------------------------------------------------------------------
# Copyright		: GSoft @2014
# Project		: GSoft Dynamite Portal
# File          : Uninstall-PortalSolutions.ps1
# Description	: Retracts and removes all of Portal's WSP solution packages
# ----------------------------------------------------------------------------

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

# 1- Retract SharePoint Solutions (Removes all WSPs from farm solutions - and DLLs from GAC)
./Cmdlets/SolutionPackages/Deploy-SPSolutions.ps1 -RemoveOnly

# --------------------------------------------------------------------------


# ------------------------ Log End --------------------------------------
# Stop log transcript
Stop-Transcript
# -----------------------------------------------------------------------