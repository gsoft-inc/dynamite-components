# -----------------------------------------
# Deployment Mode
# -----------------------------------------
$DSP_IsDistributedEnvironment = "$false"

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://dynamite.com/"
$DSP_PortalPublishingHostNamePath = "http://intranet.dynamite.com"
$DSP_PortalAuthoringHostNamePath = "http://authoring.dynamite.com"

$DSP_PortalAuthoringRootWebUrl = $DSP_PortalAuthoringHostNamePath 

$DSP_PortalAdmin = "OFFICE\franck.cornu"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Search Configuration 
# ******************************************
$DSP_SearchServiceApplicationName = "Search"
$DSP_SearchContentSourceName = "Local SharePoint sites"

# ******************************************
# Multilingualism Configuration 
# ******************************************
$DSP_IsMultilingual = $false
$DSP_VariationsLabels = @('en','fr')
$DSP_SourceLabel = "en"

# ******************************************
# Webs Configuration 
# ******************************************
$DSP_PortalAuthoringRootWebs = @('rh','com')

# ------------------------------------------
# Common Tokens
# ------------------------------------------
. ./Tokens/Tokens.Common.ps1