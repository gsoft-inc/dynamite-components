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

#### CONTENT TYPES

$DSP_DEFAULT_PortalContentTypesConfigurationFile = "./Default/Default-ContentTypes.xml"

#### FIELDS

$DSP_DEFAULT_PortalFieldsConfigurationFile = "./Default/Default-Fields.xml"

#### CATALOGS

$DSP_DEFAULT_PortalCatalogsConfigurationFile = "./Default/Default-Catalogs.xml"

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

# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
# ----------------------------------------
# PUB 02: VIEW ITEM DETAILS
# ----------------------------------------
# >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

# ============================================
# STEP 1: Create Result Sources
# ============================================

$DSP_DEFAULT_PortalResultSourcesConfigurationFile = "./Default/Default-ResultSources.xml"

# ============================================
# STEP 2: Create Page Layouts
# ============================================

$DSP_DEFAULT_PortalPageLayoutsConfigurationFile = "./Default/Default-PageLayouts.xml"

# ============================================
# STEP 3: Create Pages
# ============================================

$DSP_DEFAULT_PortalPagesConfigurationFile = "./Default/Default-Pages.xml"