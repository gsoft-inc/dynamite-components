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
$DSP_DEFAULT_PortalRestrictedConfigurationFile = "./Default/Default-RestrictedTermGroup.xml"

$DSP_DEFAULT_PortalNavigationTermGroup = "Portal - Navigation"
$DSP_DEFAULT_PortalRestrictedTermGroup = "Portal - Restricted"

# ============================================
# STEP 3: Define security
# ============================================

$DSP_DEFAULT_PortalPermissionsConfigurationFile = "./Default/Default-Permissions.xml"

#### USERS

$DSP_DefaultVisitorsGroupUsers = @"
	<User>dev\danb</User>
	<User>dev\ibent</User>
"@

$DSP_DefaultMembersGroupUsers = @"
	<User>dev\arturol</User>
"@

# ============================================
# PUBLISHING MODULE FEATURES
# ============================================

$DSP_CrossSitePublishingCMS_PUB_Catalogs = "04643c76-8b9a-4f70-9df4-7565d76e2e8a"
$DSP_CommonCMS_PUB_ContentTypes = "88d32ecd-2a4c-4cff-ad09-b74ab5aca18c"
$DSP_CommonCMS_PUB_Fields = "97a3a3ef-5989-46f0-a117-6f489f58a26b"
$DSP_CommonCMS_PUB_PageLayouts = "374b7569-9e11-4ecd-8771-da59be52141e"
$DSP_CrossSitePublishingCMS_PUB_Pages = "c0dbca2d-b477-4d91-bb55-b342f6458221"
$DSP_CrossSitePublishingCMS_PUB_ResultSources = "8d99c11b-135e-48e3-ad8f-e04e06d8b654"
$DSP_CrossSitePublishingCMS_PUB_DisplayTemplates = "d96b6f0d-8536-4367-bf3f-4a4a9fa286cb"
$DSP_CrossSitePublishingCMS_PUB_ResultTypes = "990b925b-fe6e-41ea-ae6a-3011308a303e"
$DSP_CrossSitePublishingCMS_PUB_Lists = "3be0c334-1fa9-4631-ade5-f9e044b1289d"