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
            var dynamiteBootstrapCss = new CssRegistration();
            dynamiteBootstrapCss.ID = "dynamiteBootstrapCss";
            dynamiteBootstrapCss.After = "corev4.css";
            dynamiteBootstrapCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Design.Bootstrap/CSS/bootstrap.css", false));
            this.Controls.Add(dynamiteBootstrapCss);

            var dynamiteBootstrapCustomCss = new CssRegistration();
            dynamiteBootstrapCustomCss.ID = "dynamiteBootstrapCustomCss";
            dynamiteBootstrapCustomCss.After = "corev4.css";
            dynamiteBootstrapCustomCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Design.Bootstrap/CSS/bootstrap-custom.css", false));
            this.Controls.Add(dynamiteBootstrapCustomCss);
        }
    }
}
