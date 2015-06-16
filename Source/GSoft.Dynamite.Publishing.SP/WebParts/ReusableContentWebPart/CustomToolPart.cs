using System.Web.UI.WebControls;
using Autofac;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using GSoft.Dynamite.Publishing.Contracts.Services;
using GSoft.Dynamite.ReusableContent;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace GSoft.Dynamite.Publishing.SP.WebParts.ReusableContentWebPart
{
    /// <summary>
    /// The custom tool part.
    /// </summary>
    public class CustomToolPart : ToolPart
    {
        /// <summary>
        /// The _reusable contents
        /// </summary>
        private readonly DropDownList reusableContents = new DropDownList();

        /// <summary>
        /// The _reusable content web part
        /// </summary>
        private ReusableContentWebPart reusableContentWebPart;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomToolPart"/> class.
        /// </summary>
        public CustomToolPart()
        {
            this.Title = "Select Reusable Content";
        }

        /// <summary>
        /// Called when the user clicks the OK or the Apply button in the tool pane.
        /// </summary>
        public override void ApplyChanges()
        {
            if (this.reusableContents.SelectedItem != null)
            {
                this.reusableContentWebPart.ReusableContentTitle = this.reusableContents.SelectedValue;
            }

            base.ApplyChanges();
        }

        /// <summary>
        /// The create child controls.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.reusableContentWebPart = this.ParentToolPane.SelectedWebPart as ReusableContentWebPart;

            var reusableContentHelper = PublishingContainerProxy.Current.Resolve<IReusableContentHelper>();

            var reusableContentTitles = reusableContentHelper.GetAllReusableContentTitles(SPContext.Current.Site);

            foreach (var reusableHtmlContentTitle in reusableContentTitles)
            {
                this.reusableContents.Items.Add(reusableHtmlContentTitle);
            }

            // Default selection on an existing value
            if (!string.IsNullOrEmpty(this.reusableContentWebPart.ReusableContentTitle))
            {
                var selectedItem = this.reusableContents.Items.FindByValue(this.reusableContentWebPart.ReusableContentTitle);
                if (selectedItem != null)
                {
                    selectedItem.Selected = true;
                }
            }

            this.Controls.Add(this.reusableContents);

            base.CreateChildControls();
        }
    }
}
