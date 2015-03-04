using System;
using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Taxonomy;
using GSoft.Dynamite.ValueTypes;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Catalog definitions for the publishing module
    /// </summary>
    public class PublishingCatalogInfos
    {
        private readonly PublishingContentTypeInfos _contentTypeInfoValues;
        private readonly PublishingFieldInfos _fieldInfoValues;
        private readonly PublishingTermSetInfos _termSetInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="contentTypeInfoValues">The content type info objects configuration</param>
        /// <param name="fieldInfoValues">The field info objects configuration</param>
        /// <param name="termSetInfoValues">The term set info objects configuration</param>
        public PublishingCatalogInfos(
            PublishingContentTypeInfos contentTypeInfoValues,
            PublishingFieldInfos fieldInfoValues,
            PublishingTermSetInfos termSetInfoValues)
        {
            this._contentTypeInfoValues = contentTypeInfoValues;
            this._fieldInfoValues = fieldInfoValues;
            this._termSetInfoValues = termSetInfoValues;
        }

        #region News Pages Catalog

        /// <summary>
        /// The news pages catalog that contains only catalog pages typed items
        /// </summary>
        /// <returns>The catalog info</returns>
        public CatalogInfo NewsPages()
        {
            // News pages editors should be limited to a different taxonomy term set
            var customizedNavigationField = this._fieldInfoValues.Navigation();
            customizedNavigationField.TermStoreMapping = new TaxonomyContext()
                {
                    TermSet = this._termSetInfoValues.RestrictedNews()
                };

            // News pages should be automatically tagged with the "Financial" term
            var customizedDefaultValue = new TaxonomyValue()
            {
                Context = customizedNavigationField.TermStoreMapping,
                Term = new TermInfo(
                    new Guid("{61639a70-1c62-42a4-a265-7533d27bbf65}"),
                    "Financial",
                    this._termSetInfoValues.RestrictedNews())
            };

            customizedNavigationField.DefaultValue = customizedDefaultValue;

            return new CatalogInfo(
                    "NewsPages",
                    PublishingResources.NewsCatalogTitle,
                    PublishingResources.NewsCatalogDescription)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        this._contentTypeInfoValues.NewsItem()
                    },
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    EnableRatings = false,
                    ListTemplateInfo = BuiltInListTemplates.CustomList,
                    Overwrite = false,
                    RemoveDefaultContentType = true,
                    TaxonomyFieldMap = this._fieldInfoValues.Navigation(),
                    WriteSecurity = WriteSecurityOptions.AllUser,
                    HasDraftVisibilityType = true,
                    ManagedProperties = new List<ManagedPropertyInfo>()
                    {
                        new ManagedPropertyInfo("ListItemID")
                    },
                    AddToQuickLaunch = true,
                    DefaultViewFields = new List<IFieldInfo>()
                    {
                        customizedNavigationField
                    },
                    FieldDefinitions = new List<IFieldInfo>()
                    {
                       customizedNavigationField
                    },                
                    IsAnonymous = true,
                    EnableAttachements = false
                };
        }

        #endregion

        #region Content Pages Catalog

        /// <summary>
        /// The content pages catalog that contains only target pages typed items
        /// </summary>
        /// <returns>The catalog info</returns>
        public CatalogInfo ContentPages()
        {
            return new CatalogInfo(
                "ContentPages",
                PublishingResources.ContentCatalogTitle,
                PublishingResources.ContentCatalogDescription)
            {
                ContentTypes = new List<ContentTypeInfo>()
                {
                    this._contentTypeInfoValues.ContentItem()
                },
                DraftVisibilityType = DraftVisibilityType.Approver,
                EnableRatings = false,
                ListTemplateInfo = BuiltInListTemplates.CustomList,
                Overwrite = false,
                RemoveDefaultContentType = true,
                TaxonomyFieldMap = this._fieldInfoValues.Navigation(),
                EnforceUniqueNavigationValues = true,
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
                IsAnonymous = true,
                EnableAttachements = false
            };
        }

        #endregion
    }
}
