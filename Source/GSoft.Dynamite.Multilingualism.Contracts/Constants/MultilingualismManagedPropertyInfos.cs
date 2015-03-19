using System.Collections.Generic;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Search managed properties for the multilingualism module
    /// </summary>
    public class MultilingualismManagedPropertyInfos
    {
        /// <summary>
        /// The content association key managed property
        /// </summary>
        public ManagedPropertyInfo ContentAssociationKey
        {
            get
            {
                return new ManagedPropertyInfo("DynamiteContentAssociationKeyOWSGUID", ManagedDataType.Text)
                {
                    CrawledProperties = new Dictionary<string, int>()
                {
                    { "ows_q_GUID_DynamiteContentAssociationKey", 1 },
                    { "ows_DynamiteContentAssociationKey", 2 },
                },
                    RespectPriority = true,
                    Queryable = true,
                    Retrievable = true,
                    Searchable = false,
                    Refinable = false,
                };
            }
        }

        /// <summary>
        /// The item language managed property
        /// </summary>
        public ManagedPropertyInfo ItemLanguage
        {
            get
            {
                return new ManagedPropertyInfo("DynamiteItemLanguageOWSTEXT", ManagedDataType.Text)
                {        
                    CrawledProperties = new Dictionary<string, int>()
                    {
                        { "ows_q_TEXT_DynamiteItemLanguage", 1 },
                        { "ows_DynamiteItemLanguage", 2 },
                    },
                    RespectPriority = true,
                    Queryable = true,
                    Refinable = true,
                    Retrievable = true,
                    Searchable = true
                };
            }
        }
    }
}
