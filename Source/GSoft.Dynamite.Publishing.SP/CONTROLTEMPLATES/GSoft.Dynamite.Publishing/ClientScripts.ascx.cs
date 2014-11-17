using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Branding;
using GSoft.Dynamite.Utils;

namespace GSoft.Dynamite.Publishing.SP.CONTROLTEMPLATES.GSoft.Dynamite.Publishing
{
    /// <summary>
    /// Control for JavaScript and CSS import
    /// </summary>
    public partial class ClientScripts : UserControl
    {   
        /// <summary>
        /// Event Receiver for the Page Load event on the User Control
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Add version tag to JS link
            this.DynamitePublishingScriptLink.Name = Minification.MinifyPathIfNotDebug(this.DynamitePublishingScriptLink.Name + "?v=" + VersionContext.CurrentVersionTag);
        }
    }
}
