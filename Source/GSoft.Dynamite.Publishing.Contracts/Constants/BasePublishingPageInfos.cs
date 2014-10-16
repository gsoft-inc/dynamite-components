using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingPageInfos
    {
        private readonly BasePublishingPageLayoutInfo _pageLayoutInfo;
        private readonly BasePublishingContentTypeInfos _contentTypeInfo;
        private readonly BasePublishingWebPartInfos _webaPartInfos;

        public BasePublishingPageInfos(BasePublishingPageLayoutInfo pageLayoutInfos, BasePublishingContentTypeInfos contentTypeInfos, BasePublishingWebPartInfos webaPartInfos)
        {
            this._pageLayoutInfo = pageLayoutInfos;
            this._contentTypeInfo = contentTypeInfos;
            this._webaPartInfos = webaPartInfos;
        }

        #region Target Item Page Template

        public PageInfo TargetItemPageTemplate()
        {
            return new PageInfo()
            {
                FileName = "ItemTargetPageTemplate",
                Title = "Target Item Page Template",
                PageLayout = this._pageLayoutInfo.TargetItemPageLayout(),
                ContentTypeId = this._contentTypeInfo.Page().ContentTypeId,
                WebParts = new Dictionary<string, WebPartInfo>()
                {
                    {"Main",this._webaPartInfos.TargetItemContentWebPart()}
                }
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
                ContentTypeId = this._contentTypeInfo.Page().ContentTypeId,
                WebParts = new Dictionary<string, WebPartInfo>()
                {
                    {"Main",this._webaPartInfos.CatalogItemContentWebPart()}
                }
            };
        }

        #endregion
    }
}
