# ----------------------------------------
# TARGET 02: PROFILE TARGETING
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 - Setup profile targeting"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ProfileTargeting.ps1'
& $Script