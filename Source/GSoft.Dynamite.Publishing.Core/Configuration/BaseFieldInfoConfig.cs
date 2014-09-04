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
        private readonly IResourceLocator _resourceLocator; 

        public BaseFieldInfoConfig(IResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        public IDictionary<string, FieldInfo> Fields()
        {
            var resourceFileName = BaseResources.Global;

            // Get resources strings
            BaseFieldInfoValues.Navigation.DisplayName = _resourceLocator.GetResourceString(resourceFileName,BaseResources.FieldPortalNavigationName);
            BaseFieldInfoValues.Navigation.Description = _resourceLocator.GetResourceString(resourceFileName,BaseResources.FieldPortalNavigationDescription);
            BaseFieldInfoValues.Navigation.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldGroup);

            BaseFieldInfoValues.Summary.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldPortalSummaryName);
            BaseFieldInfoValues.Summary.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldPortalSummaryDescription);
            BaseFieldInfoValues.Summary.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldGroup);

            BaseFieldInfoValues.ImageDescription.DisplayName = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldPortalImageDescriptionName);
            BaseFieldInfoValues.ImageDescription.Description = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldPortalImageDescriptionDescription);
            BaseFieldInfoValues.ImageDescription.Group = _resourceLocator.GetResourceString(resourceFileName, BaseResources.FieldGroup);

            var fields = new Dictionary<string, FieldInfo>
            {
                {BaseFieldInfoKeys.Navigation,BaseFieldInfoValues.Navigation},
                {BaseFieldInfoKeys.Summary,BaseFieldInfoValues.Summary},
                {BaseFieldInfoKeys.ImageDescription,BaseFieldInfoValues.ImageDescription},
            };

            return fields;
        }
    }
}
