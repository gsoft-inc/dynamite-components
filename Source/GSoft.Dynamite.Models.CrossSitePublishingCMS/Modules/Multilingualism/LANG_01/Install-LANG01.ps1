# ----------------------------------------
# LANG 01: VIEW MULTILINGUAL CONTENT
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

param([string]$LogFolderPath)

$UserStory = "LANG_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Fields"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#2 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script

$values = @{"Step: " = "#3 Setup Event Receivers"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-EventReceivers.ps1'
& $Script

$values = @{"Step: " = "#4 Create catalogs connections"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-CatalogConnections.ps1'
& $Script

$values = @{"Step: " = "#5 Setup Result Sources"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
& $Script