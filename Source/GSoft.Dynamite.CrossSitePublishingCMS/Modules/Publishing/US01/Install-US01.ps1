# ----------------------------------------
# US01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

param([string] $LogFolderPath)

##### STEP 1: CREATE STRUCTURE

./Modules/Publishing/US01/Setup-Sites.ps1 -Force

$Script = './Modules/Publishing/US01/Setup-Webs.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

##### STEP 2: CATEGORIZE CONTENTS

$Script = './Modules/Publishing/US01/Remove-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = './Modules/Publishing/US01/Import-TermGroups.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = './Modules/Publishing/US01/Setup-Fields.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait

$Script = './Modules/Publishing/US01/Setup-ContentTypes.ps1'
Start-Process powershell.exe -ArgumentList $Script, $LogFolderPath -Wait