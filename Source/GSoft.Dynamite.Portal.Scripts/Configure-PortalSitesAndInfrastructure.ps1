# --------------------------------------------------------------------------------
# Copyright		: GSoft @2014
# Project		: GSoft Dynamite Portal
# File          : Configure-PortalSitesAndInfrastructure.ps1
# Description	: Uses the configurable Tokens and CmdletConfig XML inputs
#				  to provision the requested Portal-driven site collections
#				  and configure all the related cross-site publishing settings
#				  and infrastructure (search, catalogs, etc.)
# --------------------------------------------------------------------------------

# You can send in a -Force parameter to delete all existing sites.
# Otherwise, if any of the sites already exists, the configuration
# will skip site deletion (and subsequent setup steps may fail
# unpredictably).
param([switch] $Force=$false)

# Verbose preference
$VerbosePreference ="Continue"

# Unblock files if they're from another computer
gci -Recurse | Unblock-File

Update-DSPTokens -UseHostName

# 0- Fix acces denied error for content type deployement
./Cmdlets/Util/Fix-AccesDenied.ps1

# 3- Create a new SPSite structure
if ($Force) {
	./Cmdlets/SitesAndFeatures/New-SPSiteStructure.ps1 -Force
} else {
	./Cmdlets/SitesAndFeatures/New-SPSiteStructure.ps1
}

# 5- Remove term set groups before importing them
./Cmdlets/Taxonomy/Remove-SPTermGroups.ps1

# 6- Import taxonomy terms
./Cmdlets/Taxonomy/Import-SPTerms.ps1

# 8- Configure Term Driven Settings
./Cmdlets/Navigation/New-SPTermDrivenPages.ps1

# 9- Set managed navigation settings
./Cmdlets/Navigation/Set-SPManagedNavigation.ps1

# 10- Enable Blob cache for image rendition
./Cmdlets/Util/Enable-SPBlobCache.ps1

# 11- Activate Features in a new Shell
./Cmdlets/SitesAndFeatures/Initialize-SPFeatures.ps1

# 12- Fix Variation English label hierarchy
./Cmdlets/Util/Fix-Variations.ps1

# 12.5 Set Variation Timer-job to 5min
./Cmdlets/Util/Set-SPTimerJobs.ps1

# 13- Create Sample items
./Cmdlets/SampleContent/New-SPSampleContent.ps1

# 14- Crawl content
./Cmdlets/Search/Start-SPSearchCrawl.ps1

# 15- Update Search Schema
./Cmdlets/Search/New-SPSearchSchema.ps1

# 16- Create Catalog Connections 
./Cmdlets/Navigation/New-SPCatalogConnections.ps1

# 17- Create Result Sources
./Cmdlets/Search/New-SPResultSources.ps1

# 18 - Create Search Result Types
./Cmdlets/Search/New-SPResultTypes.ps1

# 19 - Set the default search page
./Cmdlets/Search/New-SPWebSearchSettings.ps1