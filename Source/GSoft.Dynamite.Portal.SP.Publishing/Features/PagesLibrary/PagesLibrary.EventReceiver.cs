using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autofac;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.SiteColumns;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Publishing.Features.PagesLibrary
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>
    [Guid("fab0f2ff-f84c-46fb-81df-80d68aca7fb7")]
    public class PagesLibraryEventReceiver : SPFeatureReceiver
    {
        /// <summary>
        /// Feature activated event receiver
        /// </summary>
        /// <param name="properties">The feature receiver properties</param>
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var web = properties.Feature.Parent as SPWeb;

            using (var featureScope = PublishingContainerProxy.BeginFeatureLifetimeScope(properties.Feature))
            {
                var catalogBuilder = featureScope.Resolve<CatalogBuilder>();

                var contentCatalog = new Catalog()
                {
                    RootFolderUrl = PortalLists.PagesRootUrl,
                    Overwrite = false,
                    RemoveDefaultContentType = false,
                    DisplayName = PortalLists.PagesRootUrl,
                    Description = string.Empty,
                    ListTemplate = (SPListTemplateType)850,
                    TaxonomyFieldMap = string.Empty,
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    EnableRatings = false,
                    Segments = new List<SiteColumnField>()
                    {
                        new TextField()
                        {
                            InternalName = PortalFields.PageLanguage.InternalName,
                            DisplayName = "PageLanguageFieldName",
                            Description = "PageLanguageFieldName",
                            Group = "Portal",
                            IsMultiline = false
                        }
                    },
                    DefaultValues = new List<SiteColumnField>()
                    {
                        new TextField()
                        {
                            InternalName = PortalFields.PageLanguage.InternalName,
                            DefaultValues = new List<string>()
                            { 
                                web.Language == Language.English.Culture.LCID ? Language.English.Culture.TwoLetterISOLanguageName : Language.French.Culture.TwoLetterISOLanguageName
                            }
                        }
                    }
                };

                catalogBuilder.ProcessCatalog(web, contentCatalog);
            }
        }
    }
}
