# ----------------------------------------
# SRCH_03: OPTIMIZING THE SITE FOR THE SEARCH ENGINE OPTIMIZATION
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "SRCH_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ========================================= #
# =========   Social MetaTag Control   ========== #
# ======================================= #

$values = @{"Step: " = "#1 Enable Social MetaTag Additional control"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-SocialMetaTags.ps1'
& $Script