using System.Collections.Generic;
using GSoft.Dynamite.Common.Contract.Configuration;
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
                    PublishingFieldInfos.ImageDescription
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
                fieldInfo.TermStoreMapping = new TaxonomyContext(
                    this.commonTaxonomyConfig.NavigationTermSetInfos[0]);

                return fieldInfo;
            }
        }
    }
}
