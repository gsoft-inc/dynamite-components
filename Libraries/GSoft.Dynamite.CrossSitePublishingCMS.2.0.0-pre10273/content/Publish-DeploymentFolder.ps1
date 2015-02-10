# -----------------------------------------
#.SYNOPSIS
# Deployment folder creation for Dynamite components module.
#
# .DESCRIPTION
# 1)	Create an empty deployment artifacts folder
# 2)	Take the contents of NuGet package folder for GSoft.Dynamite.Models.CrossSitePublishingCMS
#		and copy it all to that destination
# 3)	Take the contents of current folder and copy it all to the destination
# 4)	Take all WSP solution packages present in /Source/*/bin/ folders
# 5)	Take all WSP solutions present in /../Libraries folders
#
#.PARAMETER Force
# Forces the deletion of the current Deployment folder and all it's contents (and the folder itself)
#
#.PARAMETER Release
# Fetches the solution packages (wsp) from the release folder
#
#.PARAMETER SetLocationToDestination
# Sets the current directory to the destination deployment folder after it's been created
# -----------------------------------------

Param (
        [Parameter(Mandatory=$false)]
		[switch]$Force,
		
        [Parameter(Mandatory=$false)]
		[switch]$Release,
		
        [Parameter(Mandatory=$false)]
		[switch]$SetLocationToDestination
	)

# Build paths
$CurrentPath = Split-Path -Parent $MyInvocation.MyCommand.Path
$ProjectRootPath = Join-Path $CurrentPath "..\..\" | Resolve-Path
$DestinationPath = Join-Path $ProjectRootPath "Deployment"
$DefaultDefinitionsPath = Join-Path $ProjectRootPath "*\GSoft.Dynamite.CrossSitePublishingCMS*\tools" | Resolve-Path | Select-Object -first 1
$CustomDefinitionsPath = $CurrentPath | Resolve-Path

# Force delete all contents of current Deployment folder (and delete the folder itself)
if ($Force -eq $true)
{
	if (Test-Path $DestinationPath) {
		Write-Warning "Clearing the following path : $DestinationPath... "
		Get-ChildItem -Path $DestinationPath -Recurse | Remove-Item -force -recurse
		if (Test-Path -Path $DestinationPath) {
			Remove-Item $DestinationPath
		}
	}
}

if (-not (Test-Path $DestinationPath)) 
{
	# Create deployment folder
    New-Item -ItemType Directory -Force -Path $DestinationPath | Out-Null
	Write-Verbose "Created deployment folder at following path : $DestinationPath... "

	# Start by copying the "vanilla" cross-site CMS setup scripts from the NuGet package
    # Note: Exclude the NuGet's install script
	Write-Verbose "Copying reference setup scripts and configuration from NuGet package (source: $DefaultDefinitionsPath)... "
	Copy-DSPFiles $DefaultDefinitionsPath $DestinationPath -Match @("*.ps1","*.template.*","*.xlsx","*.jpg","*.jpeg","*.png","*.sgt", "README*", "*.psd1", "*.psm1") -Exclude "Install.ps1"

	# Copy most contents of current "Scripts" folder to Deployment folder (powershell scripts, .template files, folder structure, etc.)
	Write-Verbose "Copying custom scripts and configuration from current folder (source: $CustomDefinitionsPath)... "
	Copy-DSPFiles $CustomDefinitionsPath $DestinationPath

	# Copy all WSP files
	$WspDestinationPath = Join-Path $DestinationPath "Solutions"
	$LibrariesWspFilter = "*`\Libraries`\*"
	$BinWspFilter = "*`\bin`\Debug"

	if ($Release -eq $true)
	{
		$BinWspFilter = "*`\bin`\Release"
	}

	Copy-DSPSolutions $ProjectRootPath $WspDestinationPath $LibrariesWspFilter
	Copy-DSPSolutions $ProjectRootPath $WspDestinationPath $BinWspFilter

	# Copy DSP PowerShell module so it can be installed on destination server
	$DSPModuleSourcePath = Join-Path $ProjectRootPath "Libraries\GSoft.Dynamite.SP*\tools\" | Resolve-Path | Select-Object -first 1
	$DSPDestinationPath = Join-Path $DestinationPath "DSP"
	Copy-DSPFiles $DSPModuleSourcePath $DSPDestinationPath

	# Change directory into the Deployment folder if that's what the user asked for
	if ($SetLocationToDestination -eq $true)
	{
		Set-Location $DestinationPath
	}
}
else
{
	Write-Warning "Skipped preparation of deployment contents because $DestinationPath already exists!!!"
	Write-Verbose "Use -Force parameter to clear the folder automatically." 
}