# -----------------------------------------
# Deployment Mode
# -----------------------------------------

$DSP_IsDistributedEnvironment = "$false"

# ------------------------------------------
# Common Tokens
# ------------------------------------------
. ./Tokens/Tokens.Common.ps1

# ******************************************
# Deployment Configuration 
# ******************************************

$DSP_NugetSolutionsScanRootPath = "D:\dev\Dynamite-Components\Libraries"
$DSP_CustomSolutionsScanRootPath = "D:\dev\Dynamite-Components\Source"

$DSP_CUSTOM_PortalSetupSolutionsConfigurationFile = ".\Custom\Custom-Solutions.xml"

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://franck-vm2013/"
$DSP_PortalPublishingHostNamePath = "http://intranet.dynamite.com"
$DSP_PortalAuthoringHostNamePath = "http://authoring.dynamite.com"
$DSP_PortalAdmin = "OFFICE\franck.cornu"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

##### Webs

$DSP_PortalAuthoringDefaultWebUrl = "http://authoring.dynamite.com/default/"