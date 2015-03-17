using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing.Fields;

namespace GSoft.Dynamite.Search.Core.Controls
{
    /// <summary>
    /// The Image Element Control Wrapper class.
    /// </summary>
    public class ImageElementControlWrapper : TemplatedControlWrapper
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

                // render only base control without the content template
                this.RenderBaseOnly = true;
                var baseControl = new StringBuilder();
                using (var stringWriter = new StringWriter(baseControl))
                {
                    using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
                    {
                        base.Render(htmlTextWriter);
                    }
                }

                // extract the url from the base control and render it in the template
                var hyperlinkHtml = baseControl.ToString();
                var image = new ImageFieldValue(HttpUtility.HtmlDecode(hyperlinkHtml));

                if (image != null)
                {
                    var imageUrl = image.ImageUrl;

                    // Fallback to logo if empty
                    if (string.IsNullOrEmpty(imageUrl))
                    {
                        imageUrl = Uri.UnescapeDataString(SPContext.Current.Web.SiteLogoUrl);
                    }

                    writer.Write(template.ToString().Replace("$Value$", Uri.EscapeUriString(imageUrl)));
                }
            }
        }
    }
}
