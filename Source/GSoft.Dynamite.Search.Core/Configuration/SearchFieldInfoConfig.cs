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
        /// <summary>   
        /// Property that return all the fields to create in the search module
        /// </summary>
        /// <returns>The fields</returns>
        public IList<BaseFieldInfo> Fields
        {
            get
            {
                var fields = new List<BaseFieldInfo>()
                {
                    SearchFieldInfos.BrowserTitle,
                    SearchFieldInfos.MetaDescription,
                    SearchFieldInfos.MetaKeywords,
                    SearchFieldInfos.HideFromInternetSearchEngines
                };

                return fields;
            }
        }

        /// <summary>
        /// Gets the field from the Fields property where the id of that field is passed by parameter.
        /// </summary>
        /// <param name="fieldId">The unique identifier of the field we are looking for.</param>
        /// <returns>
        /// The field information.
        /// </returns>
        public BaseFieldInfo GetFieldById(Guid fieldId)
        {
            return this.Fields.Single(f => f.Id.Equals(fieldId));
        }
    }
}
