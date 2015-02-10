# -----------------------------------------
#.SYNOPSIS
# Runs when the NuGet package is installed in a project
#
#.DESCRIPTION
# PowerShell script that is executed when the NuGet package is installed on a project.
# Please refer the the NuGet documentation for more information.
# http://docs.nuget.org/create/creating-and-publishing-a-package
#
#.PARAMETER installPath 
# The path to the folder where the package is installed
#
#.PARAMETER toolsPath 
# The path to the tools directory in the folder where the package is installed
#
#.PARAMETER package 
# Reference to the package object.
#
#.PARAMETER project 
# Reference to the EnvDTE project object and represents the project the package is installed into. 
# Note: This will be null in Init.ps1. In that case doesn't have a reference to a particular project because it runs at the solution level. 
# The properties of this object are defined in the MSDN documentation.
# -----------------------------------------

param($installPath, $toolsPath, $package, $project)

$hostname = [System.Net.Dns]::GetHostName()
$hostnameFilename = "Tokens.HOSTNAME.ps1"
$genericTokensFile = $project.ProjectItems | where {$_.Name -like $hostnameFilename}

# Token file
if ($project.ProjectItems | where {$_.Name -like $hostnameFilename.Replace("HOSTNAME", $hostname)}) 
{
    # Remove the HOSTNAME file if the tokens file exist.
    $fullName = $genericTokensFile.Properties.Item("FullPath").Value
    $genericTokensFile.Remove()
    Remove-Item $fullName
}
else 
{
    # Rename the HOSTNAME file if no tokens exists
    $genericTokensFile.Name = $hostnameFilename.Replace("HOSTNAME", $hostname)
}

# Post deployment folder creation in the target project
$moduleFolder = $project.ProjectItems.AddFolder("PostDeployment")