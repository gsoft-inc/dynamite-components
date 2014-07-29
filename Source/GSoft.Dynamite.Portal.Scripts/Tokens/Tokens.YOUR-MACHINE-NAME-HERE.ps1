# --------------------------------------------------------------------------
# Copyright		: GSoft @2014
# Project		: GSoft Dynamite Portal
# File          : Tokens.YOUR-MACHINE-NAME-HERE.ps1
# Description	: Deployment configuration file for YOUR-MACHINE-NAME-HERE
# --------------------------------------------------------------------------

# ******************************************
# Load Common Tokens
# ******************************************
. .\Portal.Common.ps1

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://your.web.app"
$DSP_PortalPublishingHostNamePath = "http://www.portal.com"
$DSP_PortalAuthoringHostNamePath = "http://authoring.portal.com"
$DSP_PortalDocumentHostNamePath = "http://docs.portal.com"
$DSP_PortalPublishingUrl = "http://www.portal.com"
$DSP_PortalPublishingUrlFR = "http://www.portal.com/fr"
$DSP_PortalPublishingUrlEN = "http://www.portal.com/en"
$DSP_PortalAuthoringUrl = "http://authoring.portal.com"
$DSP_PortalAuthoringUrlEN = "http://authoring.portal.com/en"
$DSP_PortalAuthoringUrlFR = "http://authoring.portal.com/fr"
$DSP_PortalDocumentUrl = "http://docs.portal.com"
$DSP_PortalAdmin = "office\your.username"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"

# ******************************************
# Taxonomy
# ******************************************
$DSP_PortalNavigationTermStoreGroup = "Portal - Navigation"
$DSP_PortalContentTermStoreGroup = "Portal - Content"
$DSP_PortalCatalogTermStoreGroup = "Portal - Catalogs"
$DSP_PortalNavigationTermSetNameFR = "Navigation FR"
$DSP_PortalNavigationTermSetNameEN = "Navigation EN"

# ******************************************
# SharePoint Configuration 
# ******************************************
$DSP_TaxonomyServiceAppName = "Managed Metadata Service"
$DSP_SearchServiceAppName = "Search Service Application"
$DSP_SearchContentSourceName = "Local SharePoint Sites"
$DSP_SessionStateTimeoutInMinutes = 60
$DSP_UserProfileApplication = "User Profile Service Application"

$DSP_ResultSearchPageFR = "http://www.portal.com/fr/recherche"
$DSP_ResultSearchPageEN = "http://www.portal.com/en/search"