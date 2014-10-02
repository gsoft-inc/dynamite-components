using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingFieldInfoConfig : ICustomPublishingFieldInfoConfig
    {
        private readonly DynamiteDemoPublishingFieldInfos _fieldInfoValues;

        public DynamiteDemoPublishingFieldInfoConfig(DynamiteDemoPublishingFieldInfos fieldInfoValues)
        {
            _fieldInfoValues = fieldInfoValues;
        }

        public IList<IFieldInfo> Fields()
        {
            var fields = new List<IFieldInfo>
            {
                {_fieldInfoValues.DynamiteDemoColumn()},
            };

            return fields;
        }
    }
}
