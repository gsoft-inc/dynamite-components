using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Lists;
using Microsoft.SharePoint;
using GSoft.Dynamite.Taxonomy;
using System;
using GSoft.Dynamite.ValueTypes;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base CatalogInfo values
    /// </summary>
    public class BasePublishingCatalogInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = BasePublishingResources.Global;
        private readonly BasePublishingContentTypeInfos _contentTypeInfoValues;
        private readonly BasePublishingFieldInfos _fieldInfoValues;
        private readonly BasePublishingTermGroupInfos _termGroupValues;
        private readonly BasePublishingTermInfos _termInfoValues;
        private readonly BasePublishingTermSetInfos _termSetInfoValues;

        public BasePublishingCatalogInfos(IResourceLocator resourceLocator,
            BasePublishingContentTypeInfos contentTypeInfoValues,
            BasePublishingFieldInfos fieldInfoValues,
            BasePublishingTermGroupInfos termGroupValues,
            BasePublishingTermInfos termInfoValues,
            BasePublishingTermSetInfos termSetInfoValues
            )
        {
            this._resourceLocator = resourceLocator;
            this._contentTypeInfoValues = contentTypeInfoValues;
            this._fieldInfoValues = fieldInfoValues;
            this._termGroupValues = termGroupValues;
            this._termInfoValues = termInfoValues;
            this._termSetInfoValues = termSetInfoValues;
        }

        #region News Pages Catalog

        public CatalogInfo NewsPages()
        {
            // News pages editors should be limited to a different taxonomy term set
            var customizedNavigationField = this._fieldInfoValues.Navigation();
            customizedNavigationField.TermStoreMapping = new TaxonomyContext()
                {
                    Group = _termGroupValues.Restricted(),
                    TermSet = _termSetInfoValues.RestrictedNews()
                };

            // News pages should be automatically tagged with the "Financial" term
            var customizedDefaultValue = new TaxonomyFullValue()
            {
                Context = customizedNavigationField.TermStoreMapping,
                Term = new TermInfo(
                    new Guid("{61639a70-1c62-42a4-a265-7533d27bbf65}"),
                    "Financial",
                    _termSetInfoValues.RestrictedNews())
            };

            customizedNavigationField.DefaultValue = customizedDefaultValue;

            return new CatalogInfo(
                    "NewsPages",
                    BasePublishingResources.NewsCatalogTitle,
                    BasePublishingResources.NewsCatalogDescription
                    )
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        _contentTypeInfoValues.NewsItem()
                    },
                    DraftVisibilityType = DraftVisibilityType.Approver,
                    EnableRatings = false,
                    ListTemplate = SPListTemplateType.GenericList,
                    Overwrite = false,
                    RemoveDefaultContentType = true,
                    TaxonomyFieldMap = _fieldInfoValues.Navigation(),
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
                    IsAnonymous = true
                };
        }

        #endregion

        #region Content Pages Catalog

        public CatalogInfo ContentPages()
        {
            return new CatalogInfo(
                "ContentPages",
                BasePublishingResources.ContentCatalogTitle,
                BasePublishingResources.ContentCatalogDescription)
            {
                ContentTypes = new List<ContentTypeInfo>()
                {
                    this._contentTypeInfoValues.ContentItem()
                },
                DraftVisibilityType = DraftVisibilityType.Approver,
                EnableRatings = false,
                ListTemplate = SPListTemplateType.GenericList,
                Overwrite = false,
                RemoveDefaultContentType = true,
                TaxonomyFieldMap = _fieldInfoValues.Navigation(),
                EnforceUniqueNavigationValues = true,
                WriteSecurity = WriteSecurityOptions.AllUser,
                HasDraftVisibilityType = true,
                ManagedProperties = new List<ManagedPropertyInfo>()
                {
                    {new ManagedPropertyInfo("ListItemID")}
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
