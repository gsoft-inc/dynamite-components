# ----------------------------------------
# TARGET 01: CREATE TARGETABLE CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "TARGET_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =========================================== #
# =========   CATEGORIZE CONTENTS =========== #
# =========================================== #

$values = @{"Step: " = "#1 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#2 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script

# =========================================== #
# ===========   EVENT RECEIVERS   =========== #
# =========================================== #

$values = @{"Step: " = "#3 Setup Event Receivers"}
New-HeaderDrawing -Values $Values
$Script = $CommandDirectory + '\Setup-EventReceivers.ps1'
& $Script