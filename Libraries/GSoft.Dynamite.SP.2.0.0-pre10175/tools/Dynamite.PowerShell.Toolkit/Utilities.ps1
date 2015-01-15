﻿#
# Module 'Dynamite.PowerShell.Toolkit'
# Generated by: GSoft, Team Dynamite.
# Generated on: 10/24/2013
# > GSoft & Dynamite : http://www.gsoft.com
# > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
# > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
#

function Get-BooleanValue() {
  Param
  (
  	[string]$Value = "",		
  	[bool]$DefaultValue = $false
  )

  try
  {
  	$parsedValue = [bool]::Parse($Value)
  	Write-Output $parsedValue
  }
  catch [FormatException]
  {
  	if($DefaultValue -ne $null)
    {
  		Write-Output $DefaultValue
  	}
    else
    {
  		throw $_
  	}
  }
}

function New-HeaderDrawing(){
  Param
  (
  	[hashtable]$Values	
  )

	Write-Host "`n$("-" * 50)" -ForegroundColor Green
	
    $Values.Keys | Foreach-Object {
    
     	Write-Host $_ -ForegroundColor Cyan -NoNewline
		Write-Host $Values.Item($_) -ForegroundColor Yellow  
     }

	Write-Host "$("-" * 50)`n" -ForegroundColor Green
}

function Test-DSPIsAdmin()
{
    $currentPrincipal = New-Object Security.Principal.WindowsPrincipal( [Security.Principal.WindowsIdentity]::GetCurrent() )
    return $currentPrincipal.IsInRole( [Security.Principal.WindowsBuiltInRole]::Administrator )
}