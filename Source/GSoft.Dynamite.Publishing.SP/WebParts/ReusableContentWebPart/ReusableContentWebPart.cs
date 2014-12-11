using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using GSoft.Dynamite.Publishing.Contracts.WebParts;
using GSoft.Dynamite.Publishing.SP.CONTROLTEMPLATES.GSoft.Dynamite.Publishing;
using Microsoft.SharePoint.WebPartPages;

namespace GSoft.Dynamite.Publishing.SP.WebParts.ReusableContentWebPart
{ 
    /// <summary>
    /// Reusable content Web Part
    /// </summary>
    [ToolboxItemAttribute(false)]
    public class ReusableContentWebPart : WebPart, IReusableContentWebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string AscxPath = @"~/_CONTROLTEMPLATES/15/GSoft.Dynamite.Publishing/ReusableContentUserControl.ascx";

        private string reusableContentTitle = string.Empty;

        /// <summary>
        /// The _reusable contents.
        /// </summary>
        private IList<string> reusableContents = new List<string>();

        /// <summary>
        /// Gets or sets the reusable content title.
        /// </summary>
        /// <value>
        /// The reusable content title.
        /// </value>
        public string ReusableContentTitle
        {
            get
            {
                return this.reusableContentTitle;
            }

            set
            {
                this.reusableContentTitle = value;
            }
        }

        /// <summary>
        /// Determines which tool parts are displayed in the tool pane of the Web-based Web Part design user interface, and the order in which they are displayed.
        /// </summary>
        /// <returns>
        /// An array of type <see cref="T:Microsoft.SharePoint.WebPartPages.ToolPart" /> that determines which tool parts will be displayed in the tool pane. If a Web Part that implements one or more custom properties does not override the <see cref="M:Microsoft.SharePoint.WebPartPages.WebPart.GetToolParts" /> method, the base class method will return an instance of the <see cref="T:Microsoft.SharePoint.WebPartPages.WebPartToolPart" /> class and an instance of the <see cref="T:Microsoft.SharePoint.WebPartPages.CustomPropertyToolPart" /> class. An instance of the <see cref="T:Microsoft.SharePoint.WebPartPages.WebPartToolPart" /> class displays a tool part for working with the properties provided by the WebPart base class. An instance of the <see cref="T:Microsoft.SharePoint.WebPartPages.CustomPropertyToolPart" /> class displays a built-in tool part for working custom Web Part properties, as long as the custom property is of one of the types supported by that tool part. The supported types are: String, Boolean, Integer, DateTime, or Enumeration.
        /// </returns>
        public override ToolPart[] GetToolParts()
        {
            var toolparts = new ToolPart[3];
            var webPartToolPart = new WebPartToolPart();
            var customPropertyToolPart = new CustomPropertyToolPart();
            var customToolPart = new CustomToolPart();

            toolparts[0] = webPartToolPart;
            toolparts[1] = customPropertyToolPart;
            toolparts[2] = customToolPart;

            return toolparts;
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            var control = Page.LoadControl(AscxPath) as ReusableContentUserControl;
            if (control != null)
            {
                control.ReusableContentTitle = this.ReusableContentTitle;
                this.Controls.Add(control);
            }
        }
    }
}
