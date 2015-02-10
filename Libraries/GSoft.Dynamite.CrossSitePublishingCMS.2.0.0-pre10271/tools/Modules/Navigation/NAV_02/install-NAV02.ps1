# ----------------------------------------
# NAV_01: VIEW ITEMS RELATED TO A CONTENT
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

param([string]$LogFolderPath)

$UserStory = "NAV_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =============================== #
# =========   TERMGROUPS   ========== #
# =============================== #

#$values = @{"Step: " = "#1 Remove Term Groups"}
#New-HeaderDrawing -Values $Values

#$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
#& $Script 

#$values = @{"Step: " = "#2 Import Term Groups"}
#New-HeaderDrawing -Values $Values

#$Script = $CommandDirectory + '\Import-TermGroups.ps1'
#& $Script 

# =============================== #
# =========   FIELDS   ========== #
# =============================== #

$values = @{"Step: " = "#3 Setup Fields"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script