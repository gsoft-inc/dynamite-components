using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace Dynamite.Demo.Intranet.Contracts.Constants
{
    public static class DynamiteDemoContentTypeInfoValues
    {
        #region My Content Item

        public static readonly ContentTypeInfo MyContentItem = new ContentTypeInfo()
        {
            Fields = new List<FieldInfo>()
            {
                BaseFieldInfoValues.Navigation
            },

            ContentTypeId = new SPContentTypeId(BaseContentTypeInfoValues.NewsItem.ContentTypeId + "01"),
            ContentGroupResourceKey = DynamiteDemoResources.ContentTypeGroup,
            DescriptionResourceKey = DynamiteDemoResources.ContentTypeMyContentItemDescription,
            TitleResourceKey = DynamiteDemoResources.ContentTypeMyContentItemTitle
        };

        #endregion
    }
}
