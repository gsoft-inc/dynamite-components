﻿using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BasePublishingPageLayoutInfos
    {
        #region Target Item Page Layout

        public PageLayoutInfo TargetItemPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "TargetItemPageLayout.aspx",
            };
        }
        #endregion

        #region Catalog Item Page Layout

        public PageLayoutInfo CatalogItemPageLayout()
        {
            return new PageLayoutInfo()
            {
                Name = "CatalogItemPageLayout.aspx"
            };
        }
        #endregion
    }
}