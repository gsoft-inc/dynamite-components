# ----------------------------------------
# PUB 03: VIEW ITEM DETAILS
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "PUB_03"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"Step: " = "Deploy Language Files";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-LanguageFiles.ps1'
& $Script -Force

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