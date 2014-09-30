# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
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

$UserStory = "PUB_02"

##### STEP 1: CREATE SEARCH RESULT SOURCES
$values = @{"Step: " = "Create Search Result Sources";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
& $Script -Force

##### STEP 2: CREATE PAGE LAYOUTS

$values = @{"Step: " = "Create Page Layouts";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PageLayouts.ps1'
& $Script -Force

##### STEP 3: CREATE PAGE INSTANCES

$values = @{"Step: " = "Create Page Instances";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Pages.ps1'
& $Script -Force

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
# ***************************** #