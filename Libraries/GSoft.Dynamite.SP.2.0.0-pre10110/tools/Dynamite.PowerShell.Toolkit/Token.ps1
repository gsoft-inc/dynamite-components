#
# Module 'Dynamite.PowerShell.Toolkit'
# Generated by: GSoft, Team Dynamite.
# Generated on: 10/24/2013
# > GSoft & Dynamite : http://www.gsoft.com
# > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
# > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
#

<#
.SYNOPSIS
	Replaces tokens in all child items with the file extention .template recursively.
	
.DESCRIPTION
	Replaces tokens in all child items with the file extention .template recursively.
	The template item is copied with without the .template extention before the tokens are replaced.
	The tokens are defined in a 'Tokens.Domain.ps1' file.
	Please define tokens as valiables with the prefix 'DSP_'. 
	EX.: $DSP_token1 = "Value 1" will replace [[DSP_token1]] in any .template file
	
    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
    
.PARAMETER Path
	The path where all the files are located. By default the value is the current working location.
	
.PARAMETER Domain
	The prefix for the token file 'Tokens.Domain.ps1'. By default the value is the current NetBIOS name.
 	
.PARAMETER Encoding
	Specifies the file encoding. The default is UTF8.
	Valid values are:
	-- ASCII: Uses the encoding for the ASCII (7-bit) character set.
	-- BigEndianUnicode: Encodes in UTF-16 format using the big-endian byte order.
	-- Byte: Encodes a set of characters into a sequence of bytes.
	-- String: Uses the encoding type for a string.
	-- Unicode: Encodes in UTF-16 format using the little-endian byte order.
	-- UTF7: Encodes in UTF-7 format.
	-- UTF8: Encodes in UTF-8 format.
	-- Unknown: The encoding type is unknown or invalid. The data can be treated as binary.
	
.PARAMETER TemplatePath
	The path where the template files are tokenized. By default the value is the current working location.
               
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
#>
function Update-DSPTokens {
	Param (
		[Parameter(Mandatory=$false, ValueFromPipeline=$true)]
		[ValidateScript({Test-Path $_})]
		[string]$Path = (Get-Location),
		
		[Parameter(Mandatory=$false)]
		[string]$Domain = [System.Net.Dns]::GetHostName(),
		
		[Parameter(Mandatory=$false)]
		[Microsoft.PowerShell.Commands.FileSystemCmdletProviderEncoding]
		$Encoding = [Microsoft.PowerShell.Commands.FileSystemCmdletProviderEncoding]::UTF8,
		
		[ValidateScript({Test-Path $_})]
		[string]$TemplatePath = (Get-Location),
		
		[Parameter(Mandatory=$false)]
		[switch]$UseHostName,
		
		[Parameter(Mandatory=$false)]
		[switch]$UseDomain
	)
	
	if ($UseHostName -eq $true) {
		$Domain = [System.Net.Dns]::GetHostName()
	}
	
	if ($UseDomain -eq $true) {
		$Domain = (Get-CurrentDomain)
	}

	$tokenPath = ""
	
	$Path = Resolve-Path $Path
	$TemplatePath = Resolve-Path $TemplatePath
		
	Get-ChildItem -Path $Path -Include "Tokens.$Domain.ps1" -Recurse | foreach {
		$tokenPath = $_.FullName
	}
	
	if (Test-Path $tokenPath) {
		Write-Host "Found token file at : $tokenPath"
		Execute-TokenFile $TemplatePath $tokenPath $Encoding
	}
	else {
		Write-Host "Didn't found the token file named : Tokens.$Domain.ps1"
	}
}

<#
.SYNOPSIS
	Returns the current domain name using wmi. If wmi is not installed, 
	then use the USERDOMAIN environment variable.
#>
function script:Get-CurrentDomain {
	try {
		# Return this version if wmi is installed
		return [string](gwmi Win32_NTDomain).DomainName.Trim()
	} catch {
		# Fall back on this version in case of error
		return $env:USERDOMAIN
	}
}

function script:Execute-TokenFile {
	param (
		$Path,
		$TokenPath,
		$Encoding
	)
	Write-Host "$TokenPath"
	# Load tokens
	. $TokenPath
	$tokens = Get-Variable -Include "DSP_*"
	
	# Replace tokens in all .template files.
	Get-ChildItem -Path $Path -Include "*.template" -Recurse | foreach {
		Write-Host "Replacing tokens in file '$_'... " -NoNewline
		
		try {
			# Get the contents of the template file.
			$contents  = Get-Content $_ -Encoding $Encoding -ErrorAction Stop
			
			# for each token in our token file, we replace the token in the contents of the file.
			$tokens | ForEach {
				$contents = $contents -replace "\[\[$($_.Name)\]\]", $_.Value
			}
			
			# Write the contents with the replaces tokens to a new file overriding any current file.
			Set-Content -Encoding $Encoding -Value $contents -path $_.FullName.Substring(0, $_.FullName.IndexOf(".template")) -Force -ErrorAction Stop
		} catch {
			Write-Host "Failed - $_" -ForegroundColor Red
		}
		
		Write-Host "Success!" -ForegroundColor Green
	}
}

# Prepare package for use
function Initialize-DSPTokens {
	Param (   
        [Parameter(Mandatory=$false)]
        [string]$DestinationPath,

        [Parameter(Mandatory=$false)]
        [string]$ProjectPath,

        [Parameter(Mandatory=$false)]
        [string]$SourcePath,

        [Parameter(Mandatory=$false)]
        [string]$CustomizationPath,

        [Parameter(Mandatory=$false)]
		[switch]$Force,

        [Parameter(Mandatory=$false)]
		[switch]$Release,

        [Parameter(Mandatory=$false)]
		[switch]$Demo
	)
    
    $SourceFilter = "GSoft.Dynamite.CrossSitePublishingCMS*"
    if($Release -eq $false)
    {
        $SourceFilter = $SourceFilter + "pre*"
    } 

    if (![string]::IsNullOrEmpty($ProjectPath)) 
    {
        $ProjectPath = Resolve-Path $ProjectPath
        Write-Host "Project Path used is $ProjectPath" -ForegroundColor Yellow

        $CustomizationPath = Join-Path $ProjectPath "/Source" | Resolve-Path
        
        # DestinationPath will be /Source/package
        $DestinationPath = Join-Path $CustomizationPath "/package"

        if (!(Test-Path $DestinationPath)) 
        {
            New-Item -ItemType Directory -Force -Path $DestinationPath | Out-Null
        }

        if ($Demo -eq $false)
        {
            # Source path is the latest CrossSitePublishingCMS tools folder
            $SourcePath = Get-ChildItem -Path $ProjectPath -Recurse -Include $SourceFilter | ? { $_.PSIsContainer } | sort Name | Select-Object -Last 1 | Select FullName | foreach {$_.FullName}
            $SourcePath = Join-Path $SourcePath "/tools" | Resolve-Path
                   
            # CustomizationPath will be the one finishing in .Script
            $CustomizationPath = Get-ChildItem -Path $CustomizationPath | ? { $_.Name -like "*.Scripts" } | Select FullName | foreach {$_.FullName}
        }
        else 
        {
            $CustomizationPath = Get-ChildItem -Path $CustomizationPath | ? { $_.Name -like "*.CrossSitePublishingCMS" } | Select FullName | foreach {$_.FullName}
        }
    }

    # Quirks for the demo folder who have no source
    if ($Demo -eq $true) 
    {
        $SourcePath = $CustomizationPath
    }

    $SourcePath = Resolve-Path $SourcePath
    $CustomizationPath = Resolve-Path $CustomizationPath
    $DestinationPath = Resolve-Path $DestinationPath
  
    # Force delete all Package folder
    if ($Force -eq $true)
    {
        Write-Host "Attempt to clear the following path : $DestinationPath... " -ForegroundColor Yellow -NoNewLine
        Get-ChildItem -Path $DestinationPath -Recurse | Remove-Item -force -recurse
        Write-Host "DONE" -ForeGroundColor Green
    }

    # 1 Copy and tokenize everything from source folder
    Execute-DSPTransfert $SourcePath $DestinationPath

    # 2 Copy and tokenize everything from customization folder
    Execute-DSPTransfert $CustomizationPath $DestinationPath

    # 3 Setup WSP Copy
    $wspPath = Join-Path $DestinationPath "\Solutions\WSP\"
    $filterPath = "*`\bin`\Debug"

    if ($Release -eq $true)
    {
        $filterPath = $filterPath.Replace("Debug", "Release")
    }
    
    # 4 Copy WSP from /Libraries
    if ($Demo -eq $false)
    {
        $index = $SourcePath.IndexOf("Libraries`\")
        $libPath = $SourcePath.Substring(0, $index + "Libraries`\".Length)
        Copy-DSPSolution $libPath  $wspPath "*"
    }

    # 5 Copy WSP from /Source
    $sourcePath = Join-Path $CustomizationPath "/../" | Resolve-Path
    Copy-DSPSolution $sourcePath $wspPath $filterPath

    # 6 Copy DSP from /Libraries/GSoft.Dynamite.SP*/tools
    $dynamiteSP = Get-ChildItem -Path $ProjectPath -Include "GSoft.Dynamite.SP*" -Recurse | ? { $_.PSIsContainer } | sort Name | Select-Object -Last 1 | Select FullName | foreach {$_.FullName}
    $dynamiteSPTools = Join-Path $dynamiteSP "tools"

    if (Test-Path $dynamiteSPTools)
    {
        $dspPath = Join-Path $DestinationPath "/DSP/"
        Copy-Item -Path "$dynamiteSPTools/" -Destination $dspPath -recurse -force
    }

}

function script:Execute-DSPTransfert {
	param (
		$Path,
        $DestinationPath
	)
    
    # Copy all .ps1 script inside $Path to $DestinationPath
    Copy-DSPFile $Path $DestinationPath @("*.ps1","*.template","*.xlsx","*.jpg","*.jpeg","*.png","*.sgt")
}

function script:Copy-DSPFile {
	param (
		$Path,
        $DestinationPath,
		$Match
	)

    if ((![String]::IsNullOrEmpty($DestinationPath)))
    {
    	# Replace tokens in all .template files.
	    Get-ChildItem -Path $Path -Include $Match -Recurse | foreach {
		    Write-Host "Copying script file '$_'... " -NoNewline

            # Get the relative Path of the file from where we are.
            $relativePath = $_.FullName.Replace($Path, "")

            # We then build the path from the package path with the relative folder 
            $fileFullName = Join-Path $DestinationPath $relativePath

            # We remove the filename to test the path and create the folder if it doesnt exist
            $packageSpecificPath = Split-Path $fileFullName
            if (!(Test-Path $packageSpecificPath)) 
            {
                New-Item -ItemType Directory -Force -Path $packageSpecificPath | Out-Null
            }

            # We write the tokenized file
			Copy-Item $_.FullName $fileFullName -Force -ErrorAction Stop
		    Write-Host "Success!" -ForegroundColor Green
        }
    }
}

function script:Copy-DSPSolution {
	param (
		$Path,
        $DestinationPath,
		$FilterPath
	)
    
    if ([string]::IsNullOrEmpty($FilterPath))
    {
        $FilterPath = "*"
    }

    if (!(Test-Path $DestinationPath)) 
    {
        New-Item -ItemType Directory -Force -Path $DestinationPath | Out-Null
    }
    
    Write-Host "Searching WSPs in $Path matching $FilterPath"

    Get-ChildItem -Path $Path -Include "*.wsp" -Recurse | where { (Split-Path $_.FullName) -like $FilterPath } | foreach {
		Write-Host "Copying WSP file '$_'... " -NoNewline
		Copy-Item $_.FullName $DestinationPath -Force -ErrorAction Stop
		Write-Host "Success!" -ForegroundColor Green
    }
}