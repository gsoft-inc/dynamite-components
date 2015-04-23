# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Configure-MigrationData.template.ps1
# Description	: Configures the Sharegate Excel migration metadata before the import.
#                 NOTE: If overriden, the file must keep the same method signature
# -----------------------------------------------------------------------

param(
	[ValidateScript({ Test-Path $_ })]
	[string]
	$FolderPath)


# Get Sharegate configuration Excel files
$ExcelFiles = Get-ChildItem -Path $FolderPath -Recurse  |  Where-Object { ($_.Extension -eq ".xlsx") -and ($_.Name -match $_.Parent.Name) }
$ExcelFiles | ForEach-Object {
    $ExcelFile = Open-DSPExcelFile -Path $_.FullName

    # Change logins to default portal administrator
    $ExcelFile | Edit-DSPExcelColumnValue -Pattern "\w+\\.+" -Value "[[DSP_PortalAdmin]]" -NoDispose

    # Need to dispose the file before trying to open with Sharegate API
	$ExcelFile.Dispose()
}