using System.Collections.Generic;
using GSoft.Dynamite.Search;
using Microsoft.Office.Server.Search.Administration;
using ManagedPropertyInfo = GSoft.Dynamite.Search.ManagedPropertyInfo;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Search result types definitions for the publishing modules
    /// </summary>
    public static class PublishingResultTypeInfos
    {
        /// <summary>
        /// The news page result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public static ResultTypeInfo NewsPageResultType
        {
            get
            {
                return new ResultTypeInfo()
                {
                    Name = "Dynamite - News Page",
                    OptimizeForFrequenUse = true,
                    Priority = 1,
                    DisplayProperties = new List<ManagedPropertyInfo>() 
                    {
                        BuiltInManagedProperties.Title,
                        BuiltInManagedProperties.PublishingPageContent
                    },
                    Rules = new List<ResultTypeRuleInfo>()
                    {
                        new ResultTypeRuleInfo(
                                BuiltInManagedProperties.ContentTypeId,
                                PropertyRuleOperator.DefaultOperator.Contains,
                                new string[] { PublishingContentTypeInfos.NewsItem.ContentTypeId.ToString() })
                    }
                };                
            }
        }

        /// <summary>
        /// The content page result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public static ResultTypeInfo ContentPageResultType
        {
            get
            {
                return new ResultTypeInfo()
                {
                    Name = "Dynamite - Content Page",
                    OptimizeForFrequenUse = true,
                    Priority = 1,
                    DisplayProperties = new List<ManagedPropertyInfo>() 
                    {
                        BuiltInManagedProperties.Title,
                        BuiltInManagedProperties.PublishingPageContent
                    },
                    Rules = new List<ResultTypeRuleInfo>()
                    {
                        new ResultTypeRuleInfo(
                                BuiltInManagedProperties.ContentTypeId,
                                PropertyRuleOperator.DefaultOperator.Contains,
                                new string[] { PublishingContentTypeInfos.NewsItem.ContentTypeId.ToString() })
                    }
                }; 
            }
        }

        /// <summary>
        /// The catalog item result type
        /// </summary>
        /// <returns>The result type configuration object</returns>
        public static ResultTypeInfo CategoryItemResultType
        {
            get
            {
                return new ResultTypeInfo()
                {
                    Name = "Dynamite - Category Item",
                    OptimizeForFrequenUse = true,
                    Priority = 1,
                    DisplayProperties = new List<ManagedPropertyInfo>() 
                    {
                        BuiltInManagedProperties.Title,
                        BuiltInManagedProperties.PublishingImage
                    },
                    Rules = new List<ResultTypeRuleInfo>()
                    {
                        new ResultTypeRuleInfo(
                                BuiltInManagedProperties.ContentTypeId,
                                PropertyRuleOperator.DefaultOperator.Contains,
                                new string[] { PublishingContentTypeInfos.NewsItem.ContentTypeId.ToString() })
                    }
                }; 
            }
        }
    }
}
