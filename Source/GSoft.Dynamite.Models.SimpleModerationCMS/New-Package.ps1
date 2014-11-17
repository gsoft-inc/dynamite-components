# New-Package -ModelName SimpleModerationCMS -NugetFolderPath ..\packages -OutputFolderPath ..\package -SolutionFolderPath .. -Override
function New-Package {
	Param (
		# The Model Name ex.: CrossSitePublishingCMS
		[Parameter(Mandatory=$true)]
        [String]$ModelName,
		
		# The relative or full path to the nuget pakages folder
		[Parameter(Mandatory=$true)]
		[ValidateScript({Test-Path $_})]
		[String]$NugetFolderPath,
		
		# The relative or full path to the solution folder
		[Parameter(Mandatory=$true)]
		[ValidateScript({Test-Path $_})]
		[String]$SolutionFolderPath,
		
		# The relative or full path to the folder the created package will be placed
		[Parameter(Mandatory=$true)]
		[String]$OutputFolderPath,
		
		# Override existing package
		[Switch]$Override = $false,
		
		# Use WSP files from the project output release folder
		[switch]$Release = $false
	)
    	
	# Create folder for output if it does not exist	
	if (-not (Test-Path $OutputFolderPath)) {
		New-Item $OutputFolderPath -ItemType directory | Out-Null
	} elseif ($Override) {
        Get-ChildItem -Path $OutputFolderPath -Recurse | Remove-Item -force -recurse
	} else {
		throw "Output folder already exists."
	}
	
	# Construct Full Paths
	$OutputFolderFullPath = Resolve-Path $OutputFolderPath
	$NugetFolderFullPath = Resolve-Path $NugetFolderPath
	$SolutionFolderFullPath = Resolve-Path $SolutionFolderPath
		
	# Tell user where we are working.
	Write-Host "Working with Scripts folder: " -NoNewline
	Write-Host "$(Get-Location)" -ForegroundColor Green
	
	Write-Host "Working with Nuget folder: " -NoNewline
	Write-Host "$NugetFolderFullPath" -ForegroundColor Green
		
	Write-Host "Working with Solution folder: " -NoNewline
	Write-Host "$SolutionFolderFullPath" -ForegroundColor Green
		
	Write-Host "Working with Output folder: " -NoNewline
	Write-Host "$OutputFolderFullPath" -ForegroundColor Green
	
	# Copy Solution WSP Files to output folder
	if ($Release) { $pathFilter = "\\bin\\Release" } else { $pathFilter = "\\bin\\Debug" }
	Get-ChildItem -Path $SolutionFolderFullPath -Include "*.wsp" -Recurse | where { $_.FullName -match $pathFilter } | Copy-Item  -Destination $OutputFolderFullPath
	
	# Get Gsoft-Dynamite.SP
	$dynamiteFolder = Get-ChildItem -Path $NugetFolderFullPath -Recurse -Include "*GSoft.Dynamite.SP*" | where { $_.PSIsContainer } | sort Name | Select-Object -Last 1
	Copy-Item (Join-Path $dynamiteFolder "tools") –Destination $OutputFolderFullPath -Recurse -Container
	Rename-Item (Join-Path $OutputFolderFullPath "tools") "DSP"
	
	# Put all WSP Files in the right spot
	Get-ChildItem $OutputFolderFullPath -Include "*.wsp" -Recurse | Move-Item -Destination {
	    $dir = Join-Path $OutputFolderFullPath "\Solutions\WSP\"
	    $null = mkdir $dir -Force
	    "$dir\$($_.Name)"
	}
	
	# Copy Nuget Package files to output folder for model type
	$cmsFolder = Get-ChildItem -Path $NugetFolderFullPath -Recurse -Include "*$ModelName*" | where { $_.PSIsContainer } | sort Name | Select-Object -Last 1
	Copy-Item (Join-Path $cmsFolder "tools\*") –destination $OutputFolderFullPath -recurse -container -Force
	
	# Copy all files from this location
	Copy-Item (Join-Path (Get-Location) "\*") -Exclude "tools" -Destination $OutputFolderFullPath -Recurse -Container -Force
}