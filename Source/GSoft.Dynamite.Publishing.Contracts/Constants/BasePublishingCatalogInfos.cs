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
            return new CatalogInfo()
            {
                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BasePublishingResources.NewsCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BasePublishingResources.NewsCatalogTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BasePublishingResources.NewsCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BasePublishingResources.NewsCatalogDescription,new CultureInfo(1036))}
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
                    {this._fieldInfoValues.Navigation()}
                },

                DefaultValues = new Dictionary<FieldInfo, IFieldInfoValue>()
                {
                    {this._fieldInfoValues.Navigation(), new TaxonomyFieldInfoValue()
                        {
                            TermGroup = _termGroupValues.Restricted(),
                            TermSet = _termSetInfoValues.RestrictedNews(),
                            Values = new TermInfo[]
                            {
                                new TermInfo(){Name = "Financial"}
                            
                            }
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
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BasePublishingResources.ContentCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BasePublishingResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,BasePublishingResources.ContentCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,BasePublishingResources.ContentCatalogDescription,new CultureInfo(1036))}
                },

                ContentTypes = new List<ContentTypeInfo>()
                {
                    {this._contentTypeInfoValues.ContentItem()}
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
                    {this._fieldInfoValues.Navigation()}
                },

                IsAnonymous = true
            };
        }

        #endregion
    }
}
