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

$DSP_DeploySolutions = "$false"
$DSP_NugetSolutionsScanRootPath = "C:\PATH-TO-YOUR-SOLUTION\Libraries"
$DSP_CustomSolutionsScanRootPath = "C:\PATH-TO-YOUR-SOLUTION\Source"

$DSP_CUSTOM_PortalSetupSolutionsConfigurationFile = ".\Custom\Custom-Solutions.xml"

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://HOSTNAME/"

$DSP_PortalAuthoringRootWebUrl = $DSP_PortalAuthoringHostNamePath 

$DSP_PortalAdmin = "OFFICE\YOUR.NAME"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Multilingualism Configuration 
# ******************************************

$DSP_IsMultilingual = $true
$DSP_VariationsLabels = @('en','fr')
$DSP_SourceLabel = "en"