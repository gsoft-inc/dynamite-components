Initialize-DSPTokens -ProjectPath "..\..\" -Force -Demo
cd "..\package"

# Build Package Path
#$packagePath = Join-Path (Get-Location).ToString() "../package"

# Make Path if not exist
#$packageDirectory = New-Item -ItemType Directory -Force -Path $packagePath

# Update Tokens and shit in that path
#Update-DSPTokens -PackagePath $packageDirectory.FullName

Update-DSPTokens -UseHostName

. "./Install-Model.ps1"
