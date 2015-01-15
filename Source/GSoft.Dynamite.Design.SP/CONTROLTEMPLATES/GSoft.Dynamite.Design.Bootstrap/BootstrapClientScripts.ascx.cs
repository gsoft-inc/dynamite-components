using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace GSoft.Dynamite.Design.SP.CONTROLTEMPLATES.GSoft.Dynamite.Design.Bootstrap
{
    /// <summary>
    /// JavaScript importer class
    /// </summary>
    public partial class BootstrapClientScripts : UserControl
    {
        /// <summary>
        /// At the load of the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MakeBrowserCacheSafeOrRemoveIfMissing(this.JQueryScriptLink);
            MakeBrowserCacheSafeOrRemoveIfMissing(this.BootstrapScriptLink);
            MakeBrowserCacheSafeOrRemoveIfMissing(this.BootstrapCustomScriptLink);
            MakeBrowserCacheSafeOrRemoveIfMissing(this.ModernizrScriptLink);
            MakeBrowserCacheSafeOrRemoveIfMissing(this.RespondScriptLink);
        }

        /// <summary>
        /// Cache the JS files or remove them from the User control
        /// </summary>
        /// <param name="scriptLink"></param>
        private static void MakeBrowserCacheSafeOrRemoveIfMissing(ScriptLink scriptLink)
        {
            try
            {
                // These are optional module, so trying to build these browser-cache-safe URLs may explode if the modules are missing
                scriptLink.Name = SPUtility.MakeBrowserCacheSafeLayoutsUrl(scriptLink.Name, false);
            }
            catch (SPException)
            {
                // Script not found, remove from page
                scriptLink.Parent.Controls.Remove(scriptLink);
            }
        }
    }
}
