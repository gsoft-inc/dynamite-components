using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingFieldInfoConfig : ICustomPublishingFieldInfoConfig
    {
        private readonly DynamiteDemoPublishingFieldInfoValues _fieldInfoValues;

        public DynamiteDemoPublishingFieldInfoConfig(DynamiteDemoPublishingFieldInfoValues fieldInfoValues)
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
