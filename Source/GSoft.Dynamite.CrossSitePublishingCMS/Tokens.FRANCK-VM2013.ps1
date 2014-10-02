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

$DSP_PortalAuthoringRootWebUrl = $DSP_PortalAuthoringHostNamePath 

$DSP_PortalAdmin = "OFFICE\franck.cornu"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Multilingualism Configuration 
# ******************************************

$DSP_IsMultilingual = $true
$DSP_SourceLabel = "en"
$DSP_TargetLabels = "@('fr')"

if($DSP_IsMultilingual)
{
	# Create webs under the source label root site
	$DSP_PortalAuthoringRootWebUrl += "/" + $DSP_SourceLabel
}

# ******************************************
# Webs Configuration 
# ******************************************

$DSP_PortalAuthoringDefaultWebUrl = $DSP_PortalAuthoringRootWebUrl + "/default/"
$DSP_PortalAuthoringDefaultWebName = "Authoring Default Web"