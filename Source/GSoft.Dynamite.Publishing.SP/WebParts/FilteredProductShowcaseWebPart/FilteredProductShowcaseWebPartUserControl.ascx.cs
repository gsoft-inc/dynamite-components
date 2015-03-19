using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Publishing.Contracts.WebParts;
using GSoft.Dynamite.Utils;

namespace GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart
{
    /// <summary>
    /// User Control for the Filtered Product Showcase Web Part 
    /// </summary>
    public partial class FilteredProductShowcaseWebPartUserControl : UserControl
    {
        /// <summary>
        /// The search Query
        /// </summary>
        public string SearchQuery { get; set; }

        /// <summary>
        /// The properties selected in the query
        /// </summary>
        public string SelectProperties { get; set; }

        /// <summary>
        /// The Definitions of the different filters
        /// </summary>
        public string FilterDefinitions { get; set; }

        /// <summary>
        /// Knockout Template Name
        /// </summary>
        public string ItemKnockoutTemplate { get; set; }

        /// <summary>
        /// The View Model name
        /// </summary>
        public string ItemJavaScriptViewModel { get; set; }

        /// <summary>
        /// Callback function names
        /// </summary>
        public string Callbacks { get; set; }

        /// <summary>
        /// Event handler when the page is loaded
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
