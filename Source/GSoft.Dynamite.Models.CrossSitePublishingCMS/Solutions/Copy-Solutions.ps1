﻿# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Copy-Solutions.ps1.template
# Description	: Copy WSP Solutions to a target folder
# -----------------------------------------------------------------------

# Remove existing solutions
Get-ChildItem [[DSP_PackagesFolderPath]] -Recurse | Where-Object {$_.Extension -eq ".wsp"} | Foreach-Object {Remove-Item $_.FullName}

# Grab all WSPs from either DEBUG or RELEASE output folders 
ls [[DSP_CustomSolutionsScanRootPath]] -r | 
	? { $_.attributes -eq "directory" -or ($_.name -eq 'Debug') -or ($_.name -eq 'Release') } | 
	Get-ChildItem -r | 
	? { $_.extension -eq ".wsp" } | 
	ForEach-Object { cp $_.FullName [[DSP_PackagesFolderPath]] -Force; write-host $_.Name 'copied' }

# Grab all WSPs from NuGet installation folders
ls [[DSP_NugetSolutionsScanRootPath]] -r | 
	? { $_.extension -eq ".wsp" } | 
	ForEach-Object { cp $_.FullName [[DSP_PackagesFolderPath]] -Force; write-host $_.Name 'copied' }
