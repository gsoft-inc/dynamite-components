using System.Collections.Generic;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    public class MultilingualismResultSourceInfoConfig : IMultilingualismResultSourceInfoConfig
    {
        private readonly MultilingualismResultSourceInfos _resultSourceValues;

        public MultilingualismResultSourceInfoConfig(MultilingualismResultSourceInfos resultSourceValues)
        {
            this._resultSourceValues = resultSourceValues;
        }

        public IList<ResultSourceInfo> ResultSources
        {
            get
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
}
