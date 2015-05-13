# ----------------------------------------
# LANG 01: VIEW MULTILINGUAL CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "LANG_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Adjust variations timer job schedule"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Adjust-VariationsTimerJob.ps1'
& $Script