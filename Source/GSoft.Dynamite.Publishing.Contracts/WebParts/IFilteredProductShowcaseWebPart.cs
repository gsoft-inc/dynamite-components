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
        string SelectProperties { get; set; }

        /// <summary>
        /// The list of filters to implement
        /// </summary>
        string FilterDefinitions { get; set; }

        /// <summary>
        /// The knockout template name
        /// </summary>
        string ItemKnockoutTemplate { get; set; }

        /// <summary>
        /// The View Model name
        /// </summary>
        string ItemJavaScriptViewModel { get; set; }

        /// <summary>
        /// Callback functions names
        /// </summary>
        string Callbacks { get; set; }
    }
}
