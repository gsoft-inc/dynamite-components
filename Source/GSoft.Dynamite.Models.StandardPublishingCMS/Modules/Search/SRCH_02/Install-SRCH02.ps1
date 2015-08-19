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

$values = @{"Step: " = "#1 Setup Property Bags"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PropertyBag.ps1'
& $Script 

# =============================== #
# =========   FEATURES   ========== #
# =============================== #

$values = @{"Step: " = "#2 Enable the feature"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Control.ps1'
& $Script

# =============================== #
# =======   CRAW RULES   ======== #
# =============================== #

$values = @{"Step: " = "#3 Set Craw Rules"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-CrawlRules.ps1'
& $Script
