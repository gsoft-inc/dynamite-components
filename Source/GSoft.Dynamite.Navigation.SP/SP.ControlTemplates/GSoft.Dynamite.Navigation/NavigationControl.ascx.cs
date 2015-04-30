﻿using System;
using System.Globalization;
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
    /// <summary>
    /// A generic control generated by navigation term and Featured In term
    /// </summary>
    public partial class NavigationControl : UserControl
    {
        /// <summary>
        /// The raw row for the main menu
        /// </summary>
        public string MenuJson { get; set; }

        /// <summary>
        /// The term Label
        /// </summary>
        public string FeaturedIn { get; set; }

        /// <summary>
        /// The title to display
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The CSS class for the whole control
        /// </summary>
        public string Css { get; set; }

        /// <summary>
        /// Loads the data in the page
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = this.Title ?? string.Empty;
            this.Css = this.Css ?? string.Empty;

            using (var scope = NavigationContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
            {
                var publishingManagedPropertyInfos = scope.Resolve<PublishingManagedPropertyInfos>();
                var navigationManagedPropertyInfos = scope.Resolve<NavigationManagedPropertyInfos>();
                var multilingualismManagedPropertyInfos = scope.Resolve<MultilingualismManagedPropertyInfos>();
                var publishingContentTypeInfos = scope.Resolve<PublishingContentTypeInfos>();
                var navigationService = scope.Resolve<INavigationService>();
                var navigationResultSourceInfos = scope.Resolve<NavigationResultSourceInfos>();

                var queryParameters = new NavigationQueryParameters()
                {
                    NodeMatchingSettings = new NavigationNodeMatchingSettings()
                    {
                        IncludeCatalogItems = true,
                        RestrictToReachableTargetItems = true
                    },
                    SearchSettings = new NavigationSearchSettings()
                    {
                        NavigationManagedPropertyName = publishingManagedPropertyInfos.Navigation.Name,
                        ResultSourceName = navigationResultSourceInfos.AllMenuItems().Name,
                        SelectedProperties = new[] 
                        { 
                            // These properties are required for the generation of the friendly URL
                            publishingManagedPropertyInfos.Navigation.Name, 
                            BuiltInManagedProperties.Url.Name, 
                            BuiltInManagedProperties.SiteUrl.Name, 
                            BuiltInManagedProperties.ListId.Name                                           
                        },
                        GlobalFilters = new[]
                        {
                            // Use the Locale of the web instead of the Language because when we implement unsupported languages as Inuktitut, 
                            // the variation label language is en-US.
                            // Filter items on the web's language
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}:{1}",
                                multilingualismManagedPropertyInfos.ItemLanguage.Name,
                                SPContext.Current.Web.Locale.TwoLetterISOLanguageName),

                            // Filter items on occurence link location (featured in)
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "{0}:{1}",
                                navigationManagedPropertyInfos.OccurrenceLinkLocationManagedPropertyText.Name,
                                this.FeaturedIn)
                        },
                        TargetItemFilters = new[]
                        {
                            string.Format(
                                CultureInfo.InvariantCulture, 
                                "{0}:{1}*", 
                                BuiltInManagedProperties.ContentTypeId, 
                                publishingContentTypeInfos.TargetContentItem().ContentTypeId)
                        },
                        CatalogItemFilters = new[]
                        {
                            string.Format(
                                CultureInfo.InvariantCulture, 
                                "{0}:{1}*", 
                                BuiltInManagedProperties.ContentTypeId, 
                                publishingContentTypeInfos.CatalogContentItem().ContentTypeId)
                        }
                    }
                };

                // Call the navigation service
                var navigationData = navigationService.GetAllNavigationNodes(SPContext.Current.Web, queryParameters);

                this.NavigationRepeater.DataSource = navigationData;
                this.NavigationRepeater.DataBind();
            }
        }
    }
}
