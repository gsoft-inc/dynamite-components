using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Portal.Contracts.Config;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.SiteColumns;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Core.Config
{
    public class DefaultCatalogConfig : IPortalCatalogConfig
    {
        private IPortalTermStoreConfig termStoreConfig;
        private IResourceLocator resourceLocator;

        /// <summary>
        /// Creates a new instance of the default Portal Catalogs configuration
        /// </summary>
        /// <param name="resourceLocator"></param>
        public DefaultCatalogConfig(IPortalTermStoreConfig termStoreConfig, IResourceLocator resourceLocator)
        {
            this.termStoreConfig = termStoreConfig;
            this.resourceLocator = resourceLocator;
        }

        /// <summary>
        /// By default, all authoring webs hold the same catalogs.
        /// Override this implementation with your own to specify different catalogs per web.
        /// Be sure to keep this config in sync with the CatalogConnections.xml.template
        /// search configuration file.
        /// </summary>
        /// <param name="web">The current web where we want to create content catalogs</param>
        /// <returns></returns>
        public IList<Catalog> CatalogDefinitionsForWeb(SPWeb web)
        {
            var catalogConfigs = new List<Catalog>();
            
            // StaticContent Catalog
            var staticContentCatalog = new Catalog()
            {
                RootFolderUrl = PortalLists.ContentRootUrl,
                Overwrite = true,
                RemoveDefaultContentType = true,
                DisplayName = this.resourceLocator.Find(PortalResources.ListStaticContentCatalogTitle, (int)web.Language),
                Description = string.Empty,
                ListTemplate = SPListTemplateType.GenericList,
                TaxonomyFieldMap = PortalFields.Navigation.InternalName,
                DraftVisibilityType = DraftVisibilityType.Approver,
                HasDraftVisibilityType = true,
                EnableRatings = false,
                WriteSecurity = WriteSecurityOptions.OwnerOnly,
                ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.ContentItemContentTypeId },
                Segments = new List<SiteColumnField>()
                {
                    new TaxoField()
                    {
                        InternalName = PortalFields.Navigation.InternalName,
                        DisplayName = string.Empty,
                        Description = string.Empty,
                        IsRequired = true,
                        Group = "Portal",
                        IsMultiple = false,
                        IsOpen = false,
                        TermSetGroupName = termStoreConfig.CatalogsGroup,
                        TermSetName = termStoreConfig.StaticContentCatalogTermSet
                    }
                },
                ManagedProperties = new List<string>() { PortalManagedProperties.PortalDateSlug, PortalManagedProperties.ListItemID, PortalManagedProperties.PortalSlug },
            };

            catalogConfigs.Add(staticContentCatalog);

            // News Catalog
            var newsCatalog = new Catalog()
            {
                RootFolderUrl = PortalLists.NewsRootUrl,
                Overwrite = true,
                RemoveDefaultContentType = true,
                DisplayName = this.resourceLocator.Find(PortalResources.ListNewsCatalogTitle, (int)web.Language),
                Description = string.Empty,
                ListTemplate = SPListTemplateType.GenericList,
                TaxonomyFieldMap = PortalFields.Navigation.InternalName,
                DraftVisibilityType = DraftVisibilityType.Approver,
                HasDraftVisibilityType = true,
                EnableRatings = false,
                WriteSecurity = WriteSecurityOptions.OwnerOnly,
                ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.NewsItemContentTypeId },
                Segments = new List<SiteColumnField>()
                {
                    new TaxoField()
                    {
                        InternalName = PortalFields.Navigation.InternalName,
                        DisplayName = string.Empty,
                        Description = string.Empty,
                        IsRequired = true,
                        Group = "Portal",
                        IsMultiple = false,
                        IsOpen = false,
                        TermSetGroupName = termStoreConfig.CatalogsGroup,
                        TermSetName = termStoreConfig.NewsCatalogTermSet
                    }
                },
                DefaultValues = new List<SiteColumnField>()
                {
                    new TaxoField()
                    {
                        InternalName = PortalFields.Navigation.InternalName,
                        TermSetGroupName = termStoreConfig.CatalogsGroup,
                        TermSetName = termStoreConfig.NewsCatalogTermSet,
                        DefaultValues = new List<string>() { "News" }
                    }
                },
                ManagedProperties = new List<string>() { PortalManagedProperties.PortalDateSlug, PortalManagedProperties.ListItemID, PortalManagedProperties.PortalSlug },
            };

            catalogConfigs.Add(newsCatalog);

            // Mode Description Catalog
            var nodeDescriptionCatalog = new Catalog()
            {
                RootFolderUrl = PortalLists.NodeDescriptionRootUrl,
                Overwrite = true,
                RemoveDefaultContentType = true,
                DisplayName = this.resourceLocator.Find(PortalResources.ListNodeDescriptionCatalogTitle, (int)web.Language),
                Description = string.Empty,
                ListTemplate = SPListTemplateType.GenericList,
                TaxonomyFieldMap = string.Empty,
                DraftVisibilityType = DraftVisibilityType.Approver,
                HasDraftVisibilityType = true,
                EnableRatings = false,
                WriteSecurity = WriteSecurityOptions.OwnerOnly,
                ContentTypeIds = new List<SPContentTypeId>() { PortalContentTypes.NodeDescriptionItemContentTypeId },
                Segments = new List<SiteColumnField>()
                {
                    new TaxoField()
                    {
                        InternalName = PortalFields.Navigation.InternalName,
                        DisplayName = string.Empty,
                        Description = string.Empty,
                        IsRequired = true,
                        Group = "Portal",
                        IsMultiple = false,
                        IsOpen = false,
                        TermSetGroupName = termStoreConfig.CatalogsGroup,
                        TermSetName = termStoreConfig.StaticContentCatalogTermSet
                    }
                }
            };

            catalogConfigs.Add(nodeDescriptionCatalog);

            return catalogConfigs;
        }
    }
}
