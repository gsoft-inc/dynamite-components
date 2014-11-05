using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Publishing.Contracts.WebParts;

namespace GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart
{
    /// <summary>
    /// User Control for the Filtered Product Showcase Web Part 
    /// </summary>
    public partial class FilteredProductShowcaseWebPartUserControl : UserControl
    {
        private string SelectPropertiesSerialized
        {
            get
            {
                return string.Join(",", this.SelectProperties);
            }
        }

        private string FilterDefinitionsSerialized
        {
            get
            {
                var serializer = new JavaScriptSerializer();

                return serializer.Serialize(this.FilterDefinitions);
            }
        }

        /// <summary>
        /// The search Query
        /// </summary>
        public string SearchQuery { get; set; }

        /// <summary>
        /// The properties selected in the query
        /// </summary>
        public IList<string> SelectProperties { get; set; }

        /// <summary>
        /// The Definitions of the different filters
        /// </summary>
        public IList<ShowcaseFilterDefinition> FilterDefinitions { get; set; }

        /// <summary>
        /// Event handler when the page is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
