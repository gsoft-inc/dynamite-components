using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace GSoft.Dynamite.Publishing.SP.WebParts.ContactFormWebPart
{
    public partial class ContactFormWebPartUserControl : UserControl
    {
        /// <summary>
        /// The email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The contact form template
        /// </summary>
        public string ContactFormTemplate { get; set; }

        /// <summary>
        /// Event handler when the page is loaded
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
