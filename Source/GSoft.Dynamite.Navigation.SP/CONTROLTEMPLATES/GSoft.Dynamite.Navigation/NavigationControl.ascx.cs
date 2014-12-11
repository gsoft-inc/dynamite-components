using System;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.CONTROLTEMPLATES.GSoft.Dynamite.Navigation
{
    public partial class NavigationControl : UserControl
    {
        /// <summary>
        /// The raw row for the main menu
        /// </summary>
        public string MenuJson { get; set; }

        public string FeaturedIn { get; set; }

        /// <summary>
        /// Loads the data in the page
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var scope = NavigationContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
            {
                var publishingManagedPropertyInfos = scope.Resolve<PublishingManagedPropertyInfos>();
                var navigationManagedPropertyInfos = scope.Resolve<NavigationManagedPropertyInfos>();
                var multilingualismManagedPropertyInfos = scope.Resolve<MultilingualismManagedPropertyInfos>();
                var publishingContentTypeInfos = scope.Resolve<PublishingContentTypeInfos>();
                var dynamiteNavigationService = scope.Resolve<IDynamiteNavigationService>();
                var navigationResultSourceInfos = scope.Resolve<NavigationResultSourceInfos>();

                // Creates the properties object
                var properties = new NavigationManagedProperties()
                {
                    Title = BuiltInManagedProperties.Title,
                    ResultSourceName = navigationResultSourceInfos.AllMenuItems().Name,
                    Navigation = publishingManagedPropertyInfos.Navigation.Name,
                    ItemLanguage = multilingualismManagedPropertyInfos.ItemLanguage.Name,
                    CatalogItemContentTypeId = publishingContentTypeInfos.CatalogContentItem().ContentTypeId,
                    TargetItemContentTypeId = publishingContentTypeInfos.TargetContentItem().ContentTypeId,
                    FilterManagedPropertyName = navigationManagedPropertyInfos.OccurrenceLinkLocationManagedPropertyText.Name,
                    FilterManagedPropertyValue = this.FeaturedIn,
                    FriendlyUrlRequiredProperties = new[] 
                     { 
                         publishingManagedPropertyInfos.Navigation.Name, 
                         BuiltInManagedProperties.Url, 
                         BuiltInManagedProperties.SiteUrl, 
                         BuiltInManagedProperties.ListId                                           
                     },
                };

                // Call the navigation service
                var navigationData = dynamiteNavigationService.GetMenuNodes(SPContext.Current.Web, properties, 12);

                // Serializes the data
                //var serializer = new JavaScriptSerializer();
               // this.MenuJson = serializer.Serialize(navigationData);

                this.NavigationRepeater.DataSource = navigationData;
                this.NavigationRepeater.DataBind();
            }
        }
    }
}
