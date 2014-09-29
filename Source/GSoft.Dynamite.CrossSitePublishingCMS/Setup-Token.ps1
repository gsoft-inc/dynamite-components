$hostname = [System.Net.Dns]::GetHostName()

if (Test-Path ./Tokens.HOSTNAME.ps1 -and Test-Path ./Tokens.HOSTNAME.ps1) {
    Rename-Item Tokens.HOSTNAME.ps1 Tokens.$hostname.ps1
}