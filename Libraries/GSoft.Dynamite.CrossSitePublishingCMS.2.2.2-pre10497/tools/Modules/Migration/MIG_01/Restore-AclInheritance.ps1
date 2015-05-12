# -----------------------------------------------------------------------
# Copyright		: GSoft @2015
# Model  		: Cross Site Publishing CMS
# File          : Restore-AclInheritance.ps1.template
# Description	: 	Restores ACL inheritances on the files in the specified folder.
#					This is to fix a bug where the files have a non-inherited permission
#					(unknown source for now, maybe caused by a unzipping the archive).
#					If files have unique permissions, Sharegate breaks the permission inheritance on import.
# -----------------------------------------------------------------------

param(
	[ValidateScript({ Test-Path $_ })]
	[string]
	$folderPath)

$files = Get-ChildItem -Path $folderPath -Recurse
foreach ($file in $files) {
	
	# Get access control lists of the file
	$acls = Get-Acl -path $file.FullName
	foreach ($acl in $acls) { 
		$path = (Convert-Path $acl.PSPath) 
		
		# Get access rules that aren't inherited and remove them
		foreach ($access in ($acl.Access | where { $_.IsInherited -ne $true })) { 
			$acl.RemoveAccessRule($access) | Out-Null
		}
	
	# Set the ACL to save the changes
	Set-Acl -path $path -aclObject $acl 
	}
}