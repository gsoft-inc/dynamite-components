# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------
param([string]$LogFolderPath)

$UserStory = "PUB_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ==================================== #
# =========  PAGE LAYOUTS   ========== #
# ==================================== #

$values = @{"Step: " = "#1 Create Page Layouts"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PageLayouts.ps1'
& $Script -Force