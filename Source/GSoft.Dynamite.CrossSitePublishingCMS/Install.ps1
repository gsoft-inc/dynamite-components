param($installPath, $toolsPath, $package, $project)

$hostname = [System.Net.Dns]::GetHostName()

New-Item .\log.txt -type file
Add-Content .\log.txt (Get-Location)

$hostnameFilename = "Tokens.HOSTNAME.ps1"

$tokensFile = $project.ProjectItems | where {$_.Name -like $hostnameFilename}
$tokensFile.Name = $hostnameFilename.Replace("HOSTNAME", $hostname)

#if (Test-Path .\Tokens.HOSTNAME.ps1 -and Test-Path .\Tokens.HOSTNAME.ps1) {
#    Rename-Item .\Tokens.HOSTNAME.ps1 .\Tokens.$hostname.ps1
#}