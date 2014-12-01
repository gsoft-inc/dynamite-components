using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    /// <summary>
    /// Result sources configuration for the navigation module
    /// </summary>
    public class NavigationResultSourceInfoConfig : INavigationResultSourceInfoConfig
    {   
        private readonly NavigationResultSourceInfos _resultSourceValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceValues">The result sources info objects configuration</param>
        public NavigationResultSourceInfoConfig(NavigationResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        /// <summary>
        /// Property that return all the result sources to create or configure in the navigation module
        /// </summary>
        public IList<ResultSourceInfo> ResultSources
        {
            get
            {
                var resultSources = new List<ResultSourceInfo>
                {
                    this._resultSourceValues.SingleTargetItem(),
                    this._resultSourceValues.SingleCatalogItem(),
                    this._resultSourceValues.AllMenuItems()
                };

                return resultSources;
            }
        }
    }
}
