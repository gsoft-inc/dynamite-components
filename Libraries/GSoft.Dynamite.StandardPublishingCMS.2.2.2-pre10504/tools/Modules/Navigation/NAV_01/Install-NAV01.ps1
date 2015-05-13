# ----------------------------------------
# NAV_01: BROWSE INTRANET
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "NAV01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =========================================== #
# =========   METADATA NAVIGATION   ========== #
# =========================================== #

$values = @{"Step: " = "#3 Configure taxonomy metadata navigation"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedNavigation.ps1'
& $Script