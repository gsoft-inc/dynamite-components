$here = Split-Path -Parent $MyInvocation.MyCommand.Path

# Script under test (sut)
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path).Replace(".Tests.", ".")
$sutFolderPath = "$here\..\..\GSoft.Dynamite.Models.CrossSitePublishingCMS"
$sutPath = "$sutFolderPath\$sut"

$publishDest = "..\..\..\Deployment"
 
Describe "Install-Model.ps1" {

	# Test utility functions

	function New-TokenFile {
        param ($fileName, $contents)

        $tokenFile = $sutFolderPath + "\Tokens." + $fileName + ".ps1"
        New-Item -Path $tokenFile -ItemType file -Value $contents -Force
	}

	function Remove-TokenFile {
        param ($fileName)
        $filter = "Tokens." + $fileName + ".ps1"
		Get-ChildItem -Path $sutFolderPath -Filter $filter | Remove-Item -Force -Recurse
	}

	function Remove-Sut {
		Get-ChildItem -Path $sutPath | Remove-Item -Force -Recurse
	}
}