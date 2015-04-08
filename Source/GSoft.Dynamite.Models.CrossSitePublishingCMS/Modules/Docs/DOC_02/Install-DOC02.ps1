﻿# ----------------------------------------
# DOC 02: IMPORT CONTENT
# ----------------------------------------

param([string]$LogFolderPath)

$UserStory = "DOC_02"

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$values = @{"User Story: " = $UserStory}
New-HeaderDrawing -Values $Values

$values = @{"Step: " = "#1 Setup Fields"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Fields.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#2 Setup Content Types"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ContentTypes.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#3 Setup webs"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Webs.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#4 Setup documents libraries"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-DocLibraries.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#3 Setup Content"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-Content.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#4 Setup Search Managed Properties"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedProperties.ps1'
& $Script $LogFolderPath