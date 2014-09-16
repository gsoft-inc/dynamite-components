﻿# ============================================
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