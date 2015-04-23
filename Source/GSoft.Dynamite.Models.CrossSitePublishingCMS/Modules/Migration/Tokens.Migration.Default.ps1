# If the DSP_MigrationFolderMappings hasn't been set, initialize and default to null
if ((Get-Variable -Name "DSP_MigrationFolderMappings" -ErrorAction Ignore) -eq $null) { $DSP_MigrationFolderMappings = "`$null" }

# If the DSP_MigrationDataConfigurationScript hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataConfigurationScript" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataConfigurationScript = ".\Default\Configure-MigrationData.ps1" 
}

# If the DSP_MigrationDataPropertyMappingsName hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataPropertyMappingsName" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataPropertyMappingsName = "CrossSitePublishingCMSTemplate" 
}

# If the DSP_MigrationDataPropertyMappingsFile hasn't been set, initialize and default
if ((Get-Variable -Name "DSP_MigrationDataPropertyMappingsFile" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationDataPropertyMappingsFile = ".\Default\DynamitePropertyTemplate.sgt" 
}

# If the DSP_MigrationAssociationKeys hasn't been set, initialize and default to use the content association key
if ((Get-Variable -Name "DSP_MigrationAssociationKeys" -ErrorAction Ignore) -eq $null) { 
	$DSP_MigrationAssociationKeys = "[Ordered]@{ 
		'en' = 'Content Association Key';
		'fr' = 'Clef d''association de contenu'; }"
}

# ============================================
# MIGRATION MODULE FEATURES
# ============================================
$DSP_CrossSitePublishingCMS_MIG_Fields = "df1a7bc4-0d71-4c04-bb4a-7ab19705bdf7"
$DSP_CrossSitePublishingCMS_MIG_ContentTypes = "e84769bf-6ca7-4cab-a114-9a0227888634"
$DSP_CrossSitePublishingCMS_MIG_ManagedProperties = "658fcb91-bd58-43f9-bee7-b9c14e58b34d"