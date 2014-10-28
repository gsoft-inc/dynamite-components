using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Definitions.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingManagedPropertyInfos
    {
        /// <summary>
        /// The navigation managed property name
        /// </summary>
        public ManagedPropertyInfo Navigation = new ManagedPropertyInfo("owstaxIdDynamiteNavigation", ManagedDataType.Text);

        /// <summary>
        /// The navigation text managed property name
        /// </summary>
        public ManagedPropertyInfo NavigationText = new ManagedPropertyInfo("DynamiteNavigationOWSTEXT",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_DynamiteNavigation", 1}
            },
            RespectPriority = true

        };
   
        #region SharePoint builtin Managed Properties

        /// <summary>
        /// List item Id
        /// </summary>
        public ManagedPropertyInfo ListItemId = new ManagedPropertyInfo("ListItemID", ManagedDataType.Text);

        /// <summary>
        /// ContentTypeId
        /// </summary>
        public ManagedPropertyInfo ContentTypeId = new ManagedPropertyInfo("ContentTypeId", ManagedDataType.Text);  

        #endregion
    }
}
