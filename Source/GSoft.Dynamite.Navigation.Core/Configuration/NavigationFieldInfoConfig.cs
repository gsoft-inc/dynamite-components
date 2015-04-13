using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.Common.Contract.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the navigation module
    /// </summary>
    public class NavigationFieldInfoConfig : INavigationFieldInfoConfig
    {
        private readonly IPublishingFieldInfoConfig publishingFieldInfoConfig;
        private readonly ICommonTaxonomyConfig commonTaxonomyConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationFieldInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingFieldInfoConfig">The publishing field configuration.</param>
        /// <param name="commonTaxonomyConfig">The common taxonomy configuration.</param>
        public NavigationFieldInfoConfig(
            IPublishingFieldInfoConfig publishingFieldInfoConfig,
            ICommonTaxonomyConfig commonTaxonomyConfig)
        {
            this.publishingFieldInfoConfig = publishingFieldInfoConfig;
            this.commonTaxonomyConfig = commonTaxonomyConfig;
        }

        /// <summary>
        /// Property that return all the fields to create or configure in the navigation module
        /// </summary>
        public IList<BaseFieldInfo> Fields
        {
            get
            {
                // Get the base publishing field info 
                var baseFieldInfo = new List<BaseFieldInfo>
                {
                    NavigationFieldInfos.DateSlug,
                    NavigationFieldInfos.TitleSlug,
                    this.publishingFieldInfoConfig.GetFieldById(PublishingFieldInfos.PublishingStartDate.Id),
                    this.OccurrenceLinkLocation
                };

                return baseFieldInfo;
            }
        }

        /// <summary>
        /// Gets the field from the Fields property where the id of that field is passed by parameter.
        /// </summary>
        /// <param name="fieldId">The unique identifier of the field we are looking for.</param>
        /// <returns>
        /// The field information.
        /// </returns>
        public BaseFieldInfo GetFieldById(Guid fieldId)
        {
            return this.Fields.Single(f => f.Id.Equals(fieldId));
        }

        private BaseFieldInfo OccurrenceLinkLocation
        {
            get
            {
                var field = NavigationFieldInfos.OccurrenceLinkLocation as TaxonomyMultiFieldInfo;
                field.TermStoreMapping = new TaxonomyContext()
                {
                    TermSet = this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.NavigationControls.Id)
                };

                return field;
            }
        }
    }
}
