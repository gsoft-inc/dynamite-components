# ----------------------------------------
# SOCIAL 01: DISCUSSIONS
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "SOCIAL_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Discussion Lists"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Lists.ps1'
& $Script
