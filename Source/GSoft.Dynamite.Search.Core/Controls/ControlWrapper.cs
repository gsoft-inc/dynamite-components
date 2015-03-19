using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GSoft.Dynamite.Search.Core.Controls
{
    /// <summary>
    /// The public control wrapper class.
    /// </summary>
    [ParseChildren(ChildrenAsProperties = true)]
    public class ControlWrapper : Control
    {
        private Control control;

        /// <summary>
        /// The Control
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public string Control { get; set; }

        /// <summary>
        /// Initiate the page
        /// </summary>
        /// <param name="e">Event Arguments</param>
        protected override void OnInit(EventArgs e)
        {
            this.EnsureChildControls();
            base.OnInit(e);
        }

        /// <summary>
        /// Creates child controls
        /// </summary>
        protected override void CreateChildControls()
        {
            {
                this.control = GetControlFromXml(this.Control);

                if (this.control != null)
                {
                    Controls.Add(this.control);
                }
            }
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.control != null &&
                this.control.GetType().FullName == "Microsoft.SharePoint.Publishing.WebControls.SeoBrowserTitle")
            {
                var holder = Page.Master.FindControl("PlaceHolderPageTitle") as ContentPlaceHolder;

                if (holder != null)
                {
                    StringBuilder sb = new StringBuilder();
                    using (var sw = new StringWriter(sb))
                    {
                        using (var htw = new HtmlTextWriter(sw))
                        {
                            holder.RenderControl(htw);
                        }
                    }

                    writer.Write(sb.ToString().Trim());
                }
            }
            else
            {
                base.Render(writer);
            }
        }

        private static Control GetControlFromXml(string controlXml)
        {
            Control control = null;

            var parsedControl = XElement.Parse(controlXml);

            if (parsedControl.Attribute("assembly") != null &&
                parsedControl.Attribute("type") != null)
            {
                string controlAssembly = parsedControl.Attribute("assembly").Value;
                string controlType = parsedControl.Attribute("type").Value;

                IEnumerable<XAttribute> attributes = parsedControl.Attributes();
                Dictionary<string, string> properties = new Dictionary<string, string>(attributes.Count());
                foreach (XAttribute attribute in attributes)
                {
                    if (attribute.Name == "assembly" ||
                        attribute.Name == "type")
                    {
                        continue;
                    }

                    properties[attribute.Name.ToString()] = attribute.Value;
                }

                var assembly = Assembly.Load(controlAssembly);
                var type = assembly.GetType(controlType);
                control = (Control)Activator.CreateInstance(type);

                foreach (KeyValuePair<string, string> property in properties)
                {
                    SetFieldOrProperty(type, control, property.Key, property.Value);
                }
            }

            return control;
        }

        private static void SetFieldOrProperty(Type controlType, Control control, string propertyName, string propertyValue)
        {
            var flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase;
            var property = controlType.GetProperty(propertyName, flags);

            if (property != null)
            {
                var propertyType = property.PropertyType;
                property.SetValue(control, Convert.ChangeType(propertyValue, propertyType, null));
            }
            else
            {
                var field = controlType.GetField(propertyName, flags);

                if (field != null)
                {
                    var fieldType = field.FieldType;
                    field.SetValue(control, Convert.ChangeType(propertyValue, fieldType, null));
                }
            }
        }
    }
}
