using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace GSoft.Dynamite.Multilingualism.SP.CONTROLTEMPLATES.GSoft.Dynamite.Multilingualism
{
    /// <summary>
    /// <c>CSS</c> Imports
    /// </summary>
    public partial class CssImports : UserControl
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Dynamite Core Registration
            var dynamiteMultilingualismCss = new CssRegistration();
            dynamiteMultilingualismCss.ID = "DynamiteMultilingualismCssRegistration";
            dynamiteMultilingualismCss.After = "corev4.css";
            dynamiteMultilingualismCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Multilingualism/CSS/GSoft.Dynamite.Multilingualism.css", false));
            this.Controls.Add(dynamiteMultilingualismCss);
        }
    }
}
