# -----------------------------------------
# Deployment Mode
# -----------------------------------------

$DSP_IsDistributedEnvironment = "$false"

# ******************************************
# Deployment Configuration 
# ******************************************

$DSP_DeploySolutions = "$false"
$DSP_CUSTOM_PortalSetupSolutionsConfigurationFile = ".\Custom\Custom-Solutions.xml"

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://franck-vm2013/"
$DSP_PortalPublishingHostNamePath = "http://standard.dynamite.com"

$DSP_PortalAdmin = "OFFICE\franck.cornu"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Application Configuration
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

# Specify an empty array "@()" if there are not subsites
$DSP_PortalAuthoringRootWebs = @()

# ------------------------------------------
# Common Tokens
# ------------------------------------------
. ./Tokens/Tokens.Common.ps1