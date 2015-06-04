<#
.SYNOPSIS
	Deploys SharePoint solution packages (*.wsp)
	
.DESCRIPTION
	Removes and deploys the default and custom solution packages to the farm based on the
    configuration files defined in the DSP_DEFAULT_PortalSolutionsConfigurationFile and
    DSP_CUSTOM_PortalSolutionsConfigurationFile tokens.
    -----------------------------------------------------------------------
    Copyright	: GSoft @2015
    Model  		: Standard Publishing CMS
    -----------------------------------------------------------------------
    
.PARAMETER RemoveOnly
	Performs only the removal step in the solution deployment.
.PARAMETER Distributed
    Defines in this is a distributed SharePoint farm.
#>
param([switch] $RemoveOnly=$false, [switch] $Distributed=$false)

$0 = $myInvocation.MyCommand.Definition
$CommandDirectory = [System.IO.Path]::GetDirectoryName($0)

$DefaultConfigurationFile = "[[DSP_DEFAULT_PortalSolutionsConfigurationFile]]"
$CustomConfigurationFile = "[[DSP_CUSTOM_PortalSolutionsConfigurationFile]]"

$ConfigurationFilePath = $CommandDirectory + ".\" + $DefaultConfigurationFile
$xmlInput = Get-Content $ConfigurationFilePath

Deploy-DSPSolution -Config $xmlInput -RemoveOnly:$RemoveOnly

if(![string]::IsNullOrEmpty($CustomConfigurationFile))
{
	$ConfigurationFilePath = $CommandDirectory + ".\" + $CustomConfigurationFile
	$xmlInput = Get-Content $ConfigurationFilePath
	Deploy-DSPSolution -Config $xmlInput -RemoveOnly:$RemoveOnly
}

if($Distributed)
{
	Read-Host "Please restart the OWSTIMER.exe process an all SharePoint servers (APP and WFE) before continue. Press enter when its done..."
}
else
{
	Restart-SPTimer
	Write-Warning "OWSTimer.exe process restarted locally."
}