using System.Collections.Generic;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Search;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    /// <summary>
    /// Catalogs definitions for the Dynamite demo module
    /// </summary>
    public class DemoPublishingCatalogInfos
    {
        private readonly DemoPublishingContentTypeInfos _contentTypeInfoValues;
        private readonly PublishingFieldInfos _fieldInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="contentTypeInfoValues">The content types from the Dynamite demo module</param>
        /// <param name="fieldInfoValues">The fields definitions from the publishing module</param>
        public DemoPublishingCatalogInfos(
            DemoPublishingContentTypeInfos contentTypeInfoValues,
            PublishingFieldInfos fieldInfoValues)
        {
            this._contentTypeInfoValues = contentTypeInfoValues;
            this._fieldInfoValues = fieldInfoValues;
        }

        #region Content Pages Catalog

        /// <summary>
        /// Demo catalog
        /// </summary>
        /// <returns>The catalog info</returns>
        public CatalogInfo DynamiteCatalog()
        {
            return new CatalogInfo(
                    "DynamitePages",
                    DynamiteDemoResources.DynamiteCatalogTitle,
                    DynamiteDemoResources.DynamiteCatalogDescription)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this._contentTypeInfoValues.DynamiteItem()
                    },
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    EnableRatings = false,
                    ListTemplate = SPListTemplateType.GenericList,
                    Overwrite = false,
                    RemoveDefaultContentType = true,
                    TaxonomyFieldMap = this._fieldInfoValues.Navigation(),
                    EnforceUniqueNavigationValues = false,
                    WriteSecurity = WriteSecurityOptions.AllUser,
                    HasDraftVisibilityType = true,
                    ManagedProperties = new List<ManagedPropertyInfo>()
                    {
                        new ManagedPropertyInfo("ListItemID")
                    },
                    AddToQuickLaunch = true,
                    DefaultViewFields = new List<IFieldInfo>()
                    {
                        this._fieldInfoValues.Navigation()
                    },
                    IsAnonymous = true
                };
        }

        #endregion
    }
}
