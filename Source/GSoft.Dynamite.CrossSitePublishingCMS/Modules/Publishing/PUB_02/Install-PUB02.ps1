# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------

param([string] $LogFolderPath=".")

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

##### STEP 1: CREATE SEARCH RESULT SOURCES
$Script = $CommandDirectory + '/Setup-ResultSources.ps1 -Force'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait 

##### STEP 2: CREATE PAGE LAYOUTS
$Script = $CommandDirectory + '/Setup-PageLayouts.ps1 -Force'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait 

##### STEP 3: CREATE PAGE INSTANCES
$Script = $CommandDirectory + '/Setup-Pages.ps1 -Force'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait 