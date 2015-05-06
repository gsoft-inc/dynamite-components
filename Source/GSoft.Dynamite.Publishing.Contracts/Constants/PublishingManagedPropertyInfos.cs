using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Search managed properties for the publishing module
    /// </summary>
    public static class PublishingManagedPropertyInfos
    {
        /// <summary>
        /// Gets the navigation taxonomy managed property.
        /// </summary>
        /// <value>
        /// The managed property information.
        /// </value>
        public static ManagedPropertyInfo Navigation
        {
            get
            {
                return new ManagedPropertyInfo(
                    "owstaxIdDynamiteNavigation",
                    ManagedDataType.Text)
                {
                    CrawledProperties = new Dictionary<string, int>()
                    {
                        { "ows_taxid_DynamiteNavigation", 1 }
                    },
                    RespectPriority = true,
                    Searchable = true,
                    Queryable = true,
                    Retrievable = true,
                    HasMultipleValues = true,
                    SafeForAnonymous = true,
                    OverwriteIfAlreadyExists = false
                };
            }
        } 

        /// <summary>
        /// The navigation text managed property
        /// </summary>
        public static ManagedPropertyInfo NavigationText
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
        public static ManagedPropertyInfo Summary
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
    }
}
