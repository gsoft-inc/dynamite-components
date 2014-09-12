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
    public class BaseFieldInfoConfig: IBaseFieldInfoConfig
    {
        private readonly BaseFieldInfoValues _fieldInfoValues;

        public BaseFieldInfoConfig(BaseFieldInfoValues fieldInfoValues)
        {
            _fieldInfoValues = fieldInfoValues;
        }

        public IDictionary<string, FieldInfo> Fields()
        {
            var fields = new Dictionary<string, FieldInfo>
            {
                {BaseFieldInfoKeys.Navigation,_fieldInfoValues.Navigation()},
                {BaseFieldInfoKeys.Summary,_fieldInfoValues.Summary()},
                {BaseFieldInfoKeys.ImageDescription,_fieldInfoValues.ImageDescription()},
            };

            return fields;
        }
    }
}
