using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Catalog definitions for the publishing module
    /// </summary>
    public static class PublishingCatalogInfos
    {
        #region News Pages Catalog

        /// <summary>
        /// The news pages catalog that contains only catalog pages typed items
        /// </summary>
        /// <returns>The catalog info</returns>
        public static CatalogInfo NewsPages 
        { 
            get 
            {
                return new CatalogInfo(
                    "NewsPages",
                    PublishingResources.NewsCatalogTitle,
                    PublishingResources.NewsCatalogDescription)
                {
                    Overwrite = false,
                    IsAnonymous = true,
                    EnableRatings = false,
                    AddToQuickLaunch = true,
                    EnableAttachements = false,
                    HasDraftVisibilityType = true,
                    RemoveDefaultContentType = true,
                    WriteSecurity = WriteSecurityOptions.AllUser,
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    ListTemplateInfo = BuiltInListTemplates.CustomList,
                    ManagedProperties = new List<ManagedPropertyInfo>()
                    {
                        new ManagedPropertyInfo("ListItemID")
                    },
                };
            }
        }

        #endregion

        #region Content Pages Catalog

        /// <summary>
        /// The content pages catalog that contains only target pages typed items
        /// </summary>
        /// <returns>The catalog info</returns>
        public static CatalogInfo ContentPages
        {
            get
            {
                return new CatalogInfo(
                    "ContentPages",
                    PublishingResources.ContentCatalogTitle,
                    PublishingResources.ContentCatalogDescription)
                {
                    Overwrite = false,
                    IsAnonymous = true,
                    EnableRatings = false,
                    AddToQuickLaunch = true,
                    EnableAttachements = false,
                    HasDraftVisibilityType = true,
                    RemoveDefaultContentType = true,
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    ListTemplateInfo = BuiltInListTemplates.CustomList,
                    WriteSecurity = WriteSecurityOptions.AllUser,
                    ManagedProperties = new List<ManagedPropertyInfo>()
                    {
                        new ManagedPropertyInfo("ListItemID")
                    },
                };
            }
        }

        #endregion
    }
}
