using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class BasePublishingFieldInfoConfig: IBasePublishingFieldInfoConfig
    {
        private readonly BasePublishingFieldInfos _fieldInfoValues;

        public BasePublishingFieldInfoConfig(BasePublishingFieldInfos fieldInfoValues)
        {
            _fieldInfoValues = fieldInfoValues;
        }

        public IList<IFieldInfo> Fields()
        {
            var fields = new List<IFieldInfo>
            {
                {_fieldInfoValues.Navigation()},
                {_fieldInfoValues.Summary()},
                {_fieldInfoValues.ImageDescription()},
            };

            return fields;
        }
    }
}
