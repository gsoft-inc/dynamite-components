using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Constants;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoPublishingFieldInfoConfig : ICustomPublishingFieldInfoConfig
    {
        private readonly DynamiteDemoPublishingFieldInfos fieldInfoValues;

        public DynamiteDemoPublishingFieldInfoConfig(DynamiteDemoPublishingFieldInfos fieldInfoValues)
        {
           this.fieldInfoValues = fieldInfoValues;
        }

        public IList<IFieldInfo> Fields
        {
            get
            {
                var fields = new List<IFieldInfo>
                {
                    { this.fieldInfoValues.DynamiteDemoColumn() },
                };

                return fields;
            }
        }
    }
}
