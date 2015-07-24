# ----------------------------------------
# MIG 01: IMPORT CONTENT
# ----------------------------------------

Param
(
    [string]$LogFolderPath,

    [Parameter(Mandatory=$false, ParameterSetName = "ExcelRepository")]
    [switch]$FromExcel,

    [Parameter(Mandatory=$false, ParameterSetName = "SiteRepository")]
    [switch]$FromSite
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
    Invoke-Expression "& `"$Script`" -FromExcel"
}

if ($FromSite.IsPresent)
{
    $Script = $CommandDirectory + '\Setup-Content.ps1'
    Invoke-Expression "& `"$Script`" -FromSite"
}

$values = @{"Step: " = "#4 Fix Welcome Pages (to avoid conflicts between web URLs and taxonomy friendly URLs)"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-WelcomePages.ps1'
& $Script $LogFolderPath

$values = @{"Step: " = "#5 Setup Search Managed Properties"}
New-HeaderDrawing -Values $Values

$Script = $CommandDirectory + '\Setup-ManagedProperties.ps1'
& $Script $LogFolderPath