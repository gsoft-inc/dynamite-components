using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

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
        public string MenuJson { get; set; }

        /// <summary>
        /// Loads the data in the page
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new JavaScriptSerializer();

            using (var scope = NavigationContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
            {
                var navigationService = scope.Resolve<INavigationService>();
                var publishingFieldInfoConfig = scope.Resolve<IPublishingFieldInfoConfig>();

                var navigationField = publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;

                var queryParameters = new NavigationQueryParameters()
                {
                    NodeMatchingSettings = new NavigationNodeMatchingSettings()
                    {
                        IncludeCatalogItems = true,
                        RestrictToReachableTargetItems = true,
                    },
                    SearchSettings = new NavigationSearchSettings()
                    {
                        NavigationManagedPropertyName = navigationField.OWSTaxIdManagedPropertyInfo.Name,
                        ResultSourceName = NavigationResultSourceInfos.AllMenuItems.Name,
                        SelectedProperties = new List<string>
                        { 
                            // These properties are required for the generation of the friendly URL
                            navigationField.OWSTaxIdManagedPropertyInfo.Name, 
                            BuiltInManagedProperties.Url.Name, 
                            BuiltInManagedProperties.SiteUrl.Name, 
                            BuiltInManagedProperties.ListId.Name                                           
                        },
                        GlobalFilters = new List<string>
                        {
                            // Use the Locale of the web instead of the Language because when we implement unsupported languages as Inuktitut, 
                            // the variation label language is en-US.
                            // Filter items on the web's language
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}:{1}",
                                MultilingualismManagedPropertyInfos.ItemLanguage.Name,
                                SPContext.Current.Web.Locale.Name),

                            // Filter items on occurence link location (featured in) main menu
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}:{1}",
                                NavigationManagedPropertyInfos.OccurrenceLinkLocationManagedPropertyText.Name,
                                "Main Menu")
                        },
                        TargetItemFilters = new List<string>
                        {
                            string.Format(
                                CultureInfo.InvariantCulture, 
                                "{0}:{1}*", 
                                BuiltInManagedProperties.ContentTypeId.Name, 
                                PublishingContentTypeInfos.TargetContentItem.ContentTypeId)
                        },
                        CatalogItemFilters = new List<string>
                        {
                            string.Format(
                                CultureInfo.InvariantCulture, 
                                "{0}:{1}*", 
                                BuiltInManagedProperties.ContentTypeId.Name, 
                                PublishingContentTypeInfos.CatalogContentItem.ContentTypeId)
                        }
                    }
                };

                // Call the navigation service
                var navigationData = navigationService.GetAllNavigationNodes(SPContext.Current.Web, queryParameters);

                // Serializes the data
                this.MenuJson = serializer.Serialize(navigationData);
            }
        }
    }
}
