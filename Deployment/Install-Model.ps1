# -----------------------------------------
#.SYNOPSIS
# Installs the cross-site publishing model.
#
# .DESCRIPTION
# -----------------------------------------

# ********** PRE-FLIGHT CHECK ********** #
# Unblock files if they're from another computer
Get-ChildItem -Recurse | Unblock-File


# ********** START LOGGING ********** #
Start-DSPLogging -commandName "Install-Model" -folder ((Get-Location).Path + "\Logs")


# ******** SOLUTIONS DEPLOYMENT ********* #
if ([System.Convert]::ToBoolean("True"))
{
    ./Solutions/Deploy-Solutions.ps1 [[DSP_IsDistributedEnvironment]]
}

$header = @{"Solution Model: " = "[CrossSitePublishingCMS]";}
New-HeaderDrawing -Values $header


# ********** STOP LOGGING ********** #
Stop-DSPLogging
