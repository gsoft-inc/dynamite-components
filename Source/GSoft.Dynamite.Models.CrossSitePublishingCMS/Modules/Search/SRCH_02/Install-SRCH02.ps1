# ----------------------------------------
# SRCH_02: GENERATE STATISTICS ABOUT SITE TRAFFIC
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "SRCH_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =============================== #
# =========   PROPERTY BAGS   ========== #
# =============================== #
$Script = $CommandDirectory + '\Setup-PropertyBag.ps1'
& $Script 

# =============================== #
# =========   FEATURES   ========== #
# =============================== #
$Script = $CommandDirectory + '\Setup-Control.ps1'
& $Script