$currentFolderPath = Split-Path -Parent $MyInvocation.MyCommand.Path

# Script under test (sut)
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path).Replace(".Tests.", ".")
$sutFolderPath = "$currentFolderPath\..\..\GSoft.Dynamite.VanillaCrossSiteCMS.Scripts"
$publishDeploymentScriptPath = "$sutFolderPath\Publish-DeploymentFolder.ps1"
$deploymentFolderPath = "$currentFolderPath..\..\..\Deployment"
$sutPath = "$currentFolderPath\..\..\..\Deployment\Solutions\Deploy-Solutions.ps1"
 
Describe "Deploy-Solutions.ps1" {

	#region Test utility functions
	function Remove-DeploymentFolder {
		if (Test-Path $deploymentFolderPath) {
			Get-ChildItem -Path $deploymentFolderPath -Recurse | Remove-Item -Force -Recurse
			Remove-Item $deploymentFolderPath
		}
	}
    #endregion

	Context "When only default solutions" {
	
		BeforeEach {
            Invoke-Expression "$publishDeploymentScriptPath  -Force -SetLocationToDestination"
            Update-DSPTokens
		}

		AfterEach {
            Remove-DeploymentFolder
            Set-Location $currentFolderPath
		}

		It "should deploy all default solutions to SharePoint farm" {
            # Arrange
            [xml]$solutionsXml = Get-Content ".\Solutions\Default\Default-Solutions.xml"
            $expectedSolutionNames = $solutionsXml.SelectNodes("//Solution") | ForEach-Object { $_.Path.Replace("Solutions\", [string]::Empty) }

            # Act
			& $sutPath
            $actualSolutionNames = Get-SPSolution | ForEach-Object Name

            # Assert
            foreach ($expectedSolutionName in $expectedSolutionNames) {
			     $actualSolutionNames -contains $expectedSolutionName | Should Be $true
            }
		}
	}
}