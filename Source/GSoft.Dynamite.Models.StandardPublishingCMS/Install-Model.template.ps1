﻿<#
.SYNOPSIS
    Installs the standard publishing CMS model.
    
.DESCRIPTION
    Installs solution packages and modules for this model.

.PARAMETER Force
    Forces the recreation of the site collection.

#>
Param (
        [Parameter(Mandatory=$false)]
        [switch]$Force=$false
)

# ********** PRE-FLIGHT CHECK ********** #
# Unblock files if they're from another computer
Get-ChildItem -Recurse | Unblock-File

# Stop on first error
$ErrorActionPreference = "Stop"

# Solutions deployment check
if (-not (Test-DSPDeployedSolutions -SolutionsConfigurationFilePath "$(Get-Location)\Solutions\Default\Default-Solutions.xml")) { 
    Write-Error -Message "Solutions defined in '.\Solutions\Default\Default-Solutions.xml' are not correctly deployed."
}
if (Test-Path -Path "$(Get-Location)\Solutions\Custom\Custom-Solutions.xml") {
    if (-not (Test-DSPDeployedSolutions -SolutionsConfigurationFilePath "$(Get-Location)\Solutions\Custom\Custom-Solutions.xml")) { 
        Write-Error -Message "Solutions defined in '.\Solutions\Default\Custom-Solutions.xml' are not correctly deployed."
    }
}

# Check if Sharegate is installed
if ((Get-Module | where { $_.Name -eq "Sharegate" }).Count -ne 1) {
    Import-Module Sharegate
    if ($? -eq $false) {
        Write-Error -Message "Sharegate PowerShell module is not correctly installed. Check you $PSModulePath environment variable: it should point to 'C:\Program Files (x86)\Sharegate\'."
    }
}

# TODO: Nice to have a check on which service locator is loaded into the GAC

# ********** START LOGGING ********** #
Start-DSPLogging -commandName "Install-Model" -folder ((Get-Location).Path + "\Logs")
$header = @{"Solution Model: " = "[StandardPublishingCMS]";}
New-HeaderDrawing -Values $header

try {
    #region ********** PUBLISHING MODULE ********** #
    .\Modules\Publishing\PUB_01\Install-PUB01.ps1 -Force $Force
    .\Modules\Publishing\PUB_02\Install-PUB02.ps1
    #endregion

    #region ********** NAVIGATION MODULE ********** #
    .\Modules\Navigation\NAV_01\Install-NAV01.ps1
    .\Modules\Navigation\NAV_05\Install-NAV05.ps1
    #endregion

    #region ********** DESIGN MODULE ********** #
    .\Modules\Design\DSGN_01\Install-DSGN01.ps1
    #endregion

    #region ********** MULTILINGUALISM MODULE ********** #
    # Check Multilingual settings
    $IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
    if($IsMultilingual)
    {
        # Why LANG02 before LANG01?
        .\Modules\Multilingualism\LANG_02\Install-LANG02.ps1
        .\Modules\Multilingualism\LANG_01\Install-LANG01.ps1
        .\Modules\Multilingualism\LANG_03\Install-LANG03.ps1
    }
    #endregion

    #region ********** POST DEPLOYMENT SCRIPTS ********** #
    .\Execute-PostDeploymentScript.ps1
    #endregion
} catch {
    # Output error for logging to catch it
    $_ | Out-String
    throw
} finally {
    # ********** STOP LOGGING ********** #
    Stop-DSPLogging
}