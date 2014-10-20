# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-DisplayTemplates.ps1.template
# Description	: Create display templates
# -----------------------------------------------------------------------

Write-Warning "Applying Display Templates configuration..."

# Activate feature on the root web on the publishing site collection
Switch-DSPFeature -Url http://intranet.dynamite.com  -Id d96b6f0d-8536-4367-bf3f-4a4a9fa286cb
