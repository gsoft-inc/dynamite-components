#
# Module 'Dynamite.PowerShell.Toolkit'
# Generated by: GSoft, Team Dynamite.
# Generated on: 10/24/2013
# > GSoft & Dynamite : http://www.gsoft.com
# > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
# > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
#

<#
	.SYNOPSIS
		Add the Managed Properties base on the definitions in the XML input

	.DESCRIPTION
		Add the Managed Properties base on the definitions in the XML input

    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
    
	.PARAMETER  XmlPath
		A path to the XML file defining the Properties to insert. Here's the schema:
    
    <?xml version="1.0" encoding="utf-8"?>
    <Properties>
      <Property Name="owstaxIdDynamiteLanguage" Type="1" FullTextQueriable="true" Queryable="true" Retrievable="true" Searchable="true" Refinable="true" SafeForAnonymous="true" >
        <CrawledProperties>
          <CrawledProperty Name="ows_DynamiteLanguage" Type="1"/>
          <CrawledProperty Name="ows_taxId_DynamiteLanguage" Type"1"/>
        </CrawledProperties>
      </Property>
      ...
    </Properties>
    
	.PARAMETER  SearchServiceApplicationName
		The Name of the Search Service Application

	.EXAMPLE
		PS C:\> Add-DSPMetadataManagedPropertiesByKeyword -XmlPath ./schema.xml -SearchServiceApplicationName "Search Service Application"

	.INPUTS
		System.String,System.String

	.OUTPUTS
		Nothing (Logging when -Verbose)
        
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
    
  .NOTES
   Type Reference
    1 = Text
    2 = Integer
    3 = Decimal
    4 = DateTime
    5 = YesNo
    6 = Binary
    7 = Double
   
   Naming Conventions: (as per http://technet.microsoft.com/en-us/library/jj613136.aspx)

    Crawled Property :
    * Spaces are removed from the site column name, and then the following prefixes are added to the site column name to create the crawled property name:
    	* For site columns of type Publishing HTML and Multiple line of text: ows_r_<four letter code>_
    	* For site columns of type Managed Metadata: ows_taxId_
    	* For all other site column types: ows_q_<four letter code>_
    Managed Property :
    * Spaces are removed from the site column name, and the following items are added to the site column name to create the managed property name:
    	* For all site columns of type Managed Metadata, the following prefix is added: owstaxId
    	* For all other site column types, the following suffix is added: OWS <four letter code>

    Examples :
    	
    Site column type                    Crawled property name        Managed property name
    _____________________________________________________________________________________
    Single line of text                 ows_q_TEXT_SiteColumnName    SiteColumnNameOWSTEXT
    Multiple lines of text              ows_r_MTXT_SiteColumnName    SiteColumnNameOWSMTXT
    Choice                              ows_q_CHCS_SiteColumnName    SiteColumnNameOWSCHCS
    Choice (allow multiple selections)  ows_q_CHCM_SiteColumnName    SiteColumnNameOWSCHCM
    Number                              ows_q_NMBR_SiteColumnName    SiteColumnNameOWSNMBR
    Currency                            ows_q_CURR_SiteColumnName    SiteColumnNameOWSCURR
    Date and Time                       ows_q_DATE_SiteColumnName    SiteColumnNameOWSDATE
    Yes/No                              ows_q_BOOL_SiteColumnName    SiteColumnNameOWSBOOL
    Person or Group                     ows_q_USER_SiteColumnName    SiteColumnNameOWSUSER
    Hyperlink or Picture                ows_q_URLH_SiteColumnName    SiteColumnNameOWSURHL
    Publishing HTML                     ows_r_HTML_SiteColumnName    SiteColumnNameOWSHTML
    Publishing Image                    ows_q_IMGE_SiteColumnName    SiteColumnNameOWSIMGE
    Publishing Link                     ows_q_LINK_SiteColumnName    SiteColumnNameOWSLINK
    Managed Metadata                    ows_taxId_SiteColumnName    owstaxIdSiteColumnName
    Integer*                            ows_q_INTG_SiteColumnName    SiteColumnNameOWSINTG
    GUID*                               ows_q_GUID_SiteColumnName    SiteColumnNameOWSGUID
    Grid Choice*                        ows_q_CHCG_SiteColumnName    SiteColumnNameOWSCHCG
    ContentTypeIDFieldType*             ows_q_CTID_SiteColumnName    SiteColumnNameOWSCTID
    SPS average rating                  ows_q_RAVG_SiteColumnName    SiteColumnNameOWSRAVG
    SPS rating count                    ows_q_RCNT_SiteColumnName    SiteColumnNameOWSRCNT
#>
function Add-DSPMetadataManagedPropertiesByXml() {
	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[string]$XmlPath,
		
		[Parameter(Mandatory=$true, Position=1)]
		[string]$SearchServiceApplicationName
	)	
	Write-Verbose "Entering Add-DSPMetadataManagedPropertiesByXml with following Search Service : $SearchServiceApplicationName"
	
	$Properties = [xml](Get-Content $XmlPath)
	
	if (($Properties -ne $null) -and ($SearchServiceApplicationName -ne $null))
	{	
		$SearchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName

		if ($SearchServiceApplication -eq $null)
		{
			Write-Host ([string]::Format("The Search Service Application named {0} do not exist", $SearchServiceApplicationName)) -ForegroundColor Magenta
		}
		else
		{
			Write-Host ([string]::Format("Search Service Application named {0} was found.", $SearchServiceApplicationName)) -ForegroundColor green

			foreach ($xmlProperty in $Properties.Properties.Property)
			{	
				$mp = Get-SPEnterpriseSearchMetadataManagedProperty -Identity $xmlProperty.Name -SearchApplication $SearchServiceApplication -ErrorAction SilentlyContinue

				
				# Get Parameters
				$FullTextQueriable = Get-BooleanValue -Value $xmlProperty.FullTextQueriable -DefaultValue $true
				$Queryable = Get-BooleanValue -Value $xmlProperty.Queryable -DefaultValue $true
				$Retrievable = Get-BooleanValue -Value $xmlProperty.Retrievable -DefaultValue $true
                $Sortable = Get-BooleanValue -Value $xmlProperty.Sortable -DefaultValue $false
				$SafeForAnonymous = Get-BooleanValue -Value $xmlProperty.SafeForAnonymous -DefaultValue $true
				$Refinable = Get-BooleanValue -Value $xmlProperty.Refinable -DefaultValue $true
				$RespectPriority = Get-BooleanValue -Value $xmlProperty.RespectPriority -DefaultValue $false
				$ForceCreation = Get-BooleanValue -Value $xmlProperty.ForceCreation -DefaultValue $false
                $FullTextIndex= $xmlProperty.FullTextIndex
                $Context= $xmlProperty.Context
					
				if (($mp -eq $null) -or $ForceCreation)
				{	
					if ($ForceCreation -and ($mp -ne $null)){
						if ($mp.DeleteDisallowed){
							Write-Host ([string]::Format("Delete is disallowed on the Managed Property `"{0}`".",  $xmlProperty.Name)) -ForegroundColor Red
						} else {
							$mp.DeleteAllMappings();
							$mp.Delete();
							Write-Host "Managed Property named " -nonewline -ForegroundColor yellow
							Write-Host $xmlProperty.Name -nonewline -ForegroundColor Magenta
							Write-Host " was successfully removed." -ForegroundColor yellow
						}
					}
					
					$mp = New-SPEnterpriseSearchMetadataManagedProperty -SearchApplication $SearchServiceApplication -Name $xmlProperty.Name -Type $xmlProperty.Type -FullTextQueriable $FullTextQueriable -NameNormalized $true -Queryable $Queryable -RemoveDuplicates $false -Retrievable $Retrievable -SafeForAnonymous $SafeForAnonymous -RespectPriority $RespectPriority
					Write-Host "Managed Property named " -nonewline -ForegroundColor green
					Write-Host $xmlProperty.Name -nonewline -ForegroundColor Magenta
					Write-Host " was successfully created." -ForegroundColor green
				}
				else
				{
					Write-Host ([string]::Format("The Managed Property with the name `"{0}`" already exists.",  $xmlProperty.Name)) -ForegroundColor Magenta
				}
						
				$mp.Refinable = $Refinable
				$mp.Queryable = $Queryable
				$mp.Retrievable = $Retrievable
				$mp.SafeForAnonymous = $SafeForAnonymous
				$mp.RespectPriority = $RespectPriority
				$mp.Sortable= $Sortable
                $mp.FullTextIndex = $FullTextIndex
                $mp.Context = $Context

				if ($Sortable -eq $true)
				{
					$mp.SortableType=[Microsoft.Office.Server.Search.Administration.SortableType]::Enabled
				}
				
				$mp.Update()

				# Set Associated Group
				if ($xmlProperty.CrawledProperties -ne $null)
				{
					foreach ($xmlCrawledProperty in $xmlProperty.CrawledProperties.CrawledProperty)
					{
						$cp = Get-SPEnterpriseSearchMetadataCrawledProperty -SearchApplication $SearchServiceApplication -Name $xmlCrawledProperty.Name
						
						if ($cp -eq $null)
						{							
							Write-Host ([string]::Format("The crawled property named {0} do not exist.", $xmlCrawledProperty.Name)) -ForegroundColor green
						}
						else
						{
							$mapping = New-SPEnterpriseSearchMetadataMapping -CrawledProperty $cp -ManagedProperty $mp -SearchApplication $SearchServiceApplication
							Write-Host "Mapping for crawled property named " -nonewline -ForegroundColor green
							Write-Host $cp.Name -nonewline 
							Write-Host " was successfully created." -ForegroundColor green
						}		
					}
				}
			}
		}
	}
	else
	{
		Write-Host "There is no managed properties to add." -ForegroundColor green
	}
}

function Remove-DSPMetadataManagedPropertiesByXml() {
	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[string]$XmlPath,
		
		[Parameter(Mandatory=$true, Position=1)]
		[string]$SearchServiceApplicationName
	)	
	Write-Verbose "Entering Remove-DSPMetadataManagedPropertiesByXml with following Search Service : $SearchServiceApplicationName"
	
	$Properties = [xml](Get-Content $XmlPath)
	
	if (($Properties -ne $null) -and ($SearchServiceApplicationName -ne $null))
	{	
		$SearchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName

		if ($SearchServiceApplication -eq $null)
		{
			Write-Host ([string]::Format("The Search Service Application named {0} do not exist", $SearchServiceApplicationName)) -ForegroundColor Magenta
		}
		else
		{
			Write-Host ([string]::Format("Search Service Application named {0} was found.", $SearchServiceApplicationName)) -ForegroundColor green

			foreach ($xmlProperty in $Properties.Properties.Property)
			{	
				$mp = Get-SPEnterpriseSearchMetadataManagedProperty -Identity $xmlProperty.Name -SearchApplication $SearchServiceApplication -ErrorAction SilentlyContinue

				if ($mp -ne $null)
				{					
					Remove-SPEnterpriseSearchMetadataManagedProperty $mp
					Write-Host "Managed Property named " -nonewline -ForegroundColor green
					Write-Host $xmlProperty.Name -nonewline -ForegroundColor Magenta
					Write-Host " was successfully deleted." -ForegroundColor green				
				}
				else
				{
					Write-Host ([string]::Format("The Managed Property with the name `"{0}`" doesn't exists.",  $xmlProperty.Name)) -ForegroundColor Magenta
				}
			}
		}
	}
	else
	{
		Write-Host "There is no managed properties to add." -ForegroundColor green
	}
}

<#
	.SYNOPSIS
		Remove the Managed Properties based on a search on a common keyword.

	.DESCRIPTION
		Remove the Managed Properties based on a search on a common keyword.

    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
    
	.PARAMETER  Keyword
		A keyword common in all the Managed Properties names. Usually a prefix.
    When you create the SiteColumn, a good practice is to prefix them. This come helpfull here, when you need to remove a batch of Managed Properties to recreate them with the proper type.

	.PARAMETER  SearchServiceApplicationName
		The Name of the Search Service Application

	.EXAMPLE
		PS C:\> Remove-DSPMetadataManagedPropertiesByKeyword -Keyword "myPrefix" -SearchServiceApplicationName "Search Service Application"

	.INPUTS
		System.String,System.String

	.OUTPUTS
		Nothing (Logging when -Verbose)
        
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
#>
function Remove-DSPMetadataManagedPropertiesByKeyword() {

	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[string]$Keyword,
		
		[Parameter(Mandatory=$true, Position=1)]
		[string]$SearchServiceApplicationName
	)	
	Write-Verbose "Entering Add-DSPMetadataManagedPropertiesByXml with following Search Service : $SearchServiceApplicationName"
	
	$SearchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName
	
	$ManagedPropeties = Get-SPEnterpriseSearchMetadataManagedProperty -SearchApplication $SearchServiceApplication | where { $_.Name -like "*$Keyword*" }

	foreach ($ManagedProperty in $ManagedPropeties) 
	{
		$Mappings = Get-SPEnterpriseSearchMetadataMapping -SearchApplication $SearchServiceApplication -ManagedProperty $ManagedProperty

		Write-Host "Deleting mappings for Managed Property" $ManagedProperty.Name

		foreach ($Mapping in $Mappings)
		{
			Remove-SPEnterpriseSearchMetadataMapping -SearchApplication $SearchServiceApplication -Identity $Mapping -Confirm:$false 
		}
		
		Write-Host "Deleting Managed Property" $ManagedProperty.Name
		Remove-SPEnterpriseSearchMetadataManagedProperty -SearchApplication $SearchServiceApplication -Identity $ManagedProperty.Name -Confirm:$false 
	}
}

<#
	.SYNOPSIS
		Method to add file type to the index

	.DESCRIPTION
		Method to add file type to the index

    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
    
	.PARAMETER  Extensions
		A list of Extensions ex: @("jpg", "jpeg", "png", "gif", "bmp")

	.PARAMETER  SearchServiceApplicationName
		The Name of the Search Service Application

	.EXAMPLE
		PS C:\> Add-DSPCrawlExtension -Extensions @("jpg", "jpeg", "png", "gif", "bmp") -SearchServiceApplicationName "Search Service Application"

	.INPUTS
		System.String[] ex: @("jpg", "jpeg", "png", "gif", "bmp"), System.String

	.OUTPUTS
		No output (Logging when -Verbose)
        
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
#>
Function Add-DSPCrawlExtension()
{
	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[string[]]$Extensions,
		
		[Parameter(Mandatory=$true, Position=1)]
		[string]$SearchServiceApplicationName
	)
  
	$SearchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName
	
	If ($SearchServiceApplication)
	{	
		Write-Verbose "We found the following Search Service Application: $searchApplication"
		Foreach ($extension in $extensions)
		{
			Try
			{
				Get-SPEnterpriseSearchCrawlExtension -SearchApplication $SearchServiceApplication -Identity $extension -ErrorAction Stop | Out-Null
				Write-Verbose "'$extension' file extension already set for $($searchApplication.DisplayName)."
			}
			Catch
			{
				New-SPEnterpriseSearchCrawlExtension -SearchApplication $SearchServiceApplication -Name $extension | Out-Null
				Write-Verbose "'$extension' extension for $($searchApplication.DisplayName) now set."
			}
		}
	}
	Else 
	{
		Write-Verbose "No search application found."
	}
}

Function Start-DSPContentSourceCrawl()
{
	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		[string]$ContentSourceName,
		
		[Parameter(Mandatory=$true, Position=1)]
		[string]$SearchServiceApplicationName,
		
		[Parameter(Mandatory=$false, Position=2)]
		[switch]$FullCrawl
	)
  
	$SearchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName
	
	If ($SearchServiceApplication)
	{	
		Write-Verbose "We found the following Search Service Application '$searchApplication'"
		$ContentSource = $SearchServiceApplication | Get-SPEnterpriseSearchCrawlContentSource -Identity $ContentSourceName
		Write-Verbose "Starting crawl for content source '$ContentSourceName'"
		if ($ContentSource.CrawlStatus  -eq "Idle")
		{        
                if ($FullCrawl){
                	Write-Host "Starting Full Crawl"
					$ContentSource.StartFullCrawl()    
				}
				else{
                	Write-Host "Starting Incremental Crawl"
					$ContentSource.StartIncrementalCrawl()    
				}
				
                if ($ContentSource.CrawlStatus  -eq "Paused"){        
	                $ContentSource.ResumeCrawl()    
	                Write-Host "Resuming Crawl"
                }
		}
		
		return $ContentSource
	}
	Else 
	{
		Write-Verbose "No search application found."
	}
}

Function Wait-DSPContentSourceCrawl()
{
	[CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, ValueFromPipeline=$true)]
		[Microsoft.Office.Server.Search.Administration.ContentSource]$ContentSource
	)
  
	Write-Verbose "Waiting for crawl to finish on content source '$ContentSourceName'"
	$status = $ContentSource.CrawlStatus
	Write-Host "Crawl status: '$status'." -NoNewline
	if (($ContentSource.CrawlStatus  -eq "CrawlStarting") -or ($ContentSource.CrawlStatus  -eq "CrawlingFull") -or ($ContentSource.CrawlStatus  -eq "CrawlingIncremental"))
	{        
		while ($ContentSource.CrawlStatus -ne "Idle"){
			if($status -ne $ContentSource.CrawlStatus){
				$status = $ContentSource.CrawlStatus
				Write-Host "."
				Write-Host "Crawl status: '$status'." -NoNewline
			}
			else{
				Write-Host "." -NoNewline
			}
			
			sleep 2
		}
		
		Write-Host "."
	}
	
	Write-Host "Done crawling content source."
}

<#
	.SYNOPSIS
		Commandlet to create search result types

	.DESCRIPTION
		Creates a new result type
    --------------------------------------------------------------------------------------
    Module 'Dynamite.PowerShell.Toolkit'
    by: GSoft, Team Dynamite.
    > GSoft & Dynamite : http://www.gsoft.com
    > Dynamite Github : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    > Documentation : https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    --------------------------------------------------------------------------------------
   
    .NOTES
         Here is the Structure XML schema.

        <Configuration>
	        <Web Url="http://<site_url>" Ssa="Search Application Service">
		        <ResultType Name="New Result Type" RulePriority="1" ResultSourceName="My Result Source" DisplayTemplateUrl="~sitecollection/_catalogs/masterpage/Display Templates/Search/<Template_name>.js" DisplayProperties="OriginalPath,ListID,Title,Path,ListItemID,PictureURL">
			        <!-- Operator IsEqual | NotEqual | Contains | NotContains | LessThan | GreaterThan | StartsWith -->
			        <Rule ManagedProperty="Title" Operator="Contains">
				        <Values>
					        <Value>Value 1</Value>
					        <Value>Value 2</Value>
				        </Values>
			        </Rule>
		        </ResultType>
		        <ResultType Name="New Result Type 2" RulePriority="2" ResultSourceName="Another result source" DisplayTemplateUrl="~sitecollection/_catalogs/masterpage/Display Templates/Search/<Template_name>.js" DisplayProperties="OriginalPath">
		        </ResultType>		
	        </Web>
        </Configuration>

	.PARAMETER  XmlPath (Mandatory)
		Physical path of the XML configuration file.

	.PARAMETER  Delete (Optionnal)
		Delete the actual configuration

	.EXAMPLE
		PS C:\> Set-DSPResultTypesByXml "D:\ResultTypes.xml" 
        PS C:\> Set-DSPResultTypesByXml "D:\ResultTypes.xml" -Delete

	.OUTPUTS
		n/a. 
    
  .LINK
    GSoft, Team Dynamite on Github
    > https://github.com/GSoft-SharePoint
    
    Dynamite PowerShell Toolkit on Github
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit
    
    Documentation
    > https://github.com/GSoft-SharePoint/Dynamite-PowerShell-Toolkit/wiki
    
#>
function Set-DSPResultTypesByXml
{
	[CmdletBinding()] 
	param
	(
		[Parameter(ParameterSetName="Default", Mandatory=$true, Position=0)]
		[string]$XmlPath,

		[Parameter(ParameterSetName="Default", Mandatory=$false, Position=1)]
		[switch]$Delete
	)
	
	$Config = [xml](Get-Content $XmlPath -Encoding UTF8)
	
    # Process all 
	$Config.Configuration.Web | ForEach-Object {
	
		$web = Get-SPWeb -Identity $_.Url
		$ssa = $_.Ssa
        $ssaProxyName = $_.ProxyName
		
		$_.ResultType | ForEach-Object {
		
			Set-DSPWebResultType $web $_ $ssa $ssaProxyName $Delete
		}
    }
}	

function Set-DSPWebResultType {
    [CmdletBinding()]
	Param
	(
        [Parameter(Mandatory=$true, Position=0)]
		[Microsoft.SharePoint.SPWeb]$Web,

		[Parameter(Mandatory=$true, Position=1)]
		[System.Xml.XmlElement]$ResultType,
		
		[Parameter(Mandatory=$false, Position=2)]
		$SearchServiceApplicationName,

		[Parameter(Mandatory=$false, Position=3)]
		$SearchServiceApplicationProxyName,

		[Parameter(Mandatory=$false, Position=4)]
		[switch]$Delete
	)
	
    # Get result type configuration
    $rulePriority = $ResultType.RulePriority 
	$resultSourceName = $ResultType.ResultSourceName 
	$displaytemplateUrl = $ResultType.DisplayTemplateUrl 
	$resultTypeName = $ResultType.Name 
    $displayProperties = $ResultType.DisplayProperties
	$webUrl = $Web.Url
	
	Write-Verbose "Processing result types on $webUrl.."
	
	$ssa = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName
	
	$ruleCollection = Get-SPEnterpriseSearchPropertyRuleCollection
	
    if($ResultType.HasChildNodes)
    {
	    $ResultType.Rule | ForEach-Object {
	
		    $rule = Get-SPEnterpriseSearchPropertyRule -PropertyName $_.ManagedProperty -Operator $_.Operator
		
		    $_.Values.Value  | ForEach-Object {
		
			    $rule.AddValue($_)
		    }
		
		    $ruleCollection.Add( $rule )
	    }
	}

	$tenantOwner = Get-SPEnterpriseSearchOwner -Level SPWeb -SPWeb $Web	

    if ($SearchServiceApplicationProxyName)
    {
        $svcAppProxy = Get-SPEnterpriseSearchServiceApplicationProxy $SearchServiceApplicationProxyName
    }
    else
    {
        $svcAppProxy = (Get-SPEnterpriseSearchServiceApplicationProxy)[0]
    }

    if($resultSourceName -ne $null)
    {
	    $resultSource = Get-SsaResultSource -ResultSourceName $resultSourceName -SearchServiceApplicationName $SearchServiceApplicationName 
    }
	
	$existingResultTypes = Get-SPEnterpriseSearchResultItemType -Owner $tenantOwner -SearchApplication $ssa | Where-Object {$_.Name -eq $resultTypeName}
		
	if($existingResultTypes -ne $null)
	{
        $existingResultTypes | ForEach-Object {
		    Write-Verbose "`tResult type with name $resultTypeName already exists! Removing result type with name $resultTypeName"
		    Remove-SPEnterpriseSearchResultItemType -Identity $_ -Owner $tenantOwner -SearchApplication $ssa
        }
	}	

    if($Delete -eq $false)
    {
    	Write-Verbose "`tCreating result type with name $resultTypeName..."
        if ($resultSource -ne $null)
        {
    	    New-SPEnterpriseSearchResultItemType -SearchApplicationProxy $svcAppProxy -Name $resultTypeName -Rules $ruleCollection -RulePriority $rulePriority -DisplayProperties $displayProperties -SourceID $resultSource.Id -DisplayTemplateUrl $displaytemplateUrl -Owner $tenantOwner | Out-Null	
        }
        else
        {
            New-SPEnterpriseSearchResultItemType -SearchApplicationProxy $svcAppProxy -Name $resultTypeName -Rules $ruleCollection -RulePriority $rulePriority -DisplayProperties $displayProperties -DisplayTemplateUrl $displaytemplateUrl -Owner $tenantOwner | Out-Null	
        }
    }
} 

function Get-SsaResultSource
{

 [CmdletBinding()]
	Param
	(
		[Parameter(Mandatory=$true, Position=0)]
		$ResultSourceName,
		
        [Parameter(Mandatory=$false, Position=1)]
		$SearchServiceApplicationName
	)

	if($SearchServiceApplicationName)
	{
		$searchServiceApplication = Get-SPEnterpriseSearchServiceApplication -Identity $SearchServiceApplicationName
	}
	else
	{
		# Get the default one
		$searchServiceApplication = Get-SPEnterpriseSearchServiceApplication
	}

	$federationManager = New-Object Microsoft.Office.Server.Search.Administration.Query.FederationManager($searchServiceApplication)

	$searchOwner = Get-SPEnterpriseSearchOwner -Level Ssa

	$resultSource = $federationManager.GetSourceByName($resultSourceName, $searchOwner)
	
	return $resultSource
}