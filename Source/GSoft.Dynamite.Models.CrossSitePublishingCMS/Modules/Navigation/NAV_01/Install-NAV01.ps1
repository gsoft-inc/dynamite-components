# ----------------------------------------
# NAV_01: BROWSE INTRANET
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

param([string]$LogFolderPath)

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

# ==================== #
# ===   CATALOGS   === #
# ==================== #

$values = @{"Step: " = "#6 Setup Catalogs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Catalogs.ps1'
& $Script 

# =============================== #
# ===   CATALOG CONNECTIONS   === #
# =============================== #

$values = @{"Step: " = "#7 Create Catalog Connections"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-CatalogConnections.ps1'
& $Script

# ======================================= #
# ===   MANAGED TAXONOMY NAVIGATION  ==== #
# ======================================= #

$values = @{"Step: " = "#8 Setup managed navigation"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedNavigation.ps1'
& $Script

# ======================================= #
# =========   GLOBAL NAVIGATION  ======== #
# ======================================= #

$values = @{"Step: " = "#9 Setup global navigation control"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Controls.ps1'
& $Script