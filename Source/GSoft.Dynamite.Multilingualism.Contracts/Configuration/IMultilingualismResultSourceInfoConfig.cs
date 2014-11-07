using System.Collections.Generic;
using GSoft.Dynamite.Search;

namespace GSoft.Dynamite.Multilingualism.Contracts.Configuration
{
    public interface IMultilingualismResultSourceInfoConfig
    {
        /// <summary>
        /// Property that return all the result source to create/update
        /// </summary>
        IList<ResultSourceInfo> ResultSources { get; }
    }
}
