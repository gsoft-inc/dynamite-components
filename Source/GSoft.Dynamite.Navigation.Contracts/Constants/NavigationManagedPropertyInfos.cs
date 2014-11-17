using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationManagedPropertyInfos
    {
        /// <summary>
        /// The date slug managed property name
        /// </summary>
        public ManagedPropertyInfo DateSlugManagedProperty = new ManagedPropertyInfo("DynamiteDateSlugOWSTEXT",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_q_TEXT_DynamiteDateSlug", 1},
                {"ows_DynamiteDateSlug", 2},
            },
            RespectPriority = true,
            Retrievable = true,
            Searchable = true,
            Refinable = true,
            Queryable = true
        };

        /// <summary>
        /// The title slug managed property name
        /// </summary>
        public ManagedPropertyInfo TitleSlugManagedProperty = new ManagedPropertyInfo("DynamiteTitleSlugOWSTEXT",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_q_TEXT_DynamiteTitleSlug", 1},
                {"ows_DynamiteTitleSlug", 2},
            },
            RespectPriority = true,
            Retrievable = true,
            Searchable = true,
            Refinable = true,
            Queryable = true
        };

        /// <summary>
        /// The occurrence link location managed property name
        /// </summary>
        public ManagedPropertyInfo OccurrenceLinkLocationManagedProperty = new ManagedPropertyInfo("owstaxIdDynamiteOccurrenceLinkLocation",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_taxId_DynamiteOccurrenceLinkLocation", 1}
            },
            RespectPriority = true,
            Retrievable = true,
            Searchable = true,
            // Important to set refinable to true for GPP|.. GP0| querying
            Refinable = true,
            // Important to keep the MultiValue = true for GPP|.. GP0| querying
            HasMultipleValues = true
        };

        /// <summary>
        /// The occurrence link location managed property name (Get directly the text value of the term)
        /// </summary>
        public ManagedPropertyInfo OccurrenceLinkLocationManagedPropertyText = new ManagedPropertyInfo("DynamiteOccurrenceLinkLocationOWSTEXT",
            ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_DynamiteOccurrenceLinkLocation", 1}
            },
            RespectPriority = true,
            Retrievable = true
        };
    }
}
