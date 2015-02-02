using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace GSoft.Dynamite.Design.SP.CONTROLTEMPLATES.GSoft.Dynamite.Design.Bootstrap
{
    /// <summary>
    /// CSS Imports
    /// </summary>
    public partial class BootstrapCssImport : UserControl
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bootstrap core and custom safe registration 
            var dynamiteMultilingualismCss = new CssRegistration();
            dynamiteMultilingualismCss.ID = "DynamiteDesignCssBootstrapRegistration";
            dynamiteMultilingualismCss.After = "corev4.css";
            dynamiteMultilingualismCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Design.Bootstrap/CSS/bootstrap-custom.css", false));
            dynamiteMultilingualismCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Design.Bootstrap/CSS/bootstrap.css", false));
            this.Controls.Add(dynamiteMultilingualismCss);
        }
    }
}
