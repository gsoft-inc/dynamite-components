# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

param([string]$LogFolderPath)

# ********** LOG INIT ********** #

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

if ([string]::IsNullOrEmpty($LogFolderPath))
{
	$LogFolderPath = $CommandDirectory
}


$ScriptName = [System.IO.Path]::GetFileNameWithoutExtension($MyInvocation.MyCommand.Name)

$LogTime = Get-Date -Format "MM-dd-yyyy_hh-mm-ss"
$LogFile = $LogFolderPath + "\" + $ScriptName +"_Dynamite_"+$LogTime +".log"

# Stat log transcript
Start-Transcript -Path $LogFile

# ***************************** #

# Verbose preference
$VerbosePreference ="Continue"

$UserStory = "PUB_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

##### STEP 1: CREATE STRUCTURE

$values = @{"Step: " = "#1 Setup Sites"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Sites.ps1'
& $Script -Force 

$values = @{"Step: " = "#2 Setup Permissions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Permissions.ps1'
& $Script

##### STEP 2: CATEGORIZE CONTENTS

$values = @{"Step: " = "#3 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#4 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#5 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#6 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script 

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
# ***************************** #