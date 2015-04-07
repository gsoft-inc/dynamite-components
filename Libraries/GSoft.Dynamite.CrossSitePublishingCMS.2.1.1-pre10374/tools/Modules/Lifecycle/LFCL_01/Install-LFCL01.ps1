# ----------------------------------------
# LFCL 01 : Control the publishing period of content
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "LFCL_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Web Parts"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-WebParts.ps1'
& $Script