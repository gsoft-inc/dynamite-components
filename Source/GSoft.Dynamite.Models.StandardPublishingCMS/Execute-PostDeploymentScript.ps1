# -----------------------------------------
# Custom Script
#
# This function gets all the scripts in the PostDeployment folder and executes them one by one
# -----------------------------------------

# If the path exists
if (Test-Path PostDeployment) {
	# Defines the post deployment script steps. (the custom scripts in the PostDeployement folder)

	# Executes all scripts in this folder (excluding template files)
	Get-ChildItem PostDeployment -Exclude ("*.template", "*.template.*") | Where-Object { $_.Extension -eq ".ps1" } | Foreach-Object { Invoke-Expression $_.FullName }
}