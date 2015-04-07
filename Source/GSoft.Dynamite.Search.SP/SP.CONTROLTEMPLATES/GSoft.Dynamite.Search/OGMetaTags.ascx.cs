using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using GSoft.Dynamite.Search.Core.Controls;
using GSoft.Dynamite.Search.Core.Controls.Templates;

namespace GSoft.Dynamite.Search.SP.SP.CONTROLTEMPLATES.GSoft.Dynamite.Search
{
    /// <summary>
    /// The user control for the Social Meta Tags.
    /// </summary>
    public partial class OGMetaTags : SocialMetaTagsControl
    {
        /// <summary>
        /// On PreRender override
        /// </summary>
        /// <param name="e">Event Arguments</param>
        protected override void OnPreRender(EventArgs e)
        {
            var title = new TemplatedControlWrapper()
            {
                Control = this.GetCatalogItemReuseXmlControl(BuiltInManagedProperties.Title),
                ContentTemplate = new MetaTagTemplate("name", "og:title")
            };
            this.OpenGraph.Controls.Add(title);

            var description = new TemplatedControlWrapper()
            {
                Control = this.GetCatalogItemReuseXmlControl(BuiltInManagedProperties.MetaDescription),
                ContentTemplate = new MetaTagTemplate("name", "og:description")
            };
            this.OpenGraph.Controls.Add(description);

            var path = new UrlElementControlWrapper()
            {
                Control = this.GetCatalogItemReuseXmlControl(BuiltInManagedProperties.Url),
                ContentTemplate = new MetaTagTemplate("name", "og:url")
            };
            this.OpenGraph.Controls.Add(path);

            var picture = new ImageElementControlWrapper()
            {
                Control = this.GetCatalogItemReuseXmlControl(BuiltInManagedProperties.PublishingImage),
                ContentTemplate = new MetaTagTemplate("name", "og:image")
            };
            this.OpenGraph.Controls.Add(picture);
        }
    }
}
