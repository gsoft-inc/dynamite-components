using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;

namespace GSoft.Dynamite.Search.Contracts.Constants
{
    /// <summary>
    /// Search managed properties for the search module
    /// </summary>
    public static class SearchManagedPropertyInfos
    {
        /// We map the custom crawled properties to the default managed properties of sharepoint (seo)
        /// in order to use the default seo publishing features of sharepoint
        #region SharePoint OOTB Managed Properties

        /// <summary>
        /// The OOTB Browser Title managed property
        /// </summary>
        public static ManagedPropertyInfo BrowserTitle
        {
            get
            {
                return new ManagedPropertyInfo(
                    "SeoBrowserTitleOWSTEXT",
                    ManagedDataType.Text)
                    {
                        CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_q_TEXT_DynamiteBrowserTitle", 1 }
                        },
                        RespectPriority = true,
                        Retrievable = true,
                    };
            }
        }

        /// <summary>
        /// The OOTB Meta Description managed property
        /// </summary>
        public static ManagedPropertyInfo MetaDescription
        {
            get
            {
                return new ManagedPropertyInfo(
                    "SeoMetaDescriptionOWSTEXT",
                    ManagedDataType.Text)
                {
                    CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_q_TEXT_DynamiteMetaDescription", 1 }
                        },
                    RespectPriority = true,
                    Retrievable = true,
                };
            }
        }

        /// <summary>
        /// The OOTB Meta Keywords managed property
        /// </summary>
        public static ManagedPropertyInfo MetaKeywords
        {
            get
            {
                return new ManagedPropertyInfo(
                    "SeoKeywordsOWSTEXT",
                    ManagedDataType.Text)
                {
                    CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_q_TEXT_DynamiteMetaKeywords", 1 }
                        },
                    RespectPriority = true,
                    Retrievable = true,
                };
            }
        }

        /// <summary>
        /// The OOTB Meta Keywords managed property
        /// </summary>
        public static ManagedPropertyInfo RobotsNoIndex
        {
            get
            {
                return new ManagedPropertyInfo(
                    "RobotsNoIndexOWSBOOL",
                    ManagedDataType.Text)
                {
                    CrawledProperties = new Dictionary<string, int>()
                        {
                            { "ows_q_BOOL_DynamiteRobotsNoIndex", 1 }
                        },
                    RespectPriority = true,
                    Retrievable = true,
                };
            }
        }

        #endregion
    }
}
