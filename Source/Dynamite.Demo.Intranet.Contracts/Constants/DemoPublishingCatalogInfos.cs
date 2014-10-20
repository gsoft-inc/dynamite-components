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
    public class DemoPublishingCatalogInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = DynamiteDemoResources.Global;
        private readonly DemoPublishingContentTypeInfos _contentTypeInfoValues;
        private readonly PublishingFieldInfos _fieldInfoValues;

        public DemoPublishingCatalogInfos(IResourceLocator resourceLocator,
            DemoPublishingContentTypeInfos contentTypeInfoValues,
            PublishingFieldInfos fieldInfoValues)
        {
            _resourceLocator = resourceLocator;
            _contentTypeInfoValues = contentTypeInfoValues;
            _fieldInfoValues = fieldInfoValues;
        }

        #region Content Pages Catalog

        public CatalogInfo DynamiteCatalog()
        {
            return new CatalogInfo(
                    "DynamitePages",
                    DynamiteDemoResources.DynamiteCatalogTitle,
                    DynamiteDemoResources.DynamiteCatalogDescription)
                {
                    ContentTypes = new List<ContentTypeInfo>()
                    {
                        _contentTypeInfoValues.DynamiteItem()
                    },
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
                        new ManagedPropertyInfo("ListItemID")
                    },
                    AddToQuickLaunch = true,
                    DefaultViewFields = new List<IFieldInfo>()
                    {
                        _fieldInfoValues.Navigation()
                    },
                    IsAnonymous = true
                };
        }

        #endregion
    }
}
