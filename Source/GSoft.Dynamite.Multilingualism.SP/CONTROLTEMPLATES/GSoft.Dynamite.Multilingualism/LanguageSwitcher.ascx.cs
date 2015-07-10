using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Extensions;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Utils;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Multilingualism.SP.CONTROLTEMPLATES.GSoft.Dynamite.Multilingualism
{
    /// <summary>
    /// Use control for the language switcher
    /// </summary>
    public partial class LanguageSwitcher : UserControl
    {
        private const string CatalogItemReuseWebPartId = "CatalogItemAssociationWebPart";

        /// <summary>
        /// The Content Association Key Value
        /// </summary>
        private string contentAssociationKeyValue = null;

        /// <summary>
        /// The view model.
        /// </summary>
        public IVariationNavigationHelper VariationNavigationHelper { get; private set; }

        /// <summary>
        /// The variation navigation helper
        /// </summary>
        public IVariationHelper VariationsHelper { get; private set; }

        /// <summary>
        /// The publishing module web parts properties
        /// </summary>
        public IPublishingWebPartInfoConfig PublishingWebPartConfig { get; private set; }

        /// <summary>
        /// Gets the publishing field configuration.
        /// </summary>
        public IPublishingFieldInfoConfig PublishingFieldConfig { get; private set; }

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
                if (string.IsNullOrEmpty(this.contentAssociationKeyValue))
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
                    this.contentAssociationKeyValue = stringBuilder.ToString();
                }

                return this.contentAssociationKeyValue;
            }
        }
        
        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            MultilingualismContainerProxy.Current.Resolve<ICatchallExceptionHandler>().Execute(
                SPContext.Current.Web, 
                () =>
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
                            QueryGroupName = ((ResultScriptWebPart)this.PublishingWebPartConfig.GetWebPartInfoByTitle(PublishingWebPartInfos.CatalogItemContentWebPart.WebPart.Title).WebPart).QueryGroupName,
                            SelectedPropertiesJson = string.Format("['{0}']", MultilingualismManagedPropertyInfos.ContentAssociationKey.Name),
                        };

                        Controls.Add(catalogItemWebPart);
                    }
                });
        }

        /// <summary>
        /// Sends server control content to a provided <see cref="T:System.Web.UI.HtmlTextWriter" /> object, which writes the content to be rendered on the client.
        /// </summary>
        /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object that receives the server control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            SPContext.Current.Web.RunAsSystem(
                elevatedWeb =>
                {
                    MultilingualismContainerProxy.Current.Resolve<ICatchallExceptionHandler>().Execute(
                        elevatedWeb,
                        () =>
                        {
                            var currentWebUrl = new Uri(elevatedWeb.Url);
                            var labels = this.VariationsHelper.GetVariationLabels(currentWebUrl, true);
                            var currentUrl = HttpContext.Current.Request.Url;
                            var variationSettingsInfos = this.MultilingualismVariationsConfig.VariationSettings();
                            bool isPerfectPeerPageMatch = false;

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
                                            var navigationField = this.PublishingFieldConfig.GetFieldById(PublishingFieldInfos.Navigation.Id) as TaxonomyFieldInfo;
                                            itemUrl = this.VariationNavigationHelper.GetPeerCatalogItemUrl(
                                                currentUrl,
                                                variationLabel,
                                                MultilingualismManagedPropertyInfos.ContentAssociationKey.Name,
                                                this.ContentAssociationKeyValue,
                                                MultilingualismManagedPropertyInfos.ItemLanguage.Name,
                                                navigationField.OWSTaxIdManagedPropertyInfo.Name);
                                            break;

                                        case VariationNavigationType.CategoryPage:
                                            itemUrl = this.VariationNavigationHelper.GetPeerCatalogCategoryUrl(elevatedWeb, currentUrl, variationLabel);
                                            break;

                                        // Default SharePoint Page
                                        default:
                                            try
                                            {
                                                PublishingWeb publishingWeb = PublishingWeb.GetPublishingWeb(elevatedWeb);
                                                var peerWebUrls = publishingWeb.VariationPublishingWebUrls;

                                                // only keep the peer web under the target variation label that we want
                                                var peerWebUrl = peerWebUrls.Cast<string>().SingleOrDefault(p => p.StartsWith(label.TopWebUrl));    

                                                // First try for a perfect variation peer match
                                                itemUrl = new Uri(Variations.GetPeerUrl(elevatedWeb, currentUrl.AbsolutePath, label.Title), UriKind.Relative);

                                                // If we get a physical URL back, it's worth a shot trying to resolve the corresponding friendly URL
                                                if (itemUrl.ToString().EndsWith(".aspx") && !string.IsNullOrEmpty(peerWebUrl))
                                                {
                                                    using (SPSite site = new SPSite(peerWebUrl))
                                                    {
                                                        using (SPWeb peerWeb = site.OpenWeb())
                                                        {
                                                            PublishingWeb peerPublishingWeb = PublishingWeb.GetPublishingWeb(peerWeb);
                                                            PublishingPage peerPublishingPage = peerPublishingWeb.GetPublishingPage(itemUrl.ToString());

                                                            if (peerPublishingPage != null)
                                                            {
                                                                IList<NavigationTerm> navTermsPointingToPeerPage = TaxonomyNavigation.GetFriendlyUrlsForListItem(peerPublishingPage.ListItem, true);

                                                                if (navTermsPointingToPeerPage.Count > 0)
                                                                {
                                                                    NavigationTerm navigationTermPointingToPeerPage = navTermsPointingToPeerPage[0];
                                                                    string fullFriendlyUrl = navigationTermPointingToPeerPage.GetWebRelativeFriendlyUrl();

                                                                    // We got lucky and resolved a proper friendly Url of our peer page, even if Variations.GetPeerUrl
                                                                    // failed terribly at doing the same thing.
                                                                    // Note that all friendly URLs are TopWeb-relative.
                                                                    var itemUrlAsString = SPUtility.ConcatUrls(label.TopWebUrl, fullFriendlyUrl);

                                                                    itemUrl = new Uri(new Uri(itemUrlAsString).AbsolutePath, UriKind.Relative);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                                // Sometime we won't get an ArgOutOfRange exception, but still we didn't get a perfect match.
                                                // In those cases, the target web's ~site url is returned.
                                                if (itemUrl.ToString() != new Uri(label.TopWebUrl).AbsolutePath)
                                                {
                                                    isPerfectPeerPageMatch = true;
                                                }

                                                // Special case for home page
                                                if (SPContext.Current.ListItem != null
                                                && elevatedWeb.RootFolder.WelcomePage == SPContext.Current.ListItem.Url)
                                                {
                                                    var peerHomePageUrl = Regex.Replace(itemUrl.OriginalString, @"\/Pages\/.*", string.Empty);
                                                    itemUrl = new Uri(peerHomePageUrl, UriKind.Relative);
                                                    isPerfectPeerPageMatch = true;
                                                }
                                            }
                                            catch (ArgumentOutOfRangeException)
                                            {
                                                // Second, use the VariationNavHelper's "smart" logic to make a best guess at what the peer URL is.
                                                // This should work for mosts _layouts, subweb and list view URLs. 
                                                itemUrl = this.VariationNavigationHelper.GetPeerPageUrl(elevatedWeb, currentUrl, variationLabel);
                                            }

                                            break;
                                    }

                                    // Gets the default title value of the variation label
                                    var title = Languages.TwoLetterISOLanguageNameToFullName(label.Title);

                                    // Use a CSS class to help us hide the language switch if we didn't get a perfect match
                                    var labelCssClass = string.Empty;
                                    var linkCssClass = isPerfectPeerPageMatch ? string.Empty : "not-perfect-variation-peer-page-match ";

                                    // Gets a corresponding Variation Setting Info Object
                                    var variationLabelInfo = variationSettingsInfos.Labels.FirstOrDefault(variation => variation.Title == label.Title);

                                    // Updates the title if custom title is set
                                    if (variationLabelInfo != null)
                                    {
                                        if (!string.IsNullOrEmpty(variationLabelInfo.LanguageSwitchCustomTitle))
                                        {
                                            title = variationLabelInfo.LanguageSwitchCustomTitle;
                                        }

                                        labelCssClass += variationLabelInfo.LanguageSwitchCustomCssClass;
                                    }

                                    var itemVariationInfo = new
                                    {
                                        Title = title,
                                        Url = itemUrl,
                                        CssClass = labelCssClass,
                                        LinkCssClass = linkCssClass
                                    };

                                    formattedLabels.Add(itemVariationInfo);
                                }

                                this.LabelsRepeater.DataSource = formattedLabels;
                                this.LabelsRepeater.DataBind();
                            }
                        });
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
            this.PublishingWebPartConfig = MultilingualismContainerProxy.Current.Resolve<IPublishingWebPartInfoConfig>();
            this.MultilingualismVariationsConfig = MultilingualismContainerProxy.Current.Resolve<IMultilingualismVariationsConfig>();
            this.PublishingFieldConfig = MultilingualismContainerProxy.Current.Resolve<IPublishingFieldInfoConfig>();

            // Determine the navigation context type
            this.CurrentNavigationContext = this.VariationNavigationHelper.CurrentNavigationContextType;
        }
    }
}
