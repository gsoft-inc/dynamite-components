# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "PUB_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

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

$values = @{"Step: " = "Configure pages libraries"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Lists.ps1'
& $Script

##### STEP 3: CREATE PAGE INSTANCES

$values = @{"Step: " = "Create Page Instances";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Pages.ps1'
& $Script -Force

##### STEP 4: CREATE DISPLAY TEMPLATES

$values = @{"Step: " = "Create Display Templates";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-DisplayTemplates.ps1'
& $Script

##### STEP 5: CREATE SEARCH RESULT TYPES

$values = @{"Step: " = "Create Result Types";"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ResultTypes.ps1'
& $Script