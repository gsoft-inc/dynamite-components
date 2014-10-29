using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.FieldTypes;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    public class PublishingFieldInfoConfig: IPublishingFieldInfoConfig
    {
        private readonly PublishingFieldInfos fieldInfoValues;

        public PublishingFieldInfoConfig(PublishingFieldInfos fieldInfoValues)
        {
            this.fieldInfoValues = fieldInfoValues;
        }

        public IList<IFieldInfo> Fields
        {
            get
            {
                var fields = new List<IFieldInfo>
                {
                    { this.fieldInfoValues.Navigation() },
                    { this.fieldInfoValues.Summary() },
                    { this.fieldInfoValues.ImageDescription() },
                };

                return fields;
            }
        }
    }
}
