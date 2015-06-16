using System;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.ReusableContent;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.SP.CONTROLTEMPLATES.GSoft.Dynamite.Publishing
{
    /// <summary>
    /// User Control to display a Reusable Content
    /// </summary>
    public partial class ReusableContentUserControl : UserControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of the item in the reusable content library which should be displayed
        /// </summary>
        /// <value>
        /// The title of the reusable content list item
        /// </value>
        public string ReusableContentTitle { get; set; }

        /// <summary>
        /// Gets or sets the reusable content value.
        /// </summary>
        /// <value>
        /// The reusable content value.
        /// </value>
        public string ReusableContentValue { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var resourceLocator = PublishingContainerProxy.Current.Resolve<IResourceLocator>();
            var reusableContentHelper = PublishingContainerProxy.Current.Resolve<IReusableContentHelper>();

            if (!string.IsNullOrEmpty(this.ReusableContentTitle))
            {
                // Get the proper reusable content
                var reusableContent = reusableContentHelper.GetByTitle(SPContext.Current.Site, this.ReusableContentTitle);
                this.ReusableContentValue = reusableContent != null ? reusableContent.Content : resourceLocator.Find("ReusableContent_NoReusableContentFound");
            }
            else
            {
                this.ReusableContentValue = resourceLocator.Find("ReusableContent_InsertAReusableContentTitle");
            }
        }

        #endregion Methods
    }
}
