using System;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Globalization;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DemoPublishingFieldInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;

        public DemoPublishingFieldInfos(IResourceLocator resourceLocator)
        {
            _resourceLocator = resourceLocator;
        }

        #region Field prefix

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string FieldPrefix = "DynamiteDemo";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The dynamite demo column information
        /// </summary>
        /// <returns>The Navigation field</returns>
        public TextFieldInfo DynamiteDemoColumn()
        {
            return new TextFieldInfo(
                FieldPrefix,
                new Guid("{3FBEC11F-DBCF-40E4-BD93-485BA321F564}"),
                DynamiteDemoResources.FieldDynamiteDemoColumnTitle,
                DynamiteDemoResources.FieldDynamiteDemoColumnDescription,
                DynamiteDemoResources.FieldGroup
                )
            {
                DefaultValue = "Demo",
                Required = RequiredTypes.Required
            };
        }

        #endregion
    }
}
