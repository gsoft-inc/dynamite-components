# ----------------------------------------
# TARGET 02: SYNC PROFILE PROPERTIES
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =========================================== #
# =========		 TIMER JOBS		   ========== #
# =========================================== #

$values = @{"Step: " = "#1 - Setup timer jobs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-TimerJobs.ps1'
& $Script