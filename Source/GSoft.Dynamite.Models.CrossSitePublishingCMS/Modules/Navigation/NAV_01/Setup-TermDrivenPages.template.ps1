# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-TermDrivenPages.ps1.template
# Description	: Set up the term driven pages configuration
# -----------------------------------------------------------------------

Write-Warning "Applying Term Driven Pages configuration..."

# Activate feature on the root web on the publishing site collection
Initialize-DSPFeature -Url [[DSP_PortalPublishingSiteUrl]]  -Id [[DSP_CrossSitePublishingCMS_NAV_TermDrivenPages]]

# For cross-site publishing scenario, activate the feature on the source web
[[DSP_PublishingSourceRootWebUrls]] | Foreach-Object {
    
    if ($_ -ne $null) {
        Initialize-DSPFeature -Url $_  -Id [[DSP_CrossSitePublishingCMS_NAV_TermDrivenPages]]
    }
}

# For cross-site publishing scenario, activate the feature on the target web(s)
[[DSP_PublishingTargetRootWebUrls]] | Foreach-Object {

    if ($_ -ne $null) {
        Initialize-DSPFeature -Url $_ -Id [[DSP_CrossSitePublishingCMS_NAV_TermDrivenPages]]
    }
}
