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

        public string SelectProperties { get; set; }

        public string FilterDefinitions { get; set; }

        public string ItemKnockoutTemplate { get; set; }

        protected override void CreateChildControls()
        {
            var filteredProductShowcaseControl = Page.LoadControl(ascxPath) as FilteredProductShowcaseWebPartUserControl;

            if (filteredProductShowcaseControl != null)
            {
                filteredProductShowcaseControl.SearchQuery = this.SearchQuery;
                filteredProductShowcaseControl.SelectProperties = this.SelectProperties;
                filteredProductShowcaseControl.FilterDefinitions = this.FilterDefinitions;
                filteredProductShowcaseControl.ItemKnockoutTemplate = this.ItemKnockoutTemplate;

                this.Controls.Add(filteredProductShowcaseControl);
            }
        }
    }
}
