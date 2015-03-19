# Build globally used paths
$testFolderPath = Resolve-Path "$($MyInvocation.MyCommand.Path)\..\.."
$projectUnderTest = (Resolve-Path "$($MyInvocation.MyCommand.Path)\..\..\.." | Split-Path -Leaf).Replace(".Tests", [string]::Empty)
$projectUnderTestPath = Resolve-Path "$testFolderPath\..\..\$projectUnderTest"
$deploymentFolderPath = "$projectUnderTestPath..\..\..\Deployment"
$scriptUnderTestPath = "$deploymentFolderPath\Modules\Publishing\PUB_01\Install-PUB01.ps1"
 
Describe "Install-PUB01.ps1" {

	#region Test utility functions
	function Remove-DeploymentFolder {
		if (Test-Path $deploymentFolderPath) {
			Get-ChildItem -Path $deploymentFolderPath -Recurse | Remove-Item -Force -Recurse
			Remove-Item $deploymentFolderPath
		}
	}

    function New-DuplicateContentPageItems {
        param([string]$siteUrl)

        # Make sure module is loaded
        Import-Module Sharegate
		
        # Get a fake random list (not needed in the procedure because we use an Excel file but needed for the cmdlet)
		$srcList = Connect-Site -Url $siteUrl | Get-List | Where-Object { $_.BaseType -eq "List" } | Select -First 1
		$dstList = Connect-Site -Url "$siteUrl/rh" | Get-List -Name "Content Pages"

		if($dstList -ne $null) {
            $copySettings = New-CopySettings -OnContentItemExists Overwrite
            
			# Trick to get the exact mappings settings for the list
			$mappingSettings = Get-PropertyMapping -SourceList $dstList -DestinationList $dstList
 
			# Add custom key (internal unique ID)
			$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source DynamiteInternalId -Destination DynamiteInternalId -Key

			# Remove previous key
			$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Created -Destination Created
			$mappingSettings = Set-PropertyMapping -MappingSettings $mappingSettings -Source Title -Destination Title

			# Get the specified file according to the default folder
			$file = Get-ChildItem -Path "$testFolderPath\PUB_01\AC1_DuplicateContentPages.xlsx"
			if ($file -ne $null)
			{		
				return Copy-Content -SourceList $srcList -DestinationList $dstList -ExcelFilePath $file.FullName -MappingSettings $mappingSettings -CopySettings $copySettings
			}
		}
    }
    #endregion

	Context "Vanilla cross-site publishing scenario" {
	
		BeforeEach {
            # Publish deployment folder and update tokenize template files
            Invoke-Expression "$projectUnderTestPath\Publish-DeploymentFolder.ps1  -Force -SetLocationToDestination"
            Update-DSPTokens
		}

		AfterEach {
            Set-Location $testFolderPath
            Remove-DeploymentFolder
		}

		It "AC0: Should create the site structure" {
            # Arrange
            [xml]$sitesXml = Get-Content ".\Modules\Publishing\PUB_01\Default\Default-Sites.xml"
            $webApplication = Get-SPWebApplication -Identity $sitesXml.WebApplication.Url
            $expectedSites = $sitesXml.WebApplication.Site

            # Act
			#& $scriptUnderTestPath
            $actualSites = Get-SPSite -WebApplication $webApplication

            # Assert
            foreach ($expectedSite in $expectedSites) {
                # Check if sites exist by comparing URL to HostNamePath
			    ($actualSites | ForEach-Object Url) -contains $expectedSite.HostNamePath | Should Be $true
            }
		}

		It "AC1: Should not be able to create more than one content page per navigation term" {
            ### Arrange ###

            # Load tokens
            . ".\Tokens.$([System.Net.Dns]::GetHostName()).ps1"

            ### Act ###
            $copyResults = New-DuplicateContentPageItems -siteUrl $DSP_PortalAuthoringHostNamePath

            ### Assert ###

            # 2 errors, 1 for the failed list item and 1 for the global copy
            # 3 errors, 1 for the failed list item, 1 for the existing item and 1 for the global copy
            ($copyResults.Errors -eq 2) -or ($copyResults.Errors -eq 3)| Should Be $true

            # Items copied is actually "items processed"
            $copyResults.ItemsCopied | Should Be 2
		}
	}
}