# Build Deployment package
New-Package -ModelName "SimpleModerationCMS" -NugetFolderPath "..\packages" -OutputFolderPath "..\package" -SolutionFolderPath ".." -Override

# Go to package directory
cd "..\package"

# Update the token files
Update-DSPTokens -UseHostName

# Install the Solution
. "./Install-Model.ps1"