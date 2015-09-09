# ----------------------------------------
# PUB 04: INSERT REUSABLE CONTENTS
# ----------------------------------------
# 
param([string]$LogFolderPath,[bool]$Force=$false,[bool]$IgnoreWebs=$false)

$UserStory = "PUB04"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Reusable Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ReusableContent.ps1'
& $Script