# -----------------------------------------------------------------------
# Copyright		: GSoft @2014
# Model  		: Cross Site Publishing CMS
# File          : Setup-PropertyBag.ps1.template
# Description	: Setup Property Bag Mappings
# -----------------------------------------------------------------------

# Mappings from authoring to publishing site collection
$HashTable = [[DSP_CrossSiteMappings]]

$HashTable.Keys | Foreach-Object { 

	# Add the property bag value
	Set-DSPWebProperty -Url $_ -Key "DSP_AssociatedPublishingSite" -Value $HashTable.Item($_) 
}
