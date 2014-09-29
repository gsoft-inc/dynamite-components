param($installPath, $toolsPath, $package, $project)

$hostname = [System.Net.Dns]::GetHostName()

if (Test-Path $installPath\Tokens.HOSTNAME.ps1 -and Test-Path $installPath\Tokens.HOSTNAME.ps1) {
    Rename-Item $installPath\Tokens.HOSTNAME.ps1 $installPath\Tokens.$hostname.ps1
}