# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "PUB01"

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

$values = @{"Step: " = "#2 Setup Permissions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Permissions.ps1'
& $Script

# =========================================== #
# =========   CATEGORIZE CONTENTS =========== #
# =========================================== #

$CurrentNavigationFile = 'Current-NavigationTermGroup.xml'

$values = @{"Step: " = "#3 Export Current Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Export-TermGroups.ps1'
& $Script -CurrentNavigationExportFile $CurrentNavigationFile

$values = @{"Step: " = "#4 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#5 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script -CurrentNavigationImportFile $CurrentNavigationFile

$values = @{"Step: " = "#6 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#7 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script 

$values = @{"Step: " = "#8 Setup Pages Library"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Lists.ps1'
& $Script 

$values = @{"Step: " = "#9 Setup Reusable Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ReusableContent.ps1'
& $Script 

# =========================================== #
# =========   METADATA FILTERING   ========== #
# =========================================== #

$values = @{"Step: " = "#10 Configure metadata navigation for pages librairies"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MetadataFiltering.ps1'
& $Script