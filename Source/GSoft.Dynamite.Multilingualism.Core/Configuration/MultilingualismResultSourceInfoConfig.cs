using System.Collections.Generic;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Search result sources configuration for the multilingualism module
    /// </summary>
    public class MultilingualismResultSourceInfoConfig : IMultilingualismResultSourceInfoConfig
    {
        private readonly MultilingualismResultSourceInfos _resultSourceValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceValues">The result sources settings from the multilingualism module</param>
        public MultilingualismResultSourceInfoConfig(MultilingualismResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        /// <summary>
        /// Property that return all the result sources to create or configure in the multilingualism module
        /// </summary>
        /// <returns>The result source settings for the multilingualism module</returns>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                var resultSources = new List<ResultSourceInfo>
                {
                    this._resultSourceValues.SingleTargetItem(),
                    this._resultSourceValues.SingleCatalogItem(),
                    this._resultSourceValues.CatalogCategoryItems()
                };

                return resultSources;
            }
        }
    }
}
