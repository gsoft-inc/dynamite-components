using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Binding;

namespace GSoft.Dynamite.Publishing.Contracts.Entities
{
    /// <summary>
    /// The reusable content class
    /// </summary>
    public class ReusableHtmlContent : BaseEntity
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        [Property("ReusableHtml")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        [Property("ContentCategory")]
        public string Category { get; set; }
    }
}
