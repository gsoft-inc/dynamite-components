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

# Modules Folders
# $moduleFolder = $project.ProjectItems.AddFolder("Modules")