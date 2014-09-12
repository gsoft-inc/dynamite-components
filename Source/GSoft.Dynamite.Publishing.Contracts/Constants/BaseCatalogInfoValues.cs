using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Definitions.Values;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Lists;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base CatalogInfo values
    /// </summary>
    public class BaseCatalogInfoValues
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = BaseResources.Global;
        private readonly BaseContentTypeInfoValues _contentTypeInfoValues;
        private readonly BaseFieldInfoValues _fieldInfoValues;
        private readonly BaseTermGroupInfoValues _termGroupValues;
        private readonly BaseTermInfoValues _termInfoValues;
        private readonly BaseTermSetInfoValues _termSetInfoValues;

        public BaseCatalogInfoValues(IResourceLocator resourceLocator,
            BaseContentTypeInfoValues contentTypeInfoValues,
            BaseFieldInfoValues fieldInfoValues,
            BaseTermGroupInfoValues termGroupValues,
            BaseTermInfoValues termInfoValues,
            BaseTermSetInfoValues termSetInfoValues
            )
        {
            _resourceLocator = resourceLocator;
            _contentTypeInfoValues = contentTypeInfoValues;
            _fieldInfoValues = fieldInfoValues;
            _termGroupValues = termGroupValues;
            _termInfoValues = termInfoValues;
            _termSetInfoValues = termSetInfoValues;
        }

        #region News Pages Catalog

        public CatalogInfo NewsPages()
        {
            return new CatalogInfo()
            {
                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.NewsCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.NewsCatalogTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.NewsCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.NewsCatalogDescription,new CultureInfo(1036))}
                },

                ContentTypes = new List<ContentTypeInfo>()
                {
                    {_contentTypeInfoValues.NewsItem()}
                },

                RootFolderUrl = "NewsPages",
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
                    {new ManagedPropertyInfo("ListItemID")}
                },

                AddToQuickLaunch = true,

                DefaultViewFields = new List<FieldInfo>()
                {
                    {_fieldInfoValues.Navigation()}
                },

                DefaultValues = new Dictionary<FieldInfo, IFieldInfoValue>()
                {
                    {_fieldInfoValues.Navigation(), new TaxonomyFieldInfoValue()
                        {
                            TermGroup = _termGroupValues.Restricted(),
                            TermSet = _termSetInfoValues.RestrictedNews()
                        }
                    }
                },
                
                IsAnonymous = true
            };
        }

        #endregion

        #region Content Pages Catalog

        public CatalogInfo ContentPages()
        {
            return new CatalogInfo()
            {
                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BaseResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                ContentTypes = new List<ContentTypeInfo>()
                {
                    {_contentTypeInfoValues.ContentItem()}
                },

                RootFolderUrl = "ContentPages",
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

                DefaultViewFields = new List<FieldInfo>()
                {
                    {_fieldInfoValues.Navigation()}
                },

                IsAnonymous = true
            };
        }

        #endregion
    }
}
