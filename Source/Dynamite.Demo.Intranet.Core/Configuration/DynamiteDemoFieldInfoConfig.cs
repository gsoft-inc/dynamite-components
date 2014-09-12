using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamite.Demo.Intranet.Contracts.Constants;
using Dynamite.Demo.Intranet.Core.Keys;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DynamiteDemoFieldInfoConfig : ICustomFieldInfoConfig
    {
        private readonly DynamiteDemoFieldInfoValues _fieldInfoValues;

        public DynamiteDemoFieldInfoConfig(DynamiteDemoFieldInfoValues fieldInfoValues)
        {
            _fieldInfoValues = fieldInfoValues;
        }

        public IDictionary<string, FieldInfo> Fields()
        {
            var fields = new Dictionary<string, FieldInfo>
            {
                {DynamiteDemoFieldInfoKeys.DynamiteDemoColumn,_fieldInfoValues.DynamiteDemoColumn()},
            };

            return fields;
        }
    }
}
