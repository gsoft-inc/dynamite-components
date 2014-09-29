param($installPath, $toolsPath, $package, $project)

$hostname = [System.Net.Dns]::GetHostName()

New-Item .\log.txt -type file
Add-Content .\log.txt $hostname
Add-Content .\log.txt $installPath
Add-Content .\log.txt $toolsPath
Add-Content .\log.txt $package
Add-Content .\log.txt $project

if (Test-Path $installPath\Tokens.HOSTNAME.ps1 -and Test-Path $installPath\Tokens.HOSTNAME.ps1) {
    Rename-Item $installPath\Tokens.HOSTNAME.ps1 $installPath\Tokens.$hostname.ps1
}