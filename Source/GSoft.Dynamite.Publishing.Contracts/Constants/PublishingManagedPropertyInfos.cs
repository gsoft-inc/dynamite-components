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
            RespectPriority = true,
            Retrievable = true,
            // Important to keep the MultiValue = true for GPP|.. GP0| querying
            HasMultipleValues = true
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
            RespectPriority = true,
            Retrievable = true,
        };
   
        /// <summary>
        /// The summary text managed property name
        /// </summary>
        public ManagedPropertyInfo Summary = new ManagedPropertyInfo("DynamiteSummaryOWSMTXT",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_r_MTXT_DynamiteSummary", 1}
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

        /// <summary>
        /// PublishingPageContent
        /// </summary>
        public ManagedPropertyInfo PublishingImage = new ManagedPropertyInfo("PublishingImage", ManagedDataType.Text);  

        #endregion
    }
}
