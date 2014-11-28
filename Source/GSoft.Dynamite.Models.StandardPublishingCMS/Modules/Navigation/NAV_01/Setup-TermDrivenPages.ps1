# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-TermDrivenPages.ps1.template
# Description	: Set up the term driven pages configuration
# -----------------------------------------------------------------------

Write-Warning "Applying Term Driven Pages configuration..."

# Activate feature on the root web on the publishing site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id ffaf71c4-38dc-4be8-a9b1-2b4dc5b46efe
