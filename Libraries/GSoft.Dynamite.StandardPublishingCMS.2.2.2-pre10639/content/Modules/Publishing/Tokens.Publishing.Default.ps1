# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

# ============================================
# STEP 1: Create structure
# ============================================

#### SITES

$DSP_DEFAULT_PortalSitesConfigurationFile = "./Default/Default-Sites.xml"

#### WEBS

$DSP_DEFAULT_PortalWebsConfigurationFile = "./Default/Default-Webs.xml"

# ============================================
# STEP 2: Categorize content
# ============================================

#### TAXONOMY
$DSP_DEFAULT_PortalNavigationConfigurationFile = "./Default/Default-NavigationTermGroup.xml"
$DSP_DEFAULT_PortalNavigationTermGroup = "Portal - Navigation"

# ============================================
# STEP 3: Define security
# ============================================

$DSP_DEFAULT_PortalPermissionsConfigurationFile = "./Default/Default-Permissions.xml"

#### USERS

$DSP_DefaultPublishingVisitorsGroupUsers = @"
<User>NT Authority\Authenticated Users</User>
"@

# ============================================
# PUBLISHING MODULE FEATURES
# ============================================

$DSP_CommonCMS_PUB_ContentTypes = "88d32ecd-2a4c-4cff-ad09-b74ab5aca18c"
$DSP_CommonCMS_PUB_Fields = "97a3a3ef-5989-46f0-a117-6f489f58a26b"
$DSP_CommonCMS_PUB_Lists = "3be0c334-1fa9-4631-ade5-f9e044b1289d"
$DSP_CommonCMS_PUB_PageLayouts = "374b7569-9e11-4ecd-8771-da59be52141e"
$DSP_CrossSitePublishingCMS_PUB_ResultSources = "8d99c11b-135e-48e3-ad8f-e04e06d8b654"
$DSP_CrossSitePublishingCMS_PUB_SearchRESTAnonymous = "c172bf31-e0dc-4fcf-b96c-0d0cc0aa3aed"
$DSP_StandardPublishingCMS_PUB_MetadataNavigation = "20b34b37-095a-437a-a5ab-65af7616da8f"
$DSP_CommonCMS_LANG_CreateVariationsHierarchies = "50213452-1d24-4eae-b915-9ade611bbeb5"
$DSP_CommonCMS_PUB_ReusableContent = "0aef5aef-bd7d-44ed-936f-91354b6d4e52"

# ============================================
# SHAREPOINT OOTB FEATURES
# ============================================
$DSP_SharePoint_MetadataAndFiltering = "7201d6a4-a5d3-49a1-8c19-19c4bac6e668" 

# ============================================
# SERVICE LOCATOR
# ============================================
# If the DSP_ServiceLocatorAssemblyName hasn't been set, initialize and default to null
if ((Get-Variable -Name "DSP_ServiceLocatorAssemblyName" -ErrorAction Ignore) -eq $null) { $DSP_ServiceLocatorAssemblyName = "`$null" }