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

$DSP_PortalAdmin = "OFFICE\yohan.belval"
$DSP_PortalDatabaseName = "WSS_Content_Dynamite"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Search Configuration 
# ******************************************
$DSP_SearchServiceApplicationName = "Search Service Application"
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