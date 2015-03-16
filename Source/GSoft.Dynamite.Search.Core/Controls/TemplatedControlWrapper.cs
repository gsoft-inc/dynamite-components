using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace GSoft.Dynamite.Search.Core.Controls
{
    /// <summary>
    /// The Template Control Wrapper class.
    /// </summary>
    public class TemplatedControlWrapper : ControlWrapper
    {
        /// <summary>
        /// The Control Container
        /// </summary>
        public Control ContentTemplateContainer { get; set; }
        
        /// <summary>
        /// The render base only field.
        /// </summary>
        public bool RenderBaseOnly { get; set; }

        /// <summary>
        /// The control template
        /// </summary>
        public ITemplate ContentTemplate { get; set; }

        /// <summary>
        /// Creates child controls
        /// </summary>
        protected override void CreateChildControls()
        {
            if (this.ContentTemplate != null)
            {
                this.ContentTemplateContainer = new Control();
                this.ContentTemplate.InstantiateIn(this.ContentTemplateContainer);
            }

            base.CreateChildControls();
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.RenderBaseOnly)
            {
                base.Render(writer);
            }
            else
            {
                if (this.ContentTemplateContainer != null)
                {
                    // render template
                    var template = new StringBuilder();
                    using (var stringWriter = new StringWriter(template))
                    {
                        using (var htmlTextWriter = new HtmlTextWriter(stringWriter))
                        {
                            this.ContentTemplateContainer.RenderControl(htmlTextWriter);
                        }
                    }

                    // render base
                    var baseControl = new StringBuilder();
                    using (var sw = new StringWriter(baseControl))
                    {
                        using (var htw = new HtmlTextWriter(sw))
                        {
                            base.Render(htw);
                        }
                    }

                    // Add the meta control if the value is not empty
                    if (!string.IsNullOrEmpty(baseControl.ToString()))
                    {
                        writer.Write(template.ToString().Replace("$Value$", baseControl.ToString()));
                    }
                }
            }
        }
    }
}
