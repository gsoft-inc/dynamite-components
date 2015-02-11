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
	
	Context "When solution deployment is set to false" {
		
		BeforeEach {
            # Import DSP
            Import-Module Dynamite.PowerShell.Toolkit -Force    
            
            # Mock logging
            Mock Start-DSPLogging {}
            Mock Stop-DSPLogging {}

            # Mock header output
            Mock New-HeaderDrawing {}

            # Remove old Install-Model.ps1
            Remove-Sut

            #Create token file and update the template files
            New-TokenFile -fileName "TESTS" -contents "`$DSP_DeploySolutions = `"`$false`""
            Update-DSPTokens -Path $sutFolderPath -TemplatePath $sutFolderPath -Domain "TESTS"
		}

		AfterEach {
			Remove-TokenFile -fileName "TESTS"
            Remove-Sut
		}

		It "shouldn't try to deploy solution packages" {
            # Arrange
            $actualDeployment = $false
            Mock Deploy-DSPSolution { $actualDeployment = $true }

			# Act
			& $sutPath

            # Assert
			$actualDeployment | Should Be $false
		}
    }

	Context "When solution deployment is set to true" {
		
		BeforeEach {
            # Import DSP
            Import-Module Dynamite.PowerShell.Toolkit -Force    
            
            # Mock logging
            Mock Start-DSPLogging {}
            Mock Stop-DSPLogging {}

            # Mock header output
            Mock New-HeaderDrawing {}

            # Remove old Install-Model.ps1
            Remove-Sut

            #Create token file and update the template files
            New-TokenFile -fileName "TESTS" -contents "`$DSP_DeploySolutions = `"`$true`""
            Update-DSPTokens -Path $sutFolderPath -TemplatePath $sutFolderPath -Domain "TESTS"

            Write-Host "SHould have updated the tokens..."
		}

		AfterEach {
			Remove-TokenFile -fileName "TESTS"
            Remove-Sut
		}

		It "shouldn't try to deploy solution packages" {
            # Arrange
            $actualDeployment = $false
            Mock Deploy-DSPSolution { $actualDeployment = $true }

			# Act
			& $sutPath

            # Assert
			$actualDeployment | Should Be $true
		}
	}
}