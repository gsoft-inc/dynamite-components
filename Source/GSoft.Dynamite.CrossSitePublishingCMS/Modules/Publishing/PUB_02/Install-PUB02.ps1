# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------

param([string] $LogFolderPath=".")

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

##### STEP 1: CREATE SEARCH RESULT SOURCES
$Script = $CommandDirectory + '/Setup-ResultSources.ps1 -Force'
Start-Process powershell.exe -ArgumentList $Script -Wait
