using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// The fields configuration for the publishing module
    /// </summary>
    public class PublishingFieldInfoConfig : IPublishingFieldInfoConfig
    {
        private readonly PublishingFieldInfos fieldInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fieldInfoValues">The filed info objects configuration</param>
        public PublishingFieldInfoConfig(PublishingFieldInfos fieldInfoValues)
        {
            this.fieldInfoValues = fieldInfoValues;
        }

        /// <summary>
        /// Property that return all the fields to create in the publishing module
        /// </summary>
        /// <returns>The fields</returns>
        public IList<IFieldInfo> Fields
        {
            get
            {
                var fields = new List<IFieldInfo>
                {
                    { this.fieldInfoValues.Navigation() },
                    { this.fieldInfoValues.Summary() },
                    { this.fieldInfoValues.ImageDescription() },
                };

                return fields;
            }
        }
    }
}
