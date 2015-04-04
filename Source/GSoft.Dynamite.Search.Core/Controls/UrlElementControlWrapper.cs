using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Search.Core.Controls
{
    /// <summary>
    /// The public Url Element Control Wrapper class.
    /// </summary>
    public class UrlElementControlWrapper : TemplatedControlWrapper
    {
        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.ContentTemplateContainer != null)
            {
                // get content template
                var template = new StringBuilder();
                using (var stringWriter = new StringWriter(template))
                {
                    using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
                    {
                        this.ContentTemplateContainer.RenderControl(htmlTextWriter);
                    }
                }
                
                var currentPageUrl = SPUtility.GetPageUrlPath(HttpContext.Current);
                if (currentPageUrl != null)
                {
                    writer.Write(template.ToString().Replace("$Value$", Uri.EscapeUriString(currentPageUrl)));
                }
            }
        }
    }
}
