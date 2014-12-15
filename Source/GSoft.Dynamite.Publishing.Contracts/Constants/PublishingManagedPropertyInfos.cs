using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Search managed properties for the publishing module
    /// </summary>
    public class PublishingManagedPropertyInfos
    {
        /// <summary>
        /// The navigation managed property name
        /// </summary>
        public ManagedPropertyInfo Navigation
        {
            get
            {
                return new ManagedPropertyInfo("owstaxIdDynamiteNavigation", ManagedDataType.Text);
            }
        }

        /// <summary>
        /// The navigation text managed property
        /// </summary>
        public ManagedPropertyInfo NavigationText
        {
            get
            {
                return new ManagedPropertyInfo(
                    "DynamiteNavigationOWSTEXT",
                    ManagedDataType.Text)
                    {
                        CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_DynamiteNavigation", 1 }
                        },
                        RespectPriority = true,
                        Retrievable = true,
                    };
            }
        } 

        /// <summary>
        /// The summary text managed property
        /// </summary>
        public ManagedPropertyInfo Summary
        {
            get
            {
                return new ManagedPropertyInfo(
                    "DynamiteSummaryOWSMTXT",
                    ManagedDataType.Text)
                    {
                        CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_r_MTXT_DynamiteSummary", 1 }
                        },
                        RespectPriority = true
                    };
                }
        } 

        #region SharePoint builtin Managed Properties

        /// <summary>
        /// The OOTB ListItemId managed property
        /// </summary>
        public ManagedPropertyInfo ListItemId 
        {
            get
            {
                return new ManagedPropertyInfo("ListItemID", ManagedDataType.Text);
            }
        } 

        /// <summary>
        /// The OOTB ContentTypeId managed property
        /// </summary>
        public ManagedPropertyInfo ContentTypeId
        {
            get
            {
                return new ManagedPropertyInfo("ContentTypeId", ManagedDataType.Text);
            }
        } 

        /// <summary>
        /// The OOTB Title managed property
        /// </summary>
        public ManagedPropertyInfo Title
        {
            get
            {
                return new ManagedPropertyInfo("Title", ManagedDataType.Text);
            }
        } 

        /// <summary>
        /// The OOTB PublishingPageContent managed property
        /// </summary>
        public ManagedPropertyInfo PublishingPageContent
        {
            get
            {
                return new ManagedPropertyInfo("PublishingPageContentOWSHTML", ManagedDataType.Text);
            }
        }

        /// <summary>
        /// The OOTB PublishingImage managed property
        /// </summary>
        public ManagedPropertyInfo PublishingImage
        {
            get
            {
                return new ManagedPropertyInfo("PublishingImage", ManagedDataType.Text);
            }
        }

        #endregion
    }
}
