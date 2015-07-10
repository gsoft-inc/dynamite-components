# ----------------------------------------
# PUB 04: INSERT REUSABLE CONTENTS
# ----------------------------------------
# 

param([string]$LogFolderPath)

$UserStory = "PUB_04"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"Step: " = "#1 Reusable Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ReusableContent.ps1'
& $Script