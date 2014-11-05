using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Publishing.Contracts.WebParts
{
    /// <summary>
    /// Interface for the filtered product showcase web part
    /// </summary>
    public interface IFilteredProductShowcaseWebPart
    {
        /// <summary>
        /// The Search Query
        /// </summary>
        string SearchQuery { get; set; }

        /// <summary>
        /// The properties to get in the query
        /// </summary>
        IList<string> SelectProperties { get; set; }

        /// <summary>
        /// The list of filters to implement
        /// </summary>
        IList<ShowcaseFilterDefinition> FilterDefinitions { get; set; }
    }
}
