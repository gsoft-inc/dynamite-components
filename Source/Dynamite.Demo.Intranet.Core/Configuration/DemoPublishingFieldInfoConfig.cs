using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.FieldTypes;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoPublishingFieldInfoConfig : IPublishingFieldInfoConfig
    {
        private readonly DemoPublishingFieldInfos _fieldInfoValues;
        private readonly IPublishingFieldInfoConfig _basePublishingFieldInfoConfig;

        public DemoPublishingFieldInfoConfig(IPublishingFieldInfoConfig basePublishingFieldInfoConfig, DemoPublishingFieldInfos fieldInfoValues)
        {
           this._fieldInfoValues = fieldInfoValues;
           this._basePublishingFieldInfoConfig = basePublishingFieldInfoConfig;

        }

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
