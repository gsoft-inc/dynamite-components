﻿# -----------------------------------------
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
$DSP_CUSTOM_PortalSetupSolutionsConfigurationFile = ".\Custom\Custom-Solutions.xml"

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
# Multilingualism Configuration 
# ******************************************
$DSP_IsMultilingual = $true
$DSP_VariationsLabels = @('en','fr')
$DSP_SourceLabel = "en"

# ******************************************
# Webs Configuration 
# ******************************************
$DSP_PortalAuthoringRootWebs = @('rh','com')