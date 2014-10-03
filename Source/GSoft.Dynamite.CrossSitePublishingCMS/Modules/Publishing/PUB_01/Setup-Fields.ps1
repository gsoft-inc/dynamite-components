# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-Fields.ps1.template
# Description	: Create fields
# -----------------------------------------------------------------------

Write-Warning "Applying Fields configuration..."

# Activate feature on the root web on the authoring site collection
Switch-DSPFeature -Url http://authoring.dynamite.com  -Id 97a3a3ef-5989-46f0-a117-6f489f58a26b


