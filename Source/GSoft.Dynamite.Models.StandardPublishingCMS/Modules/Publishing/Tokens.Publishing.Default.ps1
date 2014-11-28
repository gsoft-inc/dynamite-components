# ----------------------------------------
# PUB 01: CREATE, UPDATE AND DELETE AN ITEM
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

# ============================================
# STEP 1: Create structure
# ============================================

#### SITES

$DSP_DEFAULT_PortalSitesConfigurationFile = "./Default/Default-Sites.xml"

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

$DSP_DefaultVisitorsGroupUsers = @"
"@

$DSP_DefaultMembersGroupUsers = @"
"@

# ============================================
# PUBLISHING MODULE FEATURES
# ============================================

$DSP_CommonCMS_PUB_ContentTypes = "88d32ecd-2a4c-4cff-ad09-b74ab5aca18c"
$DSP_CommonCMS_PUB_Fields = "97a3a3ef-5989-46f0-a117-6f489f58a26b"
$DSP_CommonCMS_PUB_Lists = "3be0c334-1fa9-4631-ade5-f9e044b1289d"
$DSP_StandardPublishingCMS_PUB_MetadataNavigation = "246b965b-f1cb-451f-923f-8fac5812dfec"

# ============================================
# SHAREPOINT OOTB FEATURES
# ============================================
$DSP_SharePoint_MetadataAndFiltering = "7201d6a4-a5d3-49a1-8c19-19c4bac6e668" 