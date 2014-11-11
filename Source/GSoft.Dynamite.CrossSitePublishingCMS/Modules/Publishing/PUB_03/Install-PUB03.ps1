# ----------------------------------------
# PUB 03: VIEW ITEM DETAILS
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

$UserStory = "PUB_03"

$values = @{"Step: " = "Deploy Web Parts";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-WebParts.ps1'
& $Script -Force

$values = @{"Step: " = "Create template pages";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Pages.ps1'
& $Script -Force

$values = @{"Step: " = "Setup faceted navigation";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-FacetedNavigation.ps1'
& $Script -Force

Setup-FacetedNavigation.ps1

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
# ***************************** #