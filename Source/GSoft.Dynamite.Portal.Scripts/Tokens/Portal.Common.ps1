# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Project		: GSoft Dynamite Portal
# File          : Portal.Common.ps1
# Description	: Deployment configuration file for Common purpose
# -----------------------------------------------------------------------

# ******************************************
# Script Configuration files 
# ******************************************
Write-Host "Setting Common Tokens"

# SolutionPackages
$DSP_SolutionsConfigFile = ".\CmdletConfig\SolutionPackages\Solutions.xml"

# SitesAndFeatures
$DSP_SiteStructureConfigFile = ".\CmdletConfig\SitesAndFeatures\SiteStructure.xml"
$DSP_FeaturesConfigFile = ".\CmdletConfig\SitesAndFeatures\Features.xml"

# Taxonomy
$DSP_PortalNavigationTermGroupConfigFile = ".\CmdletConfig\Taxonomy\PortalNavigationTermGroup.xml"
$DSP_PortalCatalogTermGroupConfigFile = ".\CmdletConfig\Taxonomy\PortalCatalogTermGroup.xml"
$DSP_PortalContentTermGroupConfigFile = ".\CmdletConfig\PortalContentTermGroup.xml"

# Navigation
$DSP_CatalogConnectionsConfigFile = ".\CmdletConfig\Navigation\CatalogConnections.xml"
$DSP_NavigationConfigFile = ".\CmdletConfig\Navigation\Navigation.xml"
$DSP_FacetedNavigationConfigFile =".\CmdletConfig\Navigation\FacetedNavigation.xml"
$DSP_TermDrivenPagesConfigFile = ".\CmdletConfig\Navigation\TermDrivenPages.xml"

# Search
$DSP_ResultTypesConfigFile =".\CmdletConfig\Search\ResultTypes.xml"
$DSP_ResultSourcesConfigFile = ".\CmdletConfig\Search\ResultSources.xml"
$DSP_WebSearchSettingsConfigFile = ".\CmdletConfig\Search\WebSearchSettings.xml"
$DSP_QueryRulesConfigFile = ".\CmdletConfig\Search\QueryRules.xml"
$DSP_SearchSchemaConfigFile = ".\CmdletConfig\Search\SearchSchema.xml"

# Util
$DSP_TimerJobsConfigFile = ".\Configuration\TimerJobs.xml"

# SampleContent
$DSP_DataTextFieldsFolderFR = ".\CmdletConfig\SampleContent\Data\FR\TextFields"
$DSP_DataTextFieldsFolderEN = ".\CmdletConfig\SampleContent\Data\EN\TextFields"
$DSP_DataURLFieldsFolderFR = ".\CmdletConfig\SampleContent\Data\FR\URLFields"
$DSP_DataURLFieldsFolderEN = ".\CmdletConfig\SampleContent\Data\EN\URLFields"
$DSP_DataTaxonomyFieldsFolderNewsFR = ".\CmdletConfig\SampleContent\Data\FR\TaxonomyFieldsNews"
$DSP_DataTaxonomyFieldsFolderNewsEN = ".\CmdletConfig\SampleContent\Data\EN\TaxonomyFieldsNews"
$DSP_DataHTMLFieldsFolderFR = ".\CmdletConfig\SampleContent\Data\FR\HTMLFields"
$DSP_DataHTMLFieldsFolderEN = ".\CmdletConfig\SampleContent\Data\EN\HTMLFields"
$DSP_DataTaxonomyFieldsFolderStaticFR = ".\CmdletConfig\SampleContent\Data\FR\TaxonomyFieldsStatic"
$DSP_DataTaxonomyFieldsFolderStaticEN = ".\CmdletConfig\SampleContent\Data\EN\TaxonomyFieldsStatic"
$DSP_DataImageFieldsFolderFR = ".\CmdletConfig\SampleContent\Data\FR\ImageFields"
$DSP_DataImageFieldsFolderEN = ".\CmdletConfig\SampleContent\Data\EN\ImageFields"
$DSP_DataImageUFCFieldsFolderFR = ".\CmdletConfig\SampleContent\Data\FR\ImageUFCFields"
$DSP_DataNumberFieldsFR = ".\CmdletConfig\SampleContent\Data\FR\NumberFields"
$DSP_DataImagesLibraryName = "Images de la collection de sites"

$DSP_SampleDataFRConfigFile = ".\CmdletConfig\SampleContent\DataFR.xml"
$DSP_SampleDataENConfigFile = ".\CmdletConfig\SampleContent\DataEN.xml"
