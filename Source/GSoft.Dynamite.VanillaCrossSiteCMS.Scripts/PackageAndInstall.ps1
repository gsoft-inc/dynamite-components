Initialize-DSPTokens -ProjectPath "..\..\" -Force
cd "..\package"
Update-DSPTokens -UseHostName
. "./Install-Model.ps1"