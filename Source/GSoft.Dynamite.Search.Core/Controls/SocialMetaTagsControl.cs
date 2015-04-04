using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace GSoft.Dynamite.Search.Core.Controls
{
    /// <summary>
    /// The Social Meta Tags Control public class.
    /// </summary>
    public class SocialMetaTagsControl : UserControl
    {
        /// <summary>
        /// Gets the XML definition of the Catalog Item Reuse WebPart with the selected managed property.
        /// </summary>
        /// <param name="managedPropertyName">The name of the managed property</param>
        /// <returns>The XML definition</returns>
        public string GetCatalogItemReuseXmlControl(string managedPropertyName)
        {
            return string.Format("<Control type=\"Microsoft.Office.Server.Search.WebControls.CatalogItemReuseWebPart\" assembly=\"Microsoft.Office.Server.Search, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c\" NumberOfItems=\"1\"  UseSharedDataProvider=\"True\" QueryGroupName=\"SingleItem\" SelectedPropertiesJson=\"['{0}']\"/>", managedPropertyName);
        }
    }
}
