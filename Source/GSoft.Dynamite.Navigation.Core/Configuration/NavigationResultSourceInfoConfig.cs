using System.Collections.Generic;
using GSoft.Dynamite.Navigation.Contracts.Configuration;
using GSoft.Dynamite.Navigation.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Navigation.Core.Configuration
{
    public class NavigationResultSourceInfoConfig : INavigationResultSourceInfoConfig
    {
      
        private readonly NavigationResultSourceInfos _resultSourceValues;

        public NavigationResultSourceInfoConfig(NavigationResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        public IList<ResultSourceInfo> ResultSources()
        {
            var resultSources = new List<ResultSourceInfo>
            {
                {_resultSourceValues.SingleTargetItem()},
                {_resultSourceValues.SingleCatalogItem()}
            };

            return resultSources;
        }
    }
}
