using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingFieldInfoConfig: IBasePublishingFieldInfoConfig
    {
        private readonly BasePublishingFieldInfos _fieldInfoValues;

        public BasePublishingFieldInfoConfig(BasePublishingFieldInfos fieldInfoValues)
        {
            _fieldInfoValues = fieldInfoValues;
        }

        public IDictionary<string, IFieldInfo> Fields()
        {
            var fields = new Dictionary<string, IFieldInfo>
            {
                {BasePublishingFieldInfoKeys.Navigation,_fieldInfoValues.Navigation()},
                {BasePublishingFieldInfoKeys.Summary,_fieldInfoValues.Summary()},
                {BasePublishingFieldInfoKeys.ImageDescription,_fieldInfoValues.ImageDescription()},
            };

            return fields;
        }
    }
}
