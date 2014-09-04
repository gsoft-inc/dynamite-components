using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Lists;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public static class BaseCatalogInfoValues
    {
        #region News Pages Catalog

        public static readonly CatalogInfo NewsPages = new CatalogInfo()
        {
           ContentTypes = new List<ContentTypeInfo>()
           {
               {BaseContentTypeInfoValues.NewsItem}
           },

           RootFolderUrl = "NewsPages",
           DraftVisibilityType = DraftVisibilityType.Approver,
           EnableRatings = false,
           ListTemplate = SPListTemplateType.ListTemplateCatalog,
           Overwrite = false,
           RemoveDefaultContentType = true,
           TaxonomyFieldMap = BaseFieldInfoValues.Navigation,
           WriteSecurity = WriteSecurityOptions.AllUser,
           HasDraftVisibilityType = true
        };

        #endregion
    }
}
