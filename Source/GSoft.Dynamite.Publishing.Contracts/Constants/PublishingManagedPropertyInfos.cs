using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingManagedPropertyInfos
    {
        /// <summary>
        /// The navigation managed property name
        /// </summary>
        public ManagedPropertyInfo Navigation = new ManagedPropertyInfo("owstaxIdDynamiteNavigation",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_taxId_DynamiteNavigation", 1}
            },
            RespectPriority = true
        };

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

        /// <summary>
        /// Title
        /// </summary>
        public ManagedPropertyInfo Title = new ManagedPropertyInfo("Title", ManagedDataType.Text);

        /// <summary>
        /// PublishingPageContent
        /// </summary>
        public ManagedPropertyInfo PublishingPageContent = new ManagedPropertyInfo("PublishingPageContentOWSHTML", ManagedDataType.Text);  

        #endregion
    }
}
