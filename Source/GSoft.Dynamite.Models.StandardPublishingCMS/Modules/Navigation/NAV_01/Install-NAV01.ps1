# ----------------------------------------
# NAV_01: BROWSE INTRANET
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "NAV01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =============================== #
# =========   TERMGROUPS   ========== #
# =============================== #
$values = @{"Step: " = "#1 Export Current Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Export-TermGroups.ps1'
& $Script

$values = @{"Step: " = "#2 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#3 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script 

# =========================================== #
# =========   METADATA NAVIGATION   ========== #
# =========================================== #

$values = @{"Step: " = "#4 Configure taxonomy metadata navigation"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedNavigation.ps1'
& $Script