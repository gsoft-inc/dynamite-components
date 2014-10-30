using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public class MultilingualismManagedPropertyInfos
    {
        /// <summary>
        /// The content association key managed property name
        /// </summary>
        public ManagedPropertyInfo ContentAssociationKey = new ManagedPropertyInfo("DynamiteContentAssociationKeyOWSGUID", ManagedDataType.Text)
        {
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_q_GUID_DynamiteContentAssociationKey", 1},
                {"ows_DynamiteContentAssociationKey", 2},
            },
            RespectPriority = true
        };

        /// <summary>
        /// The item language
        /// </summary>
        public ManagedPropertyInfo ItemLanguage = new ManagedPropertyInfo("DynamiteItemLanguageOWSTEXT", ManagedDataType.Text)
        {        
            CrawledProperties = new Dictionary<string, int>()
            {
                {"ows_q_TEXT_DynamiteItemLanguage", 1},
                {"ows_DynamiteItemLanguage", 2},
            },
            RespectPriority = true
        };
    }
}
