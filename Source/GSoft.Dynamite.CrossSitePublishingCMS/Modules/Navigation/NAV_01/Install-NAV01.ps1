# ----------------------------------------
# NAV_01: BROWSE INTRANET
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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

$UserStory = "NAV_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =============================== #
# =========   TERMGROUPS   ========== #
# =============================== #

$values = @{"Step: " = "#1 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#2 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script 

# =============================== #
# =========   FIELDS   ========== #
# =============================== #

$values = @{"Step: " = "#1 Setup Fields"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

# =============================== #
# =========   CONTENT TYPES   ========== #
# =============================== #

$values = @{"Step: " = "#2 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script

# =============================== #
# =========   TERM DRIVEN PAGES   ========== #
# =============================== #

$values = @{"Step: " = "#3 Setup Term Driven Pages"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-TermDrivenPages.ps1'
& $Script

# =============================== #
# =====   EVENT RECEIVERS   ===== #
# =============================== #

$values = @{"Step: " = "#4 Setup Event Receivers"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-EventReceivers.ps1'
& $Script

# =============================== #
# ======   RESULT SOURCES  ====== #
# =============================== #

$values = @{"Step: " = "#5 Update Result Sources"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultSources.ps1'
& $Script

# =============================== #
# ===   CATALOG CONNECTIONS   === #
# =============================== #

$values = @{"Step: " = "#6 Create Catalog Connections"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-CatalogConnections.ps1'
& $Script

# ======================================= #
# ===   MANAGED TAXONOMY NAVIGATION  ==== #
# ======================================= #

$values = @{"Step: " = "#7 Setup managed navigation"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedNavigation.ps1'
& $Script

# ********** LOG END ********** #
# Stop log transcript
Stop-Transcript
# ***************************** #