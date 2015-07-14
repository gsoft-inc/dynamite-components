# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------
param([string]$LogFolderPath)

$UserStory = "PUB02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ============================================= #
# =========  SEARCH RESULT SOURCES   ========== #
# ============================================= #
$values = @{"Step: " = "#1 Create Search Result Sources";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
& $Script -Force

# ==================================== #
# =========  PAGE LAYOUTS   ========== #
# ==================================== #

$values = @{"Step: " = "#2 Create Page Layouts"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PageLayouts.ps1'
& $Script -Force