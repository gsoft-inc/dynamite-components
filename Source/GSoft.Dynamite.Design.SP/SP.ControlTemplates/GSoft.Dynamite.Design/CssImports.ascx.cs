using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using GSoft.Dynamite.Design.Contracts.Configuration;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace GSoft.Dynamite.Design.SP.CONTROLTEMPLATES.GSoft.Dynamite.Design
{
    /// <summary>
    /// CSS Imports
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
            using (var scope = DesignContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
            {
                var designConfig = scope.Resolve<IBaseCssConfig>();

                if (designConfig.UseCoreDynamiteDesignCssFile)
                {
                    // Dynamite Core Registration
                    var dynamiteMultilingualismCss = new CssRegistration();
                    dynamiteMultilingualismCss.ID = "DynamiteDesignCssRegistration";
                    dynamiteMultilingualismCss.After = "corev4.css";
                    dynamiteMultilingualismCss.Name = SPUtility.ConcatUrls(SPContext.Current.Site.ServerRelativeUrl, SPUtility.MakeBrowserCacheSafeLayoutsUrl("GSoft.Dynamite.Design/CSS/GSoft.Dynamite.Design.css", false));
                    this.Controls.Add(dynamiteMultilingualismCss);
                }
            }
        }
    }
}
