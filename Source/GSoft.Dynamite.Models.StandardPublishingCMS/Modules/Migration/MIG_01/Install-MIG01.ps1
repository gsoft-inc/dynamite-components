﻿# ----------------------------------------
# MIG 01: IMPORT CONTENT
# ----------------------------------------

[CmdletBinding(DefaultParameterSetName="ExcelRepository")]

Param
(
    [Parameter(Mandatory=$false)]
    [string]$LogFolderPath,

    [Parameter(Mandatory=$false)]
    [Parameter(ParameterSetName = "ExcelRepository")]
    [switch]$FromExcel=$true,

    [Parameter(Mandatory=$false)]
    [Parameter(ParameterSetName = "SiteRepository")]
    [switch]$FromSite,

    [Parameter(Mandatory=$false)]
    [switch]$ImportSource,

    [Parameter(Mandatory=$false)]
    [switch]$ImportTargets,

    [switch]$SkipSearchConfig
)

$UserStory = "MIG01"

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

$values = @{"Step: " = "#3 Setup Content"}
New-HeaderDrawing -Values $Values

if ($FromExcel.IsPresent)
{
    $Script = $CommandDirectory + '\Setup-Content.ps1'
    Invoke-Expression "& `"$Script`" -FromExcel -ImportSource:`$$ImportSource  -ImportTargets:`$$ImportTargets"
}

if ($FromSite.IsPresent)
{
    $Script = $CommandDirectory + '\Setup-Content.ps1'
    Invoke-Expression "& `"$Script`" -FromSite -ImportSource:`$$ImportSource  -ImportTargets:`$$ImportTargets"
}

$values = @{"Step: " = "#4 Setup Search Managed Properties"}
New-HeaderDrawing -Values $Values

if (-not $SkipSearchConfig) {
    $Script = $CommandDirectory + '\Setup-ManagedProperties.ps1'
    & $Script $LogFolderPath
} else {
    Write-Warning "Skipped search config & crawls..."
}
