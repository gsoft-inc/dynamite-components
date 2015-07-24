# --------------------------------------- COMMON PARAMETERS ------------------------------------------------------- #

# If the DSP_MigrationDataConfigurationScript hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataConfigurationScript" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataConfigurationScript = ".\Default\Configure-MigrationData.ps1" 
}

# If the DSP_MigrationDataSourceMappingsName hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataSourceMappingsName" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataSourceMappingsName = "CrossSitePublishingCMSTemplate" 
}

# If the DSP_MigrationDataSourceMappings hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataSourceMappings" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataSourceMappings = ".\Default\Multilingual\Source\DynamitePropertyTemplate.sgt" 
}

# If the DSP_MigrationDataTargetMappingsName hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataTargetMappingsName" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataTargetMappingsName = "CrossSitePublishingCMSTemplate" 
}

# If the DSP_MigrationDataTargetMappings hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataTargetMappings" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataTargetMappings = ".\Default\Multilingual\Targets\DynamitePropertyTemplate.sgt" 
}

# If the DSP_MigrationAssociationKeys hasn't been set, initialize and default to use the content association key
if ((Get-Variable -Name "DSP_MigrationAssociationKeys" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationAssociationKeys = "[Ordered]@{ 
		'en' = 'Content Association Key';
		'fr' = 'Clef d''association de contenu'; }"
}

# If the DSP_MigrationSourceContentTypeMappings hasn't been set, initialize the default to use an empty hashtable
if ((Get-Variable -Name "DSP_MigrationSourceContentTypeMappings" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationSourceContentTypeMappings = "[Ordered]@{}"
}

# If the DSP_MigrationTargetContentTypeMappings hasn't been set, initialize the default to use an empty hashtable
if ((Get-Variable -Name "DSP_MigrationTargetContentTypeMappings" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationTargetContentTypeMappings = "[Ordered]@{}"
}

# If the DSP_MigrationThreadNumber hasn't been set, initialize the default to 5
if ((Get-Variable -Name "DSP_MigrationThreadNumber" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationThreadNumber = "5"
}

# --------------------------------------- EXCEL DATA SOURCE --------------------------------------------------------- #

# If the DSP_MigrationFolderMappings hasn't been set, initialize and default to null
if ((Get-Variable -Name "DSP_MigrationFolderMappings" -ErrorAction Ignore) -eq $null) { $DSP_MigrationFolderMappings = "`$null" }

# --------------------------------------- SITE DATA SOURCE ---------------------------------------------------------- #

# If the DSP_MigrationSourceSiteMapping hasn't been set, initialize the empty hashtable
if ((Get-Variable -Name "DSP_MigrationSourceSiteMapping" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationSourceSiteMapping = "[Ordered]@{}"
}

# If the DSP_MigrationTargetSiteMappings hasn't been set, initialize the empty hashtable
if ((Get-Variable -Name "DSP_MigrationTargetSiteMappings" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationTargetSiteMappings = "[Ordered]@{}"
}

# If the DSP_MigrationListNames hasn't been set, initialize the empty hashtable
if ((Get-Variable -Name "DSP_MigrationListNames" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationListNames = "@('Pages','Documents','Images')"
}

# ============================================
# MIGRATION MODULE FEATURES
# ============================================
$DSP_CommonCMS_MIG_Fields = "df1a7bc4-0d71-4c04-bb4a-7ab19705bdf7"
$DSP_CommonCMS_MIG_ContentTypes = "e84769bf-6ca7-4cab-a114-9a0227888634"
$DSP_CommonCMS_MIG_ManagedProperties = "658fcb91-bd58-43f9-bee7-b9c14e58b34d"