using System;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using Microsoft.SharePoint;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using System.Collections.Generic;

namespace GSoft.Dynamite.Navigation.SP.CONTROLTEMPLATES.GSoft.Dynamite.Navigation
{
    /// <summary>
    /// Code behind of the main menu user control
    /// </summary>
    public partial class MainMenu : UserControl
    {
        /// <summary>
        /// The raw row for the main menu
        /// </summary>
        public string MenuJSON { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new JavaScriptSerializer();

            using (var scope = NavigationContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
            {
                var publishingManagedPropertyInfos = scope.Resolve<PublishingManagedPropertyInfos>();
                var multilingualismManagedPropertyInfos = scope.Resolve<MultilingualismManagedPropertyInfos>();
                var publishingContentTypeInfos = scope.Resolve<PublishingContentTypeInfos>();
                var dynamiteNavigationService = scope.Resolve<IDynamiteNavigationService>();

                // Creates the properties object
                var properties = new NavigationManagedProperties()
                 {
                     Title = BuiltInManagedProperties.Title,
                     ResultSourceName = "All Menu Items",
                     Navigation = publishingManagedPropertyInfos.Navigation.Name,
                     ItemLanguage = multilingualismManagedPropertyInfos.ItemLanguage.Name,
                     FriendlyUrlRequiredProperties = new[] 
                     { 
                         publishingManagedPropertyInfos.Navigation.Name, 
                         BuiltInManagedProperties.Url, 
                         BuiltInManagedProperties.SiteUrl, 
                         BuiltInManagedProperties.ListId 
                     },
                     CatalogItemId = publishingContentTypeInfos.CatalogContentItem().ContentTypeId
                 };

                // Call the navigation service
                var navigationData = dynamiteNavigationService.GetMenuNodes(SPContext.Current.Web, properties, 12);

                // Serializes the data
                this.MenuJSON = serializer.Serialize(navigationData);
            }
        }
    }
}
