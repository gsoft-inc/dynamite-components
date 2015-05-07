using System.Collections.Generic;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Lists configuration for the navigation module
    /// </summary>
    public class NavigationListInfosConfig : INavigationListInfosConfig
    {
        private readonly IPublishingCatalogInfoConfig publishingCatalogInfoConfig;
        private readonly IPublishingListInfoConfig publishingListInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationListInfosConfig"/> class.
        /// </summary>
        /// <param name="publishingCatalogInfoConfig">The publishing catalog configuration.</param>
        /// <param name="publishingListInfoConfig">The publishing list configuration.</param>
        public NavigationListInfosConfig(
            IPublishingCatalogInfoConfig publishingCatalogInfoConfig,
            IPublishingListInfoConfig publishingListInfoConfig)
        {
            this.publishingCatalogInfoConfig = publishingCatalogInfoConfig;
            this.publishingListInfoConfig = publishingListInfoConfig;
        }

        /// <summary>
        /// Property that return all the lists to create or configure in the navigation module
        /// </summary>
        public IList<ListInfo> Lists
        {        
            // The collection in set by features depending on the solution type
            get
            {
                return new List<ListInfo>()
                {
                    this.ContentPages,
                    this.PagesLibrary
                };
            }          
        }

        private ListInfo ContentPages
        {
            get
            {
                // Page editors can create terms directly in the form so find the navigation field and set CreateValuesInEditForm to true.
                var list = this.publishingCatalogInfoConfig.GetCatalogInfoByWebRelativeUrl(PublishingCatalogInfos.ContentPages.WebRelativeUrl);
                foreach (var field in list.FieldDefinitions)
                {
                    if (field.Id.Equals(PublishingFieldInfos.Navigation.Id))
                    {
                        (field as TaxonomyFieldInfo).CreateValuesInEditForm = true;
                    }
                }

                return list;
            }
        }

        private ListInfo PagesLibrary
        {
            get
            {
                // Page editors can create terms directly in the form so find the navigation field and set CreateValuesInEditForm to true.
                // By default, Navigation Term Set must be set to IsOpenForTermCreation = True
                var list = this.publishingListInfoConfig.GetListInfoByWebRelativeUrl(PublishingListInfos.PagesLibrary.WebRelativeUrl);
                foreach (var field in list.FieldDefinitions)
                {
                    if (field.Id.Equals(PublishingFieldInfos.Navigation.Id))
                    {
                        (field as TaxonomyFieldInfo).CreateValuesInEditForm = true;
                    }
                }

                return list;
            }
        }
    }
}
