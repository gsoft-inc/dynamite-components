# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------
# 
param([string]$LogFolderPath,[bool]$Force=$false)

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
if($Force)
{
	& $Script -Force
}
else
{
	& $Script
} 

$values = @{"Step: " = "#2 Setup Webs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Webs.ps1'
if($Force)
{
	& $Script -Force
}
else
{
	& $Script
} 

$values = @{"Step: " = "#3 Setup Permissions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Permissions.ps1'
& $Script

# =========================================== #
# =========   CATEGORIZE CONTENTS =========== #
# =========================================== #

$CurrentNavigationFile = 'Current-NavigationTermGroup.xml'

$values = @{"Step: " = "#4 Export Current Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Export-TermGroups.ps1'
& $Script -CurrentNavigationExportFile $CurrentNavigationFile

$values = @{"Step: " = "#5 Remove Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Remove-TermGroups.ps1'
& $Script 

$values = @{"Step: " = "#6 Import Term Groups"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Import-TermGroups.ps1'
& $Script -CurrentNavigationImportFile $CurrentNavigationFile

$values = @{"Step: " = "#7 Setup Columns"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script

$values = @{"Step: " = "#8 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script 

$values = @{"Step: " = "#9 Setup Pages Library"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Lists.ps1'
& $Script 

$values = @{"Step: " = "#10 Setup Reusable Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ReusableContent.ps1'
& $Script 

# =========================================== #
# =========   METADATA FILTERING   ========== #
# =========================================== #

$values = @{"Step: " = "#11 Configure metadata navigation for pages librairies"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MetadataFiltering.ps1'
& $Script