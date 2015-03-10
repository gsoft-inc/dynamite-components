using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Autofac;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Security;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.SP.Features.CrossSitePublishingCMS_SeoFields
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("bccbefd1-ec8c-4b00-a9e8-8955d5b334d2")]
    public class CrossSitePublishingCMS_SeoFieldsEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event
        /// </summary>
        /// <param name="properties">Context properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            if (site != null)
            {
                using (var featureScope = SearchContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
                {
                    var fieldHelper = featureScope.Resolve<IFieldHelper>();
                    var contentTypeHelper = featureScope.Resolve<IContentTypeHelper>();
                    var fieldInfoConfig = featureScope.Resolve<ISearchFieldInfoConfig>();
                    var contentTypeInfos = featureScope.Resolve<PublishingContentTypeInfos>();
                    var fields = fieldInfoConfig.Fields;
                    var logger = featureScope.Resolve<ILogger>();

                    var browsableItem = contentTypeInfos.BrowsableItem();

                    foreach (var field in fields)
                    {
                        browsableItem.Fields.Add(field);
                    }

                    using (new Unsafe(site.RootWeb))
                    {
                        contentTypeHelper.EnsureContentType(site.RootWeb.ContentTypes, browsableItem);
                    }
                }
            }
        }
    }
}
