# Deployement folder creation:
# 1) Create an empty deployment artifacts folder
# 2) Take the contents of NuGet package folder for GSoft.Dynamite.Models.CrossSitePublishingCMS
# and copy it all to that destination
# 3) Take the contents of current folder and copy it all to the destination
# 4) Take all WSP solution packages present in /Source/*/bin/ folders
# 5) Take all WSP solutions present in /../Libraries folders

Param (
        [Parameter(Mandatory=$false)]
		[switch]$Force,
		
        [Parameter(Mandatory=$false)]
		[switch]$Release,
		
        [Parameter(Mandatory=$false)]
		[switch]$SetLocationToDestination
	)

$here = Split-Path -Parent $MyInvocation.MyCommand.Path
Write-Host "HERE $here"
$ProjectRootPath = Join-Path $here "..\..\" | Resolve-Path
$DestinationPath = Join-Path $ProjectRootPath "Deployment"
$DefaultDefinitionsPath = Join-Path $ProjectRootPath "*\GSoft.Dynamite.CrossSitePublishingCMS*\tools" | Resolve-Path | Select-Object -first 1
$CustomDefinitionsPath = $here | Resolve-Path

# Force delete all contents of current Deployment folder (and delete the folder itself)
if ($Force -eq $true)
{
    Write-Host "Attempt to clear the following path : $DestinationPath... " -ForegroundColor Yellow -NoNewLine
    Get-ChildItem -Path $DestinationPath -Recurse | Remove-Item -force -recurse
	Remove-Item $DestinationPath
    Write-Host "DONE" -ForeGroundColor Green
}

if (!(Test-Path $DestinationPath)) 
{
	# Create deployment folder
    New-Item -ItemType Directory -Force -Path $DestinationPath | Out-Null
	Write-Host "Created deployment folder at following path : $DestinationPath... " -ForegroundColor Yellow

	# Start by copying the "vanilla" cross-site CMS setup scripts from the NuGet package
	Write-Host "Copying reference setup scripts and configuration from NuGet package (source: $DefaultDefinitionsPath)... " -ForegroundColor Yellow
	Copy-DSPFiles $DefaultDefinitionsPath $DestinationPath

	# Copy most contents of current "Scripts" folder to Deployment folder (powershell scripts, .template files, folder structure, etc.)
	Write-Host "Copying custom scripts and configuration from current folder (source: $CustomDefinitionsPath)... " -ForegroundColor Yellow
	Copy-DSPFiles $CustomDefinitionsPath $DestinationPath

	# Copy all WSP files
	$WspDestinationPath = Join-Path $DestinationPath "Solutions"
	$LibrariesWspFilter = "*`\Libraries`\*"
	$BinWspFilter = "*`\bin`\Debug"

	if ($Release -eq $true)
	{
		$BinWspFilter = "*`\bin`\Release"
	}

	Copy-DSPSolution $ProjectRootPath $WspDestinationPath $LibrariesWspFilter
	Copy-DSPSolution $ProjectRootPath $WspDestinationPath $BinWspFilter

	# Copy DSP PowerShell module so it can be installed on destination server
	$DSPModuleSourcePath = Join-Path $ProjectRootPath "Libraries\GSoft.Dynamite.SP*\tools\" | Resolve-Path | Select-Object -first 1
	$DSPDestinationPath = Join-Path $DestinationPath "DSP"
	Copy-DSPFiles $DSPModuleSourcePath $DSPDestinationPath

	# cd into the Deployment folder if that's what the user asked for
	#if ($SetLocationToDestination -eq $true)
	#{
	#	Set-Location $DestinationPath
	#}

	Write-Host "DONE" -ForeGroundColor Green
}
else
{
	Write-Host "Skipped preparation of deployment contents because $DestinationPath already exists!!!" -ForeGroundColor Red
	Write-Host "Use -Force parameter to clear the folder automatically." 
}




