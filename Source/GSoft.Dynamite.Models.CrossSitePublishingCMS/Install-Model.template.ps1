# -----------------------------------------
#.SYNOPSIS
# Installs the cross-site publishing model.
#
# .DESCRIPTION
# Installs solution packages and modules for this model.
# -----------------------------------------

# ********** PRE-FLIGHT CHECK ********** #
# Unblock files if they're from another computer
Get-ChildItem -Recurse | Unblock-File

# ********** START LOGGING ********** #
Start-DSPLogging -commandName "Install-Model" -folder ((Get-Location).Path + "\Logs")

# ******** SOLUTIONS DEPLOYMENT ********* #
if ([System.Convert]::ToBoolean("[[DSP_DeploySolutions]]"))
{
    ./Solutions/Deploy-Solutions.ps1 [[DSP_IsDistributedEnvironment]]
}

$header = @{"Solution Model: " = "[CrossSitePublishingCMS]";}
New-HeaderDrawing -Values $header

$scripts = @()
#region ********** PUBLISHING MODULE ********** #
$scripts += @(`
    "\Modules\Publishing\PUB_01\Install-PUB01.ps1",` 
    "\Modules\Publishing\PUB_02\Install-PUB02.ps1",`
    "\Modules\Publishing\PUB_03\Install-PUB03.ps1")
#endregion

#region ********** NAVIGATION MODULE ********** #
$scripts += @(`
    "\Modules\Publishing\NAV_01\Install-NAV01.ps1",` 
    "\Modules\Publishing\NAV_02\Install-NAV02.ps1",`
    "\Modules\Publishing\NAV_05\Install-NAV05.ps1")
#endregion

#region ********** LIFE CYCLE MODULE ********** #
##### LFCL 01
$scripts += @("\Modules\Publishing\LFCL_01\Install-LFCL01.ps1")
#endregion

#region ********** DESIGN MODULE ********** #
##### DSGN 01
$scripts += @("\Modules\Publishing\DSGN_01\Install-DSGN01.ps1")
#endregion

#region ********** MULTILINGUALISM MODULE ********** #
# Check Multilingual settings
$IsMultilingual = [System.Convert]::ToBoolean("[[DSP_IsMultilingual]]")
if($IsMultilingual)
{
    # Why LANG02 before LANG01?
    $scripts += @(`
        "\Modules\Publishing\LANG_02\Install-LANG02.ps1",` 
        "\Modules\Publishing\LANG_01\Install-LANG01.ps1",`
        "\Modules\Publishing\LANG_03\Install-LANG03.ps1")
}
#endregion

#region ********** DOCUMENT MANAGEMENT MODULE ********** #
# Notes: We need to import content after all content types were created

##### DOC 02
$scripts += @("\Modules\Docs\DOC_02\Install-DOC02.ps1")
#endregion

# Install modules in seperate process
$scripts = $scripts | ForEach-Object { $CommandDirectory + $_ }
$scriptBlock = [ScriptBlock]::Create([string]::Join(';', $scripts))
Start-Process PowerShell -ArgumentList $scriptBlock -Wait


#region ********** POST DEPLOYMENT SCRIPTS ********** #
$Script = $CommandDirectory + "/Execute-PostDeploymentScript.ps1"
Start-Process PowerShell -ArgumentList $Script -Wait
#endregion

# ********** STOP LOGGING ********** #
Stop-DSPLogging
