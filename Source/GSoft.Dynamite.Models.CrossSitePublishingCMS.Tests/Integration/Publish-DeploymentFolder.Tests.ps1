$here = Split-Path -Parent $MyInvocation.MyCommand.Path

# Script under test (sut)
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path).Replace(".Tests.", ".")
$sutPath = "$here\..\..\GSoft.Dynamite.Models.CrossSitePublishingCMS\$sut"

$publishDest = "..\..\..\Deployment"
 
Describe "Publish-CMSDeploymentFolder.ps1" {

	# Test utility functions
	function Add-DeploymentFolder {
		if ((Test-Path $script:publishDest) -eq $false) {
			New-Item -ItemType Directory -Force -Path $script:publishDest | Out-Null
			New-Item -ItemType Directory -Force -Path (Join-Path $script:publishDest "\Test\") | Out-Null
		}
	}
	
	function Remove-DeploymentFolder {
		if (Test-Path $script:publishDest) {
			Get-ChildItem -Path $publishDest -Recurse | Remove-Item -Force -Recurse
			Remove-Item $publishDest
		}
	}

	Context "when deployment folder has NOT YET been created" {
	
		BeforeEach {	
			# Pre-condition: make sure nothing exists under $solutionRoot/Deployment
			Write-Host "     --Test Setup--"
			Remove-DeploymentFolder
		}

		AfterEach {
			# Post-condition: make sure nothing exists under $solutionRoot/Deployment
			Remove-DeploymentFolder
			Write-Host "     --Test Teardown--"
		}

		It "should create a deployment folder at solution root" {
			# run the script
			& $sutPath
		
			Test-Path $publishDest | Should Be $true
		}

		It "should copy all files from NuGet package" {
			# run the script
			& $sutPath

			Test-Path "$publishDest\Install.ps1" | Should Be $true
			Test-Path "$publishDest\Modules" | Should Be $true
			Test-Path "$publishDest\Modules\Publishing\Tokens.Publishing.Custom.ps1" | Should Be $true
			Test-Path "$publishDest\Modules\Publishing\Tokens.Publishing.Default.ps1" | Should Be $true
			Test-Path "$publishDest\Modules\Publishing\PUB_01\Install-PUB01.ps1" | Should Be $true
			Test-Path "$publishDest\Modules\Publishing\PUB_01\Setup-Fields.ps1.template" | Should Be $true
			Test-Path "$publishDest\Solutions" | Should Be $true
			Test-Path "$publishDest\Tokens" | Should Be $true
			# etc.
		}

		It "should copy all files from local folder" {
			# run the script
			& $sutPath

			(Get-ChildItem "$publishDest\Tokens.*.ps1").Count -ge 1 | Should Be $true
			Test-Path "$publishDest\Solutions\Custom\Custom-Solutions.xml.template" | Should Be $true
			# etc.
		}

		It "should copy all WSP's from NuGet libs" {
			# run the script
			& $sutPath

			Test-Path "$publishDest\Solutions\GSoft.Dynamite.wsp" | Should Be $true
			Test-Path "$publishDest\Solutions\GSoft.Dynamite.Publishing.SP.wsp" | Should Be $true
			# etc.
		}
	
		It "should copy Gary's wonderful WSP" {
			# run the script
			& $sutPath

			Test-Path "$publishDest\Solutions\Lapointe.SharePoint.PowerShell.wsp" | Should Be $true
			# etc.
		}
	
		It "should copy all WSP's from current solution" {
			# run the script
			& $sutPath
	
			# slightly strange that this one would make it, but - at publish-time -
			# we want to bring together all packaged WSPs under the solution root
			Test-Path "$publishDest\Solutions\Dynamite.Demo.Intranet.SP.wsp" | Should Be $true
			# etc.
		}
	
		It "should copy Dynamite PowerShell Toolkit, just in case" {
			# run the script
			& $sutPath
	
			# slightly strange that this one would make it, but - at publish-time -
			# we want to bring together all packaged WSPs under the solution root
			Test-Path "$publishDest\DSP\Dynamite.PowerShell.Toolkit" | Should Be $true
			Test-Path "$publishDest\DSP\Dynamite.PowerShell.Toolkit\Dynamite.PowerShell.Toolkit.psm1" | Should Be $true
			# etc.
		}
	}
	
	Context "when deployment folder has ALREADY been created" {
		
		BeforeEach {
			# Pre-condition: make sure something exists under $solutionRoot/Deployment
			Add-DeploymentFolder
		}

		AfterEach {
			# Post-condition: make sure nothing exists under $solutionRoot/Deployment
			Remove-DeploymentFolder
		}

		It "shouldn't delete existing folder by default" {
			Test-Path "$publishDest\Test" | Should Be $true

			# run the script
			& $sutPath

			Test-Path "$publishDest" | Should Be $true
			Test-Path "$publishDest\Test" | Should Be $true
			Test-Path "$publishDest\Solutions" | Should Be $false
			Test-Path "$publishDest\Modules" | Should Be $false
		}
		
		It "should delete existing folder if forced" {
			Test-Path "$publishDest\Test" | Should Be $true

			# run the script
			& $sutPath -Force

			Test-Path "$publishDest" | Should Be $true
			Test-Path "$publishDest\Test" | Should Be $false
		}
	}
}