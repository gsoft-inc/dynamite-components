# ******************************************
# Deployment Mode
# ******************************************
$DSP_IsDistributedEnvironment = "$false"

# ******************************************
# Deployment Configuration 
# ******************************************
$DSP_CUSTOM_PortalSetupSolutionsConfigurationFile = ".\Custom\Custom-Solutions.xml"

# ******************************************
# Application Configuration 
# ******************************************
$DSP_PortalWebAppUrl = "http://HOSTNAME/"
$DSP_PortalPublishingHostNamePath = "http://standard.dynamite.com"
$DSP_PortalDocsHostNamePath = "http://docs.dynamite.com"
$DSP_PortalAdmin = "OFFICE\YOUR.NAME"
$DSP_PortalDatabaseName = "SP2013_Content_Portal"
$DSP_PortalDefaultLanguage = "1033"

# ******************************************
# Container/Service Locator Configuration 
# ******************************************
$DSP_ServiceLocatorAssemblyName = ""

# ******************************************
# Search Configuration 
# ******************************************
$DSP_SearchServiceApplicationName = "Search Service Application"
$DSP_SearchContentSourceName = "Local SharePoint sites"
$DSP_GoogleAnalyticsUA = "UA-XXXXXXXX"
$DSP_EnableSEOFields = $false

# ******************************************
# Multilingualism Configuration 
# ******************************************
$DSP_IsMultilingual = $true
$DSP_VariationsLabels = @('en','fr')
$DSP_SourceLabel = "en"

# ******************************************
# Documents Configuration 
# ******************************************
# By default, pictures are uploaded in the specified pictures library on the authoring root site.
# If you need to upload pictures on another site collection, modify tokens bellow.
$DSP_UploadPicturesInDocCenter = $false
$DSP_PictureLibraryName = "Site Collection Images"

# ******************************************
# Webs Configuration 
# ******************************************
$DSP_PortalAuthoringRootWebs = @('rh','com')

# ******************************************
# Taxonomy Configuration 
# ******************************************
$DSP_UseDefaultTermGroups = $true

# ******************************************
# Common Tokens
# ******************************************
. ./Tokens/Tokens.Common.ps1