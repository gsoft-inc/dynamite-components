using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
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
    /// <summary>
    /// Use control for the language switcher
    /// </summary>
    public partial class LanguageSwitcher : UserControl
    {
        private const string CatalogItemReuseWebPartId = "CatalogItemAssociationWebPart";

        /// <summary>
        /// The view model.
        /// </summary>
        public IVariationNavigationHelper VariationNavigationHelper { get; private set; }

        /// <summary>
        /// The variation navigation helper
        /// </summary>
        public IVariationHelper VariationsHelper { get; private set; }

        /// <summary>
        /// The multilingualism module managed properties
        /// </summary>
        public MultilingualismManagedPropertyInfos MultilingualismManagedPropertyInfos { get; private set; }

        /// <summary>
        /// The publishing module managed properties
        /// </summary>
        public PublishingManagedPropertyInfos PublishingManagedPropertyInfos { get; private set; }

        /// <summary>
        /// The publishing module web parts properties
        /// </summary>
        public PublishingWebPartInfos PublishingWebPartInfos { get; private set; }

        /// <summary>
        /// Get the current variation navigation context
        /// </summary>
        public VariationNavigationType CurrentNavigationContext { get; private set; }

        /// <summary>
        /// The variation navigation helper
        /// </summary>
        public IMultilingualismVariationsConfig MultilingualismVariationsConfig { get; private set; }

        /// <summary>
        /// The content association key fetched from the catalog item reuse web part.
        /// </summary>
        private string ContentAssociationKeyValue
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
            // If catalog item page, insert a CatalogItemReuseWebPart to fetch the association key for the
            // shared search results from the Content by Search Web Part
            if (this.CurrentNavigationContext == VariationNavigationType.ItemPage)
            {
                var catalogItemWebPart = new CatalogItemReuseWebPart()
                {
                    ID = CatalogItemReuseWebPartId,
                    NumberOfItems = 1,
                    UseSharedDataProvider = true,

                    // The query group name must be the same as the search webpart which display the current item to get the association key correctly
                    QueryGroupName = ((ResultScriptWebPart)this.PublishingWebPartInfos.CatalogItemContentWebPart(string.Empty).WebPart).QueryGroupName,
                    SelectedPropertiesJson = string.Format("['{0}']", this.MultilingualismManagedPropertyInfos.ContentAssociationKey.Name),
                };

                Controls.Add(catalogItemWebPart);
            }
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            MultilingualismContainerProxy.Current.Resolve<ICatchallExceptionHandler>().Execute(
                SPContext.Current.Web, 
                delegate
            {
                var currentWebUrl = new Uri(SPContext.Current.Web.Url);
                var labels = this.VariationsHelper.GetVariationLabels(currentWebUrl, true);
                var currentUrl = HttpContext.Current.Request.Url;
                var variationSettingsInfos = this.MultilingualismVariationsConfig.VariationSettings();

                var formattedLabels = new List<dynamic>();

                if (labels != null && labels.Any())
                {
                    foreach (VariationLabel label in labels)
                    {
                        var variationLabel = new VariationLabelInfo(label);

                        Uri itemUrl;
                        switch (this.CurrentNavigationContext)
                        {
                            case VariationNavigationType.ItemPage:
                                itemUrl = this.VariationNavigationHelper.GetPeerCatalogItemUrl(
                                    currentUrl,
                                    variationLabel,
                                    this.MultilingualismManagedPropertyInfos.ContentAssociationKey.Name,
                                    this.ContentAssociationKeyValue,
                                    this.MultilingualismManagedPropertyInfos.ItemLanguage.Name,
                                    this.PublishingManagedPropertyInfos.Navigation.Name);
                                break;

                            case VariationNavigationType.CategoryPage:
                                itemUrl = this.VariationNavigationHelper.GetPeerCatalogCategoryUrl(currentUrl, variationLabel);
                                break;

                            // Default SharePoint Page
                            default:
                                itemUrl = this.VariationNavigationHelper.GetPeerPageUrl(currentUrl, variationLabel);
                                break;
                        }

                        // Gets the default title value of the variation label
                        var title = Languages.TwoLetterISOLanguageNameToFullName(label.Title);
                        var cssClass = string.Empty;

                        // Gets a corresponding Variation Setting Info Object
                        var variationSettingsInfo = variationSettingsInfos.Labels.Where(variation => variation.Title == label.Title).FirstOrDefault();

                        // Updates the title if custom title is set
                        if (variationSettingsInfo != null)
                        {
                            if (!string.IsNullOrEmpty(variationSettingsInfo.CustomTitleValue))
                            {
                                title = variationSettingsInfo.CustomTitleValue; 
                            }

                            cssClass = variationSettingsInfo.CssClass;
                        }

                        var itemVariationInfo = new
                        {
                            Title = title,
                            Url = itemUrl,
                            CssClass = cssClass
                        };
                        
                        formattedLabels.Add(itemVariationInfo);
                    }

                    this.LabelsRepeater.DataSource = formattedLabels;
                    this.LabelsRepeater.DataBind();
                }
            });               
            
            base.Render(writer);
        }

        /// <summary>
        /// Event occurs on the page loading
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize helpers
            this.VariationNavigationHelper = MultilingualismContainerProxy.Current.Resolve<IVariationNavigationHelper>();
            this.VariationsHelper = MultilingualismContainerProxy.Current.Resolve<IVariationHelper>();
            this.PublishingManagedPropertyInfos = MultilingualismContainerProxy.Current.Resolve<PublishingManagedPropertyInfos>();
            this.MultilingualismManagedPropertyInfos = MultilingualismContainerProxy.Current.Resolve<MultilingualismManagedPropertyInfos>();
            this.PublishingWebPartInfos = MultilingualismContainerProxy.Current.Resolve<PublishingWebPartInfos>();
            this.MultilingualismVariationsConfig = MultilingualismContainerProxy.Current.Resolve<IMultilingualismVariationsConfig>();

            // Determine the navigation context type
            this.CurrentNavigationContext = this.VariationNavigationHelper.CurrentNavigationContextType;
        }
    }
}
