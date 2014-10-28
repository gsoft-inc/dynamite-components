using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Definitions.ManagedPropertyInfo;

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
            RespectPriority = true
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
            RespectPriority = true
        };
    }
}
