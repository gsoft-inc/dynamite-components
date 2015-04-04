using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace GSoft.Dynamite.Search.Core.Controls.Templates
{
    /// <summary>
    /// The public implementation for the MetaTag Template class
    /// </summary>
    public class MetaTagTemplate : ITemplate
    {
        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="attributeName">The meta tag attribute name</param>
        /// <param name="attributeValue">The meta tag attribute value</param>
        public MetaTagTemplate(string attributeName, string attributeValue)
        {
            this.AttributeName = attributeName;
            this.AttributeValue = attributeValue;
        }

        /// <summary>
        /// The meta tag attribute name
        /// </summary>
        /// <value>
        /// The label of the name attribute of the meta tag.
        /// </value>
        public string AttributeName { get; set; }

        /// <summary>
        /// The meta tag attribute value
        /// </summary>
        /// <value>
        /// The value of the attribute of the meta tag.
        /// </value>
        public string AttributeValue { get; set; }

        /// <summary>
        /// Instantiates the Control and adds it into the container
        /// </summary>
        /// <param name="container">The Template container</param>
        public void InstantiateIn(Control container)
        {
            if (!string.IsNullOrEmpty(this.AttributeName) && !string.IsNullOrEmpty(this.AttributeValue))
            {
                var label = new LiteralControl();

                label.Text = string.Format("<meta {0}=\"{1}\" content=\"$Value$\" />", this.AttributeName, this.AttributeValue);

                container.Controls.Add(label);
            }
        }
    }
}
