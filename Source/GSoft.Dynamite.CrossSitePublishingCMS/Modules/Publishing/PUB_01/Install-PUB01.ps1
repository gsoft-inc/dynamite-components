# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

param([string] $LogFolderPath=".")

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

##### STEP 1: CREATE STRUCTURE
$Script = $CommandDirectory + '/Setup-Sites.ps1 -Force'
Start-Process powershell.exe -ArgumentList $Script -Wait -NoNewWindow

$Script = $CommandDirectory + '/Setup-Webs.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

##### STEP 2: CATEGORIZE CONTENTS

$Script = $CommandDirectory + '/Remove-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = $CommandDirectory + '/Import-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = $CommandDirectory + '/Setup-Fields.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = $CommandDirectory + '/Setup-ContentTypes.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = $CommandDirectory + '/Setup-Catalogs.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = $CommandDirectory + '/Setup-Permissions.ps1'
Start-Process powershell.exe -ArgumentList $Script -Wait -NoNewWindow

