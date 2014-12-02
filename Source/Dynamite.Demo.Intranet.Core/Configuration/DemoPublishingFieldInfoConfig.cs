using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Example of an override of fields for a client solution
    /// </summary>
    public class DemoPublishingFieldInfoConfig : IPublishingFieldInfoConfig
    {
        private readonly DemoPublishingFieldInfos _fieldInfoValues;
        private readonly IPublishingFieldInfoConfig _basePublishingFieldInfoConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="basePublishingFieldInfoConfig">The base fields configuration from the publishing module</param>
        /// <param name="fieldInfoValues">The fields settings from the dynamite demo solution</param>
        public DemoPublishingFieldInfoConfig(IPublishingFieldInfoConfig basePublishingFieldInfoConfig, DemoPublishingFieldInfos fieldInfoValues)
        {
           this._fieldInfoValues = fieldInfoValues;
           this._basePublishingFieldInfoConfig = basePublishingFieldInfoConfig;
        }

        /// <summary>
        /// Fields override from the publishing module
        /// </summary>
        public IList<IFieldInfo> Fields
        {
            get
            {
                var fields = this._basePublishingFieldInfoConfig.Fields;

                // Add the custom field
                fields.Add(this._fieldInfoValues.DynamiteDemoColumn());

                return fields;
            }
        }
    }
}
