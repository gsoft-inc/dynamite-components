using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// The fields configuration for the publishing module
    /// </summary>
    public class PublishingFieldInfoConfig : IPublishingFieldInfoConfig
    {
        private readonly ICommonTaxonomyConfig commonTaxonomyConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="commonTaxonomyConfig">The common taxonomy configuration.</param>
        public PublishingFieldInfoConfig(ICommonTaxonomyConfig commonTaxonomyConfig)
        {
            this.commonTaxonomyConfig = commonTaxonomyConfig;
        }

        /// <summary>
        /// Property that return all the fields to create in the publishing module
        /// </summary>
        /// <returns>The fields</returns>
        public IList<BaseFieldInfo> Fields
        {
            get
            {
                var fields = new List<BaseFieldInfo>
                {
                    this.NavigationFieldInfo,
                    PublishingFieldInfos.Summary,
                    PublishingFieldInfos.ImageDescription,
                    PublishingFieldInfos.PublishingStartDate
                };

                return fields;
            }
        }

        /// <summary>
        /// Gets the navigation field information.
        /// </summary>
        /// <value>
        /// The navigation field information.
        /// </value>
        private TaxonomyFieldInfo NavigationFieldInfo
        {
            get
            {
                // By default, use the first defined navigation term set info as the
                // field term set mapping.
                var fieldInfo = PublishingFieldInfos.Navigation;
                fieldInfo.TermStoreMapping = new TaxonomyContext(this.commonTaxonomyConfig.GetTermSetInfoById(CommonTermSetInfo.EnglishNavigation.Id));

                return fieldInfo;
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
    }
}
