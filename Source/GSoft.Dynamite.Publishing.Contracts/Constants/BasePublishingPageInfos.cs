using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingPageInfos
    {
        private readonly BasePublishingPageLayoutInfo _pageLayoutInfo;
        private readonly BasePublishingContentTypeInfos _contentTypeInfo;

        public BasePublishingPageInfos(BasePublishingPageLayoutInfo pageLayoutInfo, BasePublishingContentTypeInfos contentTypeInfo)
        {
            this._pageLayoutInfo = pageLayoutInfo;
            this._contentTypeInfo = contentTypeInfo;
        }

        #region Target Item Page Template

        public PageInfo TargetItemPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "ItemTargetPageTemplate",
                Title = "Target Item Page Template",
                PageLayout = this._pageLayoutInfo.TargetItemPageLayout(),
                ContentTypeId = this._contentTypeInfo.Page().ContentTypeId
            };
        }

        #endregion

        #region Catalog Item Page Template

        public PageInfo CatalogItemPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "CatalogTargetPageTemplate",
                Title = "Catalog Item Page Template",
                PageLayout = this._pageLayoutInfo.CatalogItemPageLayout(),
                ContentTypeId = this._contentTypeInfo.Page().ContentTypeId
            };
        }

        #endregion
    }
}
