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
        private readonly NavigationResultSourceInfos resultSourceValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="resultSourceValues">The result sources info objects configuration</param>
        public NavigationResultSourceInfoConfig(NavigationResultSourceInfos resultSourceValues)
        {
            this.resultSourceValues = resultSourceValues;
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
                    this.resultSourceValues.SingleTargetItem(),
                    this.resultSourceValues.SingleCatalogItem(),
                    this.resultSourceValues.AllMenuItems()
                };

                return resultSources;
            }
        }
    }
}
