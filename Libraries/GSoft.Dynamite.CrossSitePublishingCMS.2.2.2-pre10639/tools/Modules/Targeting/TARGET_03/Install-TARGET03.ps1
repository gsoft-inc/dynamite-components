# ----------------------------------------
# TARGET 03: SEARCH TARGETING
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 - Setup search targeting"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-SearchTargeting.ps1'
& $Script