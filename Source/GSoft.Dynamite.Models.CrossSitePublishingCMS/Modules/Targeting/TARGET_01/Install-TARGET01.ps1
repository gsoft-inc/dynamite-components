# ----------------------------------------
# TARGET 01: TARGETABLE CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Content Targeting"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTargeting.ps1'
& $Script
