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

# Verbose preference
$VerbosePreference ="Continue"

$UserStory = "PUB_02"

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# ==================================== #
# =========  PAGE LAYOUTS   ========== #
# ==================================== #

$values = @{"Step: " = "#1 Create Page Layouts"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PageLayouts.ps1'
& $Script -Force

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
# ***************************** #