# ----------------------------------------
# TARGET 03: VISUALIZE TARGETED CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =========================================== #
# =========	   RESULT SOURCES	 ============ #
# =========================================== #

$values = @{"Step: " = "#1 - Setup result sources"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
& $Script