using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using Autofac;
using GSoft.Dynamite.Lists;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Publishing.SP.Features.CrossSitePublishingCMS_SearchRESTAnonymous
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("91a67c8d-3b14-4242-ba33-199f25cc98ff")]
    public class CrossSitePublishingCMS_SearchRESTAnonymousEventReceiver : SPFeatureReceiver
    {
        private readonly string data = @"<QueryPropertiesTemplate xmlns=""http://www.microsoft.com/sharepoint/search/KnownTypes/2008/08"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    <QueryProperties i:type=""KeywordQueryProperties"">
        <EnableStemming>true</EnableStemming>
        <FarmId>00000000-0000-0000-0000-000000000000</FarmId>
        <SiteId>00000000-0000-0000-0000-000000000000</SiteId>
        <WebId>00000000-0000-0000-0000-000000000000</WebId>
        <IgnoreAllNoiseQuery>true</IgnoreAllNoiseQuery>
        <KeywordInclusion>AllKeywords</KeywordInclusion>
        <SummaryLength>180</SummaryLength>
        <TrimDuplicates>true</TrimDuplicates>
        <WcfTimeout>120000</WcfTimeout>
        <Properties xmlns:a=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
            <a:KeyValueOfstringanyType>
                <a:Key>_IsEntSearchLicensed</a:Key>
                <a:Value i:type=""b:boolean"" xmlns:b=""http://www.w3.org/2001/XMLSchema"">true</a:Value>
            </a:KeyValueOfstringanyType>
            <a:KeyValueOfstringanyType>
                <a:Key>EnableSorting</a:Key>
                <a:Value i:type=""b:boolean"" xmlns:b=""http://www.w3.org/2001/XMLSchema"">true</a:Value>
            </a:KeyValueOfstringanyType>
            <a:KeyValueOfstringanyType>
                <a:Key>MaxKeywordQueryTextLength</a:Key>
                <a:Value i:type=""b:int"" xmlns:b=""http://www.w3.org/2001/XMLSchema"">4096</a:Value>
            </a:KeyValueOfstringanyType>
            <a:KeyValueOfstringanyType>
                <a:Key>TryCache</a:Key>
                <a:Value i:type=""b:boolean"" xmlns:b=""http://www.w3.org/2001/XMLSchema"">true</a:Value>
            </a:KeyValueOfstringanyType>
        </Properties>
        <PropertiesContractVersion>15.0.0.0</PropertiesContractVersion>
        <EnableFQL>false</EnableFQL>
        <EnableSpellcheck>Suggest</EnableSpellcheck>
        <EnableUrlSmashing>true</EnableUrlSmashing>
        <IsCachable>false</IsCachable>
        <MaxShallowRefinementHits>100</MaxShallowRefinementHits>
        <MaxSummaryLength>185</MaxSummaryLength>
        <MaxUrlLength>2048</MaxUrlLength>
        <SimilarType>None</SimilarType>
        <SortSimilar>true</SortSimilar>
        <TrimDuplicatesIncludeId>0</TrimDuplicatesIncludeId>
        <TrimDuplicatesKeepCount>1</TrimDuplicatesKeepCount>
    </QueryProperties>
    <WhiteList xmlns:a=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
        <a:string>RowLimit</a:string>
        <a:string>SortList</a:string>
        <a:string>StartRow</a:string>
        <a:string>RefinementFilters</a:string>
        <a:string>Culture</a:string>
        <a:string>RankingModelId</a:string>
        <a:string>TrimDuplicatesIncludeId</a:string>
        <a:string>ReorderingRules</a:string>
        <a:string>EnableQueryRules</a:string>
        <a:string>HiddenConstraints</a:string>
        <a:string>QueryText</a:string>
        <a:string>QueryTemplate</a:string>
        <a:string>SelectProperties</a:string>
        <a:string>SourceID</a:string>
    </WhiteList>
</QueryPropertiesTemplate>";

        /// <summary>
        /// Event handler called when the feature is activated
        /// </summary>
        /// <param name="properties">The event arguments</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;

            if (site != null)
            {
                using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var listHelper = featureScope.Resolve<IListHelper>();
                    var fileHelper = featureScope.Resolve<Files.IFileHelper>();

                    var listTitle = "QueryPropertiesTemplate";
                    listHelper.EnsureList(site.RootWeb, listTitle, "List holding the Query Properties template used by Search REST API.", SPListTemplateType.DocumentLibrary);

                    var doc = new XmlDocument();

                    using (var stream = new MemoryStream())
                    {
                        doc.LoadXml(this.data);
                        doc.DocumentElement["QueryProperties"]["FarmId"].InnerText = site.WebApplication.Farm.Id.ToString();
                        doc.DocumentElement["QueryProperties"]["SiteId"].InnerText = site.ID.ToString();
                        doc.DocumentElement["QueryProperties"]["WebId"].InnerText = site.RootWeb.ID.ToString();
                        doc.Save(stream);

                        var fileInfo = new Files.FileInfo("queryparametertemplate.xml", stream);

                        fileHelper.EnsureFile(site.RootWeb, listTitle, fileInfo);
                    }
                }
            }
        }
    }
}
