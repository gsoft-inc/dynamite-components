using System;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Definitions.Values;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.SiteColumns;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DynamiteDemoPublishingFieldInfoValues
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;

        public DynamiteDemoPublishingFieldInfoValues(IResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        #region Field prefix

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string FieldPrefix = "DynamiteDemo";

        #endregion

        #region Field internal names

        private static readonly string DynamiteDemoColumnFieldName = FieldPrefix + "DynamiteDemo";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The dynamite demo column information
        /// </summary>
        /// <returns>The Navigation field</returns>
        public TextFieldInfo DynamiteDemoColumn()
        {
            return new TextFieldInfo()
            {
                DisplayName =
                    _resourceLocator.GetResourceString(_resourceFileName,
                        DynamiteDemoResources.FieldDynamiteDemoColumnTitle),
                Description =
                    _resourceLocator.GetResourceString(_resourceFileName,
                        DynamiteDemoResources.FieldDynamiteDemoColumnDescription),
                Group = _resourceLocator.GetResourceString(_resourceFileName, DynamiteDemoResources.FieldGroup),
                InternalName = DynamiteDemoColumnFieldName,
                Id = new Guid("{3FBEC11F-DBCF-40E4-BD93-485BA321F564}"),
                // Default managed metadata mapping configuration
                DefaultValue = new TextFieldInfoValue()
                {
                    Values = new[] {"Demo"}
                },

                RequiredType = RequiredTypes.Required
            };
        }

        #endregion
    }
}
