# ----------------------------------------
# LANG 03: SWITCH DISPLAY LANGUAGE
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "LANG_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-LanguageSwitcher.ps1'
& $Script