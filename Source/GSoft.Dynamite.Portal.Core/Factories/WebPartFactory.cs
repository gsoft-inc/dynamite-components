using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Portal.Contracts.Factories;
using GSoft.Dynamite.WebParts;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint;
using GSoft.Dynamite.Portal.Contracts.WebParts;
using System;

namespace GSoft.Dynamite.Portal.Core.Factories
{
    /// <summary>
    /// Factory for the web parts
    /// </summary>
    public class WebPartFactory : IWebPartFactory
    {
        private readonly WebPartHelper webPartHelper;
        private readonly Func<IContentBySearchSchedule> contentBySearchScheduleFactoryMethod;
        private readonly Func<IContextualNavigation> contextualNavigationFactoryMethod;
        private readonly Func<IChildNodes> childNodesFactoryMethod;
        private readonly Func<IResultScriptSchedule> resultScriptScheduleFactoryMethod;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="webPartHelper">The web part helper</param>
        public WebPartFactory(WebPartHelper webPartHelper,
            Func<IContentBySearchSchedule> contentBySearchScheduleFactoryMethod,
            Func<IContextualNavigation> contextualNavigationFactoryMethod,
            Func<IChildNodes> childNodesFactoryMethod,
            Func<IResultScriptSchedule> resultScriptScheduleFactoryMethod
            )
        {
            this.webPartHelper = webPartHelper;
            this.contentBySearchScheduleFactoryMethod = contentBySearchScheduleFactoryMethod;
            this.contextualNavigationFactoryMethod = contextualNavigationFactoryMethod;
            this.childNodesFactoryMethod = childNodesFactoryMethod;
            this.resultScriptScheduleFactoryMethod = resultScriptScheduleFactoryMethod;
        }

        /// <summary>
        /// Add a web part in specified page which displays info about current navigation node
        /// </summary>
        /// <param name="listItem">the current page</param>
        /// <param name="webPartZoneName">the web part zone name</param>
        /// <param name="webPartZoneIndex">the web part zone index</param>
        public void AddNodeDescriptionWebPart(SPListItem listItem, string webPartZoneName, int webPartZoneIndex)
        {
             var NodeDescriptionPart = new ContentBySearchWebPart()
            {
                Title = "Current Node Title and Description",
                ChromeType = PartChromeType.None,
                PropertyMappings = "Link URL{URL du lien}:,Line 1{Ligne 1}:Title,Line 2{Ligne 2}:'PublishingPageContentOWSHTML',FileExtension,SecondaryFileExtension",
                ShowAdvancedLink = false,
                NumberOfItems = 1,
                ResultTypeId = string.Empty,
                ItemTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Item_TwoLines.js",
                QueryGroupName = "NodeDescription",
                ShowPaging = false,
                ShowResultCount = false,
                ShowLanguageOptions = false
            };

            var querySettings = new DataProviderScriptWebPart
            {
                PropertiesJson = NodeDescriptionPart.DataProviderJSON
            };
            querySettings.Properties["SourceID"] = "ed4c74cf-d613-4e2d-ad5b-115ce63f0374";
            querySettings.Properties["SourceName"] = "Single Node Description";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";
            NodeDescriptionPart.DataProviderJSON = querySettings.PropertiesJson;

            this.webPartHelper.AddWebPartToZone(listItem, NodeDescriptionPart, webPartZoneName, webPartZoneIndex);
        }

        public IContentBySearchSchedule CreateContentBySearchScheduleWebPart()
        {
            return this.contentBySearchScheduleFactoryMethod();
        }

        public IContextualNavigation CreateContextualNavigationWebPart()
        {
            return this.contextualNavigationFactoryMethod();
        }

        public IChildNodes CreateChildNodesWebPart()
        {
            return this.childNodesFactoryMethod();
        }

        public IResultScriptSchedule CreateResultScriptScheduleWebPart()
        {
            return this.resultScriptScheduleFactoryMethod();
        }
    }
}
