using System;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Globalization;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    /// <summary>
    /// Fields definitions for the Dynamite demo module
    /// </summary>
    public class DemoPublishingFieldInfos
    {
        #region Field prefix

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string FieldPrefix = "DynamiteDemo";

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public DemoPublishingFieldInfos()
        {
        }
        
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
                DynamiteDemoResources.FieldGroup)
            {
                DefaultValue = "Demo",
                Required = RequiredType.Required
            };
        }

        #endregion
    }
}
