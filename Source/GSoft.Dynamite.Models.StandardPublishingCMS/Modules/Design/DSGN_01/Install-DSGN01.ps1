# ----------------------------------------
# DSGN 01: VIEW ENTERPRISE BRANDING AND DESIGN
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "DSGN01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ==================================== #
# =========   MASTER PAGE   ========== #
# ==================================== #

$values = @{"Step: " = "#1 MasterPage"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MasterPage.ps1'
& $Script

# =============================== #
# =========   THEMES   ========== #
# =============================== #

$values = @{"Step: " = "#2 Theme and Logo"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Theme.ps1'
& $Script

# =================================== #
# =========   HOME PAGES   ========== #
# =================================== #

$values = @{"Step: " = "#3 Home pages"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-HomePages.ps1'
& $Script

# =========================================== #
# =========   Javascript Imports   ========== #
# =========================================== #

$values = @{"Step: " = "#3 Home pages"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-JavascriptImports.ps1'
& $Script