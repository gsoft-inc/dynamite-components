using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;

namespace GSoft.Dynamite.Search.Core.Configuration
{
    /// <summary>
    /// The fields configuration for the search module
    /// </summary>
    public class SearchFieldInfoConfig : ISearchFieldInfoConfig
    {
        private readonly SearchFieldInfos searchFieldInfos;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="searchFieldInfos">Field Info for the search module</param>
        public SearchFieldInfoConfig(SearchFieldInfos searchFieldInfos)
        {
            this.searchFieldInfos = searchFieldInfos;
        }

        /// <summary>   
        /// Property that return all the fields to create in the search module
        /// </summary>
        /// <returns>The fields</returns>
        public IList<IFieldInfo> Fields
        {
            get
            {
                var fields = new List<IFieldInfo>()
                {
                    { this.searchFieldInfos.BrowserTitle() },
                    { this.searchFieldInfos.MetaDescription() },
                    { this.searchFieldInfos.MetaKeywords() },
                    { this.searchFieldInfos.HideFromInternetSearchEngines() }
                };

                return fields;
            }
        }
    }
}
