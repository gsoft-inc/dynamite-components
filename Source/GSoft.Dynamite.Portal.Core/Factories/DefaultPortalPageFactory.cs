using GSoft.Dynamite.Portal.Contracts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.WebParts;
using GSoft.Dynamite.Setup;
using System.Web.UI.WebControls.WebParts;
using Microsoft.Office.Server.Search.WebControls;
using System.Xml;
using System.Globalization;

namespace GSoft.Dynamite.Portal.Core.Factories
{
    public class DefaultPortalPageFactory : IPortalPageFactory
    {
        private WebPartHelper webPartHelper;
        private PageCreator pageCreator;
        private IWebPartFactory webPartFactory;
        
        public DefaultPortalPageFactory(WebPartHelper webPartHelper, PageCreator pageCreator, IWebPartFactory webPartFactory)
        {
            this.webPartHelper = webPartHelper;
            this.pageCreator = pageCreator;
            this.webPartFactory = webPartFactory;
        }

        public PublishingPage CreateHomePageInstance(SPWeb web, string filename)
        {
            if (PublishingSite.IsPublishingSite(web.Site) && PublishingWeb.IsPublishingWeb(web))
            {
                // Create Page
                var homePage = this.CreatePage(web, filename, PortalPageLayouts.HomeThreeRowsFilename);

                // Create Dummy WP
                this.webPartHelper.AddWebPartToZone(homePage.ListItem, this.webPartHelper.CreatePlaceHolderWebPart(210, 606), "RightSide1", 1);
                this.webPartHelper.AddWebPartToZone(homePage.ListItem, this.webPartHelper.CreatePlaceHolderWebPart(210, 200, "e8f7f6"), "RightSide2", 1);
                this.webPartHelper.AddWebPartToZone(homePage.ListItem, this.webPartHelper.CreatePlaceHolderWebPart(760, 200), "Main3", 1);
                this.webPartHelper.AddWebPartToZone(homePage.ListItem, this.webPartHelper.CreatePlaceHolderWebPart(210, 200, "3d4e5e"), "RightSide3", 1);

                // Publish
                this.UpdateCheckInPublish(homePage, "First Publish");

                return homePage;
            }

            return null;
        }

        public PublishingPage CreateStaticContentPageTemplate(SPWeb web, string filename)
        {
            var contentPage = this.CreatePage(web, filename, PortalPageLayouts.OneFilename);

            var mainContentWebPart = this.webPartFactory.CreateContentBySearchScheduleWebPart();
            mainContentWebPart.StartDatePropertyName = PortalManagedProperties.SchedulingStartDate;
            mainContentWebPart.EndDatePropertyName = PortalManagedProperties.SchedulingEndDate;
            mainContentWebPart.PropertyMappings = "'Title':'Title','Path':'Path','OriginalPath':'OriginalPath','ListID':'ListID','ListItemID':'ListItemID','PictureURL':'PublishingImage','Body':'PublishingPageContentOWSHTML','UniqueID':'UniqueID','ModifiedBy':'ModifiedBy','LastModifiedTime':'LastModifiedTime'";
            mainContentWebPart.ShowAdvancedLink = false;
            mainContentWebPart.NumberOfItems = 1;
            mainContentWebPart.ShowPreferencesLink = false;
            mainContentWebPart.ResultTypeId = string.Empty;
            mainContentWebPart.ItemTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Item_WebPage.js";
            mainContentWebPart.GroupTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Group_Content.js";
            mainContentWebPart.ResultsPerPage = 1;
            mainContentWebPart.ShowPaging = false;
            mainContentWebPart.ShowResultCount = false;
            mainContentWebPart.ShowLanguageOptions = false;
            mainContentWebPart.Title = "Single Content Main";
            mainContentWebPart.ChromeType = PartChromeType.None;
            mainContentWebPart.ShowDefinitions = true;
            mainContentWebPart.QueryGroupName = "Default";
            //// AvailableSortsJson = "[{{\"name\":\"Pertinence\",\"sorts\":[]}},{{\"name\":\"Date(La plus récente)\",\"sorts\":[{{\"p\":\"Write\",\"d\":1}}]}},{{\"name\":\"Date(La plus ancienne)\",\"sorts\":[{{\"p\":\"Write\",\"d\":0}}]}},{{\"name\":\"Liste des affichages\",\"sorts\":[{{\"p\":\"ViewsLifeTime\",\"d\":1}}]}},{{\"name\":\"Affichages récents\",\"sorts\":[{{\"p\":\"ViewsRecent\",\"d\":1}}]}}]"),
            //// SelectedPropertiesJson = "["Path","Title","PortalSummaryOWSMTXT","FileExtension","SecondaryFileExtension"]["Path","Title","PublishingPageContentOWSHTML","FileExtension","SecondaryFileExtension"]"   

            var querySettings = new DataProviderScriptWebPart()
            {
                PropertiesJson = mainContentWebPart.DataProviderJSON
            };

            querySettings.Properties["SourceID"] = "270dbfe5-ad50-42bf-b27b-c848483b4bd5";
            querySettings.Properties["SourceName"] = "Single Content Item";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";
            mainContentWebPart.DataProviderJSON = querySettings.PropertiesJson;

            var sideMenu = this.webPartFactory.CreateContextualNavigationWebPart();
            sideMenu.ChromeType = PartChromeType.None;
            sideMenu.SearchPages = true;
            sideMenu.IsParentNode = false;

            // Main section wp
            this.webPartHelper.AddWebPartToZone(contentPage.ListItem, mainContentWebPart as WebPart, "PageContent", 10);

            // Left side WP
            this.webPartHelper.AddWebPartToZone(contentPage.ListItem, sideMenu as WebPart, "LeftSide", 10);

            this.UpdateCheckInPublish(contentPage, "First Publish");

            return contentPage;
        }

        public PublishingPage CreateAllNewsPageInstance(SPWeb web, string filename)
        {
            var allNewsPage = this.CreatePage(web, filename, PortalPageLayouts.ManyFilename);

            var allNewsWebPart = this.webPartFactory.CreateContentBySearchScheduleWebPart();
            allNewsWebPart.StartDatePropertyName = PortalManagedProperties.SchedulingStartDate;
            allNewsWebPart.EndDatePropertyName = PortalManagedProperties.SchedulingEndDate;
            allNewsWebPart.PropertyMappings = "Link URL{URL du lien}:Path,Line 1{Ligne 1}:Title,Line 2{Ligne 2}:PortalSummaryOWSMTXT,FileExtension,SecondaryFileExtension,'ArticleStartDateOWSDATE':'ArticleStartDateOWSDATE','PictureURL':'PublishingImage'";
            allNewsWebPart.ShowAdvancedLink = false;
            allNewsWebPart.NumberOfItems = 7;
            allNewsWebPart.ShowPreferencesLink = false;
            allNewsWebPart.ResultTypeId = string.Empty;
            allNewsWebPart.ItemTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Item_WebPage.js";
            allNewsWebPart.GroupTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Group_Content.js";
            allNewsWebPart.RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Search/Control_SearchResults.js";
            //allNewsWebPart.RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Control_ListWithPaging.js";
            allNewsWebPart.ResultsPerPage = 5;
            allNewsWebPart.ShowAlertMe = false;
            allNewsWebPart.ShowPaging = true;
            allNewsWebPart.ShowResultCount = false;
            allNewsWebPart.ShowLanguageOptions = false;
            allNewsWebPart.Title = filename;
            allNewsWebPart.ShowDefinitions = true;
            allNewsWebPart.QueryGroupName = "Default";
            allNewsWebPart.ChromeType = PartChromeType.None;
            
            var querySettings = new DataProviderScriptWebPart()
            {
                PropertiesJson = allNewsWebPart.DataProviderJSON
            };

            querySettings.Properties["SourceID"] = "84df43de-141d-4930-a8bc-6e142ba23476";
            querySettings.Properties["SourceName"] = "All News";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";

            allNewsWebPart.DataProviderJSON = querySettings.PropertiesJson;

            var sideMenu = this.webPartFactory.CreateContextualNavigationWebPart();
            sideMenu.ChromeType = PartChromeType.None;
            sideMenu.SearchPages = false;
            sideMenu.IsParentNode = true;

            // PlaceHolder for the Main section of the page
            this.webPartFactory.AddNodeDescriptionWebPart(allNewsPage.ListItem, "Main", 10);
            this.webPartHelper.AddWebPartToZone(allNewsPage.ListItem, allNewsWebPart as WebPart, "Main", 20);

            // PlaceHolder for the Left Navigation Menu
            this.webPartHelper.AddWebPartToZone(allNewsPage.ListItem, sideMenu as WebPart, "LeftSide", 10);

            this.UpdateCheckInPublish(allNewsPage, "First Publish");

            return allNewsPage;
        }

        public PublishingPage CreateNewsPageTemplate(SPWeb web, string filename)
        {

            var newsPage = this.CreatePage(web, filename, PortalPageLayouts.OneFilename);

            var mainNewsWebPart = this.webPartFactory.CreateContentBySearchScheduleWebPart();
            mainNewsWebPart.StartDatePropertyName = PortalManagedProperties.SchedulingStartDate;
            mainNewsWebPart.EndDatePropertyName = PortalManagedProperties.SchedulingEndDate;
            mainNewsWebPart.PropertyMappings = "'Title':'Title','Path':'Path','OriginalPath':'OriginalPath','ListID':'ListID','ListItemID':'ListItemID','PictureURL':'PublishingImage','Body':'PublishingPageContentOWSHTML','ArticleStartDateOWSDATE':'ArticleStartDateOWSDATE','UniqueID':'UniqueID','ModifiedBy':'ModifiedBy','LastModifiedTime':'LastModifiedTime'";
            mainNewsWebPart.ShowAdvancedLink = false;
            mainNewsWebPart.NumberOfItems = 1;
            mainNewsWebPart.ShowPreferencesLink = false;
            mainNewsWebPart.ResultTypeId = string.Empty;
            mainNewsWebPart.ItemTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Item_ChadNewsPage.js";
            mainNewsWebPart.GroupTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Group_Content.js";
            mainNewsWebPart.ResultsPerPage = 1;
            mainNewsWebPart.ShowPaging = false;
            mainNewsWebPart.ShowResultCount = false;
            mainNewsWebPart.ShowLanguageOptions = false;
            mainNewsWebPart.Title = "Single News Main";
            mainNewsWebPart.ChromeType = PartChromeType.None;
            mainNewsWebPart.ShowDefinitions = true;
            mainNewsWebPart.QueryGroupName = "Default";

            var querySettings = new DataProviderScriptWebPart()
            {
                PropertiesJson = mainNewsWebPart.DataProviderJSON
            };

            querySettings.Properties["SourceID"] = "270dbfe5-ad50-42bf-b27b-c848483b4bd5";
            querySettings.Properties["SourceName"] = "Single News Item";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";
            mainNewsWebPart.DataProviderJSON = querySettings.PropertiesJson;

            var sideMenu = this.webPartFactory.CreateContextualNavigationWebPart();
            sideMenu.ChromeType = PartChromeType.None;
            sideMenu.SearchPages = false;
            sideMenu.IsParentNode = true;

            // Main content wp
            this.webPartHelper.AddWebPartToZone(newsPage.ListItem, mainNewsWebPart as WebPart, "PageContent", 10);

            // Left side WP
            this.webPartHelper.AddWebPartToZone(newsPage.ListItem, sideMenu as WebPart, "LeftSide", 10);

            this.UpdateCheckInPublish(newsPage, "First Publish");

            return newsPage;
        }

        public PublishingPage CreateNodeDescriptionPageTemplate(SPWeb web, string filename)
        {
            var nodePage = this.CreatePage(web, filename, PortalPageLayouts.ManyFilename);

            var leafsWebPart = this.webPartFactory.CreateContentBySearchScheduleWebPart();
            leafsWebPart.StartDatePropertyName = PortalManagedProperties.SchedulingStartDate;
            leafsWebPart.EndDatePropertyName = PortalManagedProperties.SchedulingEndDate;
            leafsWebPart.PropertyMappings = "Link URL{URL du lien}:Path,Line 1{Ligne 1}:Title,Line 2{Ligne 2}:PortalSummaryOWSMTXT,FileExtension,SecondaryFileExtension";
            leafsWebPart.ShowAdvancedLink = false;
            leafsWebPart.NumberOfItems = 10;
            leafsWebPart.ShowPreferencesLink = false;
            leafsWebPart.ResultTypeId = string.Empty;
            leafsWebPart.ItemTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Item_WebPage.js";
            leafsWebPart.GroupTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Content Web Parts/Group_Content.js";
            leafsWebPart.RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Search/Control_SearchResults.js";
            leafsWebPart.ResultsPerPage = 10;
            leafsWebPart.ShowPaging = true;
            leafsWebPart.ShowResultCount = false;
            leafsWebPart.ShowLanguageOptions = false;
            leafsWebPart.Title = "Results";
            leafsWebPart.ChromeType = PartChromeType.None;
            leafsWebPart.ShowDefinitions = true;
            leafsWebPart.QueryGroupName = "Default";

            var querySettings = new DataProviderScriptWebPart()
            {
                PropertiesJson = leafsWebPart.DataProviderJSON
            };

            querySettings.Properties["SourceID"] = "075a87f6-65ef-4d68-abb1-da17e13656a0";
            querySettings.Properties["SourceName"] = "All Category Items";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";
            leafsWebPart.DataProviderJSON = querySettings.PropertiesJson;

            var childNodesPart = this.webPartFactory.CreateChildNodesWebPart();
            childNodesPart.ChromeType = PartChromeType.None;

            var sideMenu = this.webPartFactory.CreateContextualNavigationWebPart();
            sideMenu.ChromeType = PartChromeType.None;
            sideMenu.SearchPages = false;
            sideMenu.IsParentNode = true;

            // Main Web Part Zone
            this.webPartFactory.AddNodeDescriptionWebPart(nodePage.ListItem, "PageContent", 10);
            this.webPartHelper.AddWebPartToZone(nodePage.ListItem, childNodesPart as WebPart, "PageContent", 20);
            this.webPartHelper.AddWebPartToZone(nodePage.ListItem, leafsWebPart as WebPart, "PageContent", 30);

            // PlaceHolder for the Left Navigation Menu
            this.webPartHelper.AddWebPartToZone(nodePage.ListItem, sideMenu as WebPart, "LeftSide", 10);

            this.UpdateCheckInPublish(nodePage, "First Publish");

            return nodePage;
        }

        public PublishingPage CreateSearchResultsPageInstance(SPWeb web, string filename)
        {
            var searchResultsPage = this.CreatePage(web, filename, PortalPageLayouts.ManyFilename);

            var searchBox = new SearchBoxScriptWebPart()
            {
                ChromeType = PartChromeType.None,
                RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Search/Control_SearchBox.js"
            };

            var refinements = new RefinementScriptWebPart()
            {
                ChromeType = PartChromeType.TitleAndBorder,
                Title = "Filtres de recherche",
                Description = "Refinements",
                RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Filters/Control_Refinement.js",
                QueryGroupName = "Default",
                ShowDataErrors = false,
                AlternateErrorMessage = string.Empty,
                ImportErrorMessage = string.Empty,
                SelectedRefinementControlsJson =
                "{" +
                    "'refinerConfigurations':[{" +
                        "'sortBy':0," +
                        "'sortOrder':0," +
                        "'maxNumberRefinementOptions':21," +
                        "'propertyName':'FileType'," +
                        "'type':'Text'," +
                        "'displayTemplate':'~sitecollection/_catalogs/masterpage/Display Templates/Filters/Filter_Default.js'," +
                        "'displayName':'Type de document'," +
                        "'useDefaultDateIntervals':false," +
                        "'aliases':['format']," +
                        "'refinerSpecStringOverride':''," +
                        "'intervals':null" +
                        "},{" +
                        "'sortBy':0," +
                        "'sortOrder':0," +
                        "'maxNumberRefinementOptions':15," +
                        "'propertyName':'PortalSubjectOWSTEXT'," +
                        "'type':'Text'," +
                        "'displayTemplate':'~sitecollection/_catalogs/masterpage/Display Templates/Filters/Filter_Default.js'," +
                        "'displayName':'Sujets'," +
                        "'useDefaultDateIntervals':false," +
                        "'aliases':null," +
                        "'refinerSpecStringOverride':''," +
                        "'intervals':null" +
                        "},{" +
                        "'sortBy':0," +
                        "'sortOrder':0," +
                        "'maxNumberRefinementOptions':15," +
                        "'propertyName':'ArticleStartDateOWSDATE'," +
                        "'type':'DateTime'," +
                        "'displayTemplate':'~sitecollection/_catalogs/masterpage/Display Templates/Filters/Filter_Default.js'," +
                        "'displayName':'Date de publication'," +
                        "'useDefaultDateIntervals':false," +
                        "'aliases':null," +
                        "'refinerSpecStringOverride':''," +
                        "'intervals':null" +
                    "}]}"
            };

            var searchResults = this.webPartFactory.CreateResultScriptScheduleWebPart();
            searchResults.ChromeType = PartChromeType.None;
            searchResults.Title = "Search Results";
            searchResults.StartDatePropertyName = PortalManagedProperties.SchedulingStartDate;
            searchResults.EndDatePropertyName = PortalManagedProperties.SchedulingEndDate;
            searchResults.ShowPaging = true;
            searchResults.MaxPagesBeforeCurrent = 4;
            searchResults.ResultsPerPage = 10;
            searchResults.ShowResultCount = true;
            searchResults.ResultTypeId = string.Empty;
            searchResults.ItemBodyTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Search/Item_CommonItem_Body.js";
            searchResults.RenderTemplateId = "~sitecollection/_catalogs/masterpage/Display Templates/Search/Control_SearchResults.js";
            searchResults.QueryGroupName = "Default";
            searchResults.ShowAdvancedLink = false;
            searchResults.ShowPreferencesLink = false;
            searchResults.ShowLanguageOptions = false;
            searchResults.ShowDefinitions = true;
            searchResults.EmptyMessage = "";

            var querySettings = new DataProviderScriptWebPart()
            {
                PropertiesJson = searchResults.DataProviderJSON
            };

            querySettings.Properties["SourceID"] = "bc102bde-9ab4-47f2-894a-829f2f31e165";
            querySettings.Properties["SourceName"] = "Search - Portal Content";
            querySettings.Properties["SourceLevel"] = "Ssa";
            querySettings.Properties["QueryTemplate"] = "(IsDocument:\"True\" OR contentclass:\"STS_ListItem\")";
            querySettings.Properties["TrimDuplicates"] = "false";
            searchResults.DataProviderJSON = querySettings.PropertiesJson;

            var element = new XmlDocument().CreateElement("content");
            element.InnerText = string.Format("<h1 class=\"page-title\">{0}</h1>", CultureInfo.CurrentUICulture.LCID == Language.English.Culture.LCID ? "Search" : "Recherche");

            var titleWebPart = new Microsoft.SharePoint.WebPartPages.ContentEditorWebPart();
            titleWebPart.ChromeType = PartChromeType.None;
            titleWebPart.Content = element;

            //Main Web Part zone 
            this.webPartHelper.AddWebPartToZone(searchResultsPage.ListItem, titleWebPart, "PageContent", 10);
            this.webPartHelper.AddWebPartToZone(searchResultsPage.ListItem, searchBox as WebPart, "PageContent", 20);
            this.webPartHelper.AddWebPartToZone(searchResultsPage.ListItem, searchResults as WebPart, "PageContent", 30);

            //Left Web Part zone 
            this.webPartHelper.AddWebPartToZone(searchResultsPage.ListItem, refinements as WebPart, "LeftSide", 10);

            this.UpdateCheckInPublish(searchResultsPage, "First Publish");

            return searchResultsPage;
        }

        private PublishingPage CreatePage(SPWeb web, string filename, string pageLayoutFilename)
        {
            var publishingSite = new PublishingSite(web.Site);

            var pageInfo = new PageInfo()
            {
                Name = filename,
                ContentTypeId = PortalContentTypes.ContentPageContentTypeId,
                PageLayout = this.pageCreator.GetPageLayout(publishingSite, pageLayoutFilename, false)
            };

            // Create French Home Page
            var page = this.pageCreator.Create(web, pageInfo);
            return page;
        }

        private void UpdateCheckInPublish(PublishingPage page, string message)
        {
            page.Update();
            page.CheckIn(message);
            page.ListItem.File.Publish(message);
        }
    }
}
