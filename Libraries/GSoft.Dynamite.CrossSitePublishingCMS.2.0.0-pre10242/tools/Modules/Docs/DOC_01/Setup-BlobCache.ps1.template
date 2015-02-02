# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-BlobCache.ps1.template
# Description	: Configure the Blob Cache on IIS
# -----------------------------------------------------------------------

Write-Warning "Configuring the Blob Cache..."

# Remove previous BLOB cache modifications (so we don't clog up the web config modifications API)
Disable-DSPBlobCache -WebApplication "[[DSP_PortalWebAppUrl]]"

# Configure and enable the BLOB cache
Enable-DSPBlobCache -WebApplication "[[DSP_PortalWebAppUrl]]"