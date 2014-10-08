using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Navigation;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Multilingualism.SP.CONTROLTEMPLATES.GSoft.Dynamite.Multilingualism
{
    public partial class LanguageSwitcher : UserControl
    {
        private const string CatalogItemReuseWebPartId = "CatalogItemAssociationWebPart";

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public ILanguageSwitcherService LanguageSwitcherService { get; private set; }

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        /// <value>
        /// The label text.
        /// </value>
        public string LabelText { get; set; }

        /// <summary>
        /// Gets or sets the label URL.
        /// </summary>
        /// <value>
        /// The label URL.
        /// </value>
        public string LabelUrl { get; set; }

        private string AssociationKey
        {
            get
            {
                var catalogItemWebPart = FindControl(CatalogItemReuseWebPartId);
                var stringBuilder = new StringBuilder();
                StringWriter stringWriter = null;
                try
                {
                    stringWriter = new StringWriter(stringBuilder);
                    using (var htmlWriter = new HtmlTextWriter(stringWriter))
                    {
                        catalogItemWebPart.RenderControl(htmlWriter);
                    }
                }
                finally
                {
                    if (stringWriter != null)
                    {
                        stringWriter.Dispose();
                    }
                }

                catalogItemWebPart.Visible = false;
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
             //If catalog item page, insert a CatalogItemReuseWebPart to fetch the association key for the
             //shared search results from the Content by Search Web Part
            //if (CatalogNavigationContext.Current.Type == CatalogNavigationType.ItemPage)
            //{
                var catalogItemWebPart = new CatalogItemReuseWebPart()
                {
                    ID = CatalogItemReuseWebPartId,
                    NumberOfItems = 1,
                    UseSharedDataProvider = true,
                    QueryGroupName = "Default",
                    SelectedPropertiesJson = string.Format("['{0}']", "ContentAssociationKeyOWSGUID"/*PortalManagedProperties.ContentAssociationKey*/),
                };

                Controls.Add(catalogItemWebPart);
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}
