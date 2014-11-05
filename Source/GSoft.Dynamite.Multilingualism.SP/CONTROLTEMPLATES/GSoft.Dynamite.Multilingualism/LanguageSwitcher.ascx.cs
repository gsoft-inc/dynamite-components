using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Utils;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

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
            var multilingualismManagedPropertyInfos = MultilingualismContainerProxy.Current.Resolve<MultilingualismManagedPropertyInfos>();

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
                SelectedPropertiesJson = string.Format("['{0}']", multilingualismManagedPropertyInfos.ContentAssociationKey),
            };

            Controls.Add(catalogItemWebPart);
            //}
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            MultilingualismContainerProxy.Current.Resolve<ICatchallExceptionHandler>().Execute(SPContext.Current.Web, delegate()
            {
                var currentWebUrl = new Uri(SPContext.Current.Web.Url);
                var labels = this.LanguageSwitcherService.GetPeerVariationLabels(currentWebUrl, Variations.Current, SPContext.Current.Web.CurrentUser);

                if (labels != null && labels.Any())
                {
                    var formattedLabels = labels.Select(label => new
                    {
                        Title = Languages.TwoLetterISOLanguageNameToFullName(label.Title),
                        Url = this.LanguageSwitcherService.GetPeerUrl(label, this.AssociationKey).ToString()
                    }).ToList();

                    this.LabelsRepeater.DataSource = formattedLabels;
                    this.LabelsRepeater.DataBind();
                }
            });               
            
            base.Render(writer);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LanguageSwitcherService = MultilingualismContainerProxy.Current.Resolve<ILanguageSwitcherService>();
        }
    }
}
