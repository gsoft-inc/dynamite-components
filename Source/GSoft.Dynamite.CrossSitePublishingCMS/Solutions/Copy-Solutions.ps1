# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Copy-Solutions.ps1.template
# Description	: Copy WSP Solutions to a target folder
# -----------------------------------------------------------------------

# Remove existing solutions
Get-ChildItem D:\dev\Dynamite-Components\Source\GSoft.Dynamite.CrossSitePublishingCMS.\Solutions\Packages -Recurse | Where-Object {$_.Extension -eq ".wsp"} | Foreach-Object {Remove-Item $_.FullName}

# Grab all WSPs from either DEBUG or RELEASE output folders, and all WSPs from NuGet installation folders
ls D:\dev\Dynamite-Components\Libraries -r | 
	? { $_.attributes -eq "directory" -or ($_.name -eq 'tools') } | 
	Get-ChildItem -r | 
	? { $_.extension -eq ".wsp" } | 
	ForEach-Object { cp $_.FullName D:\dev\Dynamite-Components\Source\GSoft.Dynamite.CrossSitePublishingCMS.\Solutions\Packages -Force; write-host $_.Name 'copied' }
