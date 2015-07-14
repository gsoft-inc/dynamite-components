# ----------------------------------------
# DSGN 01: VIEW ENTERPRISE BRANDING AND DESIGN
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "DSGN_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 MasterPage"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-MasterPage.ps1'
& $Script

$values = @{"Step: " = "#2 Theme and Logo"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Theme.ps1'
& $Script

$values = @{"Step: " = "#3 Home pages"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-HomePages.ps1'
& $Script