using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingFieldInfoConfig : IBasePublishingFieldInfoConfig
    {
        private readonly DynamiteDemoPublishingFieldInfos _fieldInfoValues;
        private readonly IBasePublishingFieldInfoConfig _basePublishingFieldInfoConfig;

        public DynamiteDemoPublishingFieldInfoConfig(IBasePublishingFieldInfoConfig basePublishingFieldInfoConfig, DynamiteDemoPublishingFieldInfos fieldInfoValues)
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
