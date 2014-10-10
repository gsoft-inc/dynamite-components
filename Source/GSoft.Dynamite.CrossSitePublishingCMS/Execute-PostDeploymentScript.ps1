# -----------------------------------------
# Custom Script
#
# This function gets all the scripts in the PostDeployment folder and executes them one by one
# -----------------------------------------

# Get all files in the PostDeployment folder
Get-ChildItem PostDeployment/* -include *.ps1 | ForEach-Object {
Write-Host "Executes the script $_" -ForegroundColor Yellow
Start-Process powershell.exe -ArgumentList "-file `"$_`"" -Wait -Verbose
}