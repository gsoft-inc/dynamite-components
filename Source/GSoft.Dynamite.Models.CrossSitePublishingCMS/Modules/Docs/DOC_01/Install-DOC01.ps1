# ----------------------------------------
# DOC 01: ADD MEDIA CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "DOC_01"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Blob Cache Configuration"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-BlobCache.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#2 Setup Image Renditions"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ImageRenditions.ps1'
& $Script $LogFolderPath