using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Publishing.Contracts.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace GSoft.Dynamite.Publishing.SP.WebParts.FilteredProductShowcaseWebPart
{
    /// <summary>
    /// WebPart to showcase product and fluid filters
    /// </summary>
    [ToolboxItemAttribute(false)]
    public class FilteredProductShowcaseWebPart : WebPart, IFilteredProductShowcaseWebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string ascxPath = @"~/_CONTROLTEMPLATES/15/GSoft.Dynamite.Publishing.SP.WebParts/FilteredProductShowcaseWebPart/FilteredProductShowcaseWebPartUserControl.ascx";

        /// <summary>
        /// Start date property name
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Search Query"), WebDescription(""), Category("Filtered Product Showcase")]
        public string SearchQuery { get; set; }

        /// <summary>
        /// The properties send to the query to be returned
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Select Properties"), WebDescription(""), Category("Filtered Product Showcase")]
        public string SelectProperties { get; set; }

        /// <summary>
        /// A list of serialized filter definitions. It contains The Managed Properties on which to filter.
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Filter Definitions"), WebDescription(""), Category("Filtered Product Showcase")]
        public string FilterDefinitions { get; set; }

        /// <summary>
        /// The name of the knockout template to use for each result item
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Item Knockout Template"), WebDescription(""), Category("Filtered Product Showcase")]
        public string ItemKnockoutTemplate { get; set; }

        /// <summary>
        /// The name of the view model javascript class to use for each result item
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Item Javascript View Model"), WebDescription(""), Category("Filtered Product Showcase")]
        public string ItemJavaScriptViewModel { get; set; }

        /// <summary>
        /// The name of the view model javascript class to use for each result item
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Callbacks"), WebDescription(""), Category("Filtered Product Showcase")]
        public string Callbacks { get; set; }

        protected override void CreateChildControls()
        {
            var filteredProductShowcaseControl = Page.LoadControl(ascxPath) as FilteredProductShowcaseWebPartUserControl;

            if (filteredProductShowcaseControl != null)
            {
                filteredProductShowcaseControl.SearchQuery = this.SearchQuery;
                filteredProductShowcaseControl.SelectProperties = this.SelectProperties;
                filteredProductShowcaseControl.FilterDefinitions = this.FilterDefinitions;
                filteredProductShowcaseControl.ItemKnockoutTemplate = this.ItemKnockoutTemplate;
                filteredProductShowcaseControl.ItemJavaScriptViewModel = this.ItemJavaScriptViewModel;
                filteredProductShowcaseControl.Callbacks = this.Callbacks;

                this.Controls.Add(filteredProductShowcaseControl);
            }
        }
    }
}
