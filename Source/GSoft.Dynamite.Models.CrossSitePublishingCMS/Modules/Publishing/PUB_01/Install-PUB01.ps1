# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "PUB_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

# =========================================== #
# =========   CREATE STRUCTURE ============== #
# =========================================== #

$values = @{"Step: " = "#1 Setup Sites"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Sites.ps1'
& $Script -Force

$values = @{"Step: " = "#2 Setup Webs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Webs.ps1'
& $Script 

$values = @{"Step: " = "#3 Setup Property Bag Values"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-PropertyBag.ps1'
& $Script 

$values = @{"Step: " = "#5 Setup Permissions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Permissions.ps1'
& $Script

# =========================================== #
# =========   CATEGORIZE CONTENTS =========== #
# =========================================== #

$values = @{"Step: " = "#6 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#6 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#7 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#8 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script 

$values = @{"Step: " = "#9 Setup Event Receivers"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-EventReceivers.ps1'
& $Script 

$values = @{"Step: " = "#10 Setup Catalogs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Catalogs.ps1'
& $Script 
  
$values = @{"Step: " = "#11 Reusable Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ReusableContent.ps1'
& $Script 

# =========================================== #
# =========   METADATA FILTERING   ========== #
# =========================================== #

$values = @{"Step: " = "#11 Configure metadata navigation for catalogs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MetadataFiltering.ps1'
& $Script