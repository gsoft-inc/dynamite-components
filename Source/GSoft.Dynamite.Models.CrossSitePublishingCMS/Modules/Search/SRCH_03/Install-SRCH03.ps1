﻿# ----------------------------------------
# SRCH_03: OPTIMIZING THE SITE FOR THE SEARCH ENGINE OPTIMIZATION
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "SRCH_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =============================== #
# =========   Fields    ========== #
# =============================== #

$values = @{"Step: " = "#1 Setup Fields"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script 

# =============================== #
# =========   Content Types   ========== #
# =============================== #

$values = @{"Step: " = "#2 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script