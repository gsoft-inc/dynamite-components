using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynamite.Demo.Intranet.Contracts.Resources;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public class DynamiteDemoPublishingCatalogInfoValues
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;
        private readonly DynamiteDemoPublishingContentTypeInfoValues _contentTypeInfoValues;
        private readonly BasePublishingFieldInfos _fieldInfoValues;

        public DynamiteDemoPublishingCatalogInfoValues(IResourceLocator resourceLocator,
            DynamiteDemoPublishingContentTypeInfoValues contentTypeInfoValues,
            BasePublishingFieldInfos fieldInfoValues)
        {
            _resourceLocator = resourceLocator;
            _contentTypeInfoValues = contentTypeInfoValues;
            _fieldInfoValues = fieldInfoValues;
        }

        #region Content Pages Catalog

        public CatalogInfo DynamiteCatalog()
        {
            return new CatalogInfo()
            {
                TitleResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.DynamiteCatalogTitle,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.DynamiteCatalogTitle,new CultureInfo(1036))}
                },

                DescriptionResources = new Dictionary<CultureInfo, string>()
                {
                    {new CultureInfo(1033),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.DynamiteCatalogDescription,new CultureInfo(1033))},
                    {new CultureInfo(1036),_resourceLocator.Find(_resourceFileName,DynamiteDemoResources.DynamiteCatalogDescription,new CultureInfo(1036))}
                },

                ContentTypes = new List<ContentTypeInfo>()
                {
                    {_contentTypeInfoValues.DynamiteItem()}
                },

                RootFolderUrl = "DynamitePages",
                DraftVisibilityType = DraftVisibilityType.Approver,
                EnableRatings = false,
                ListTemplate = SPListTemplateType.GenericList,
                Overwrite = false,
                RemoveDefaultContentType = true,
                TaxonomyFieldMap = _fieldInfoValues.Navigation(),
                EnforceUniqueNavigationValues = false,
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
