using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Structures;

namespace GSoft.Dynamite.Portal.Contracts.Constants
{
    /// <summary>
    /// Portal Resources
    /// </summary>
    public static class PortalResources
    {
        /// <summary>
        /// The global namespace for the dynamite portal resource files 
        /// </summary>
        public static readonly string Global = "GSoft.Dynamite.Portal.Global";

        #region Fields

        /// <summary>
        /// The field Portal Navigation Name
        /// </summary>
        public static readonly string FieldPortalNavigationName = "Field_PortalNavigation_Name";

        /// <summary>
        /// The field Portal Navigation Description
        /// </summary>
        public static readonly string FieldPortalNavigationDescription = "Field_PortalNavigation_Description";

        /// <summary>
        /// The field Portal Slug Name
        /// </summary>
        public static readonly string FieldPortalSlugName = "Field_PortalSlug_Name";

        /// <summary>
        /// The field Portal Slug Description
        /// </summary>
        public static readonly string FieldPortalSlugDescrpition = "Field_PortalSlug_Description";

        /// <summary>
        /// The field Portal Date Slug Name
        /// </summary>
        public static readonly string FieldPortalDateSlugName = "Field_PortalDateSlug_Name";

        /// <summary>
        /// The field Portal Date Slug Description
        /// </summary>
        public static readonly string FieldPortalDateSlugDescription = "Field_PortalDateSlug_Description";

        /// <summary>
        /// The field Content association key Name
        /// </summary>
        public static readonly string FieldContentAssociationKeyName = "Field_ContentAssociationKey_Name";

        /// <summary>
        /// The fieldContent association key Description
        /// </summary>
        public static readonly string FieldContentAssociationKeyDescription = "Field_ContentAssociationKey_Description";

        /// <summary>
        /// The field Item Language Name
        /// </summary>
        public static readonly string FieldItemLamguageName = "Field_ItemLanguage_Name";

        /// <summary>
        /// The field Item Language Description
        /// </summary>
        public static readonly string FieldItemLamguageDescription = "Field_ItemLanguage_Description";

        /// <summary>
        /// The field Scheduling Start Date Name
        /// </summary>
        public static readonly string FieldSchedulingStartDateName = "Field_SchedulingStartDate_Name";

        /// <summary>
        /// The field Scheduling Start Date Description
        /// </summary>
        public static readonly string FieldSchedulingStartDateDescription = "Field_SchedulingStartDate_Description";

        /// <summary>
        /// The field Scheduling End Date Name
        /// </summary>
        public static readonly string FieldSchedulingEndDateName = "Field_SchedulingEndDate_Name";

        /// <summary>
        /// The field Scheduling End Date Description
        /// </summary>
        public static readonly string FieldSchedulingEndDateDescription = "Field_SchedulingEmdDate_Description";

        /// <summary>
        /// The field Is Navigation Menu Item Name
        /// </summary>
        public static readonly string FieldIsNavigationMenuItemName = "Field_IsNavigationMenuItem_Name";

        /// <summary>
        /// The field Is Navigation Menu Item Description
        /// </summary>
        public static readonly string FieldIsNavigationMenuItemDescription = "Field_IsNavigationMenuItem_Description";

        /// <summary>
        /// The field Portal Subject Name
        /// </summary>
        public static readonly string FieldPortalSubjectName = "Field_PortalSubject_Name";

        /// <summary>
        /// The field Portal Subject Description
        /// </summary>
        public static readonly string FieldPortalSubjectDescription = "Field_PortalSubject_Description";

        /// <summary>
        /// The field Portal Summary Name
        /// </summary>
        public static readonly string FieldPortalSummaryName = "Field_PortalSummary_Name";

        /// <summary>
        /// The field Portal Summary Description
        /// </summary>
        public static readonly string FieldPortalSummaryDescription = "Field_PortalSummary_Description";

        /// <summary>
        /// The field Portal Summary Name
        /// </summary>
        public static readonly string FieldIsTopNewsName = "Field_IsTopNews_Name";

        /// <summary>
        /// The field Portal Summary Description
        /// </summary>
        public static readonly string FieldIsTopNewsDescription = "Field_IsTopNews_Description";

        /// <summary>
        /// The field Portal Summary Name
        /// </summary>
        public static readonly string FieldTopNewsOrderName = "Field_TopNewsOrder_Name";

        /// <summary>
        /// The field Portal Summary Description
        /// </summary>
        public static readonly string FieldTopNewsOrderDescription = "Field_TopNewsOrder_Description";

        #endregion

        #region Content Types
        /// <summary>
        /// The content type group
        /// </summary>
        public static readonly string ContentTypeGroup = "ContentTypes_Group";

        /// <summary>
        /// The content type browsed Item Name
        /// </summary>
        public static readonly string ContentTypeBrowsableItemName = "ContentType_BrowsableItem_Name";

        /// <summary>
        /// The content type browsed Item Description
        /// </summary>
        public static readonly string ContentTypeBrowsableItemDescription = "ContentType_BrowsableItem_Description";

        /// <summary>
        /// The content type Schedulable Item Name
        /// </summary>
        public static readonly string ContentTypeSchedulableItemName = "ContentType_SchedulableItem_Name";

        /// <summary>
        /// The content type Schedulable Item Description
        /// </summary>
        public static readonly string ContentTypeSchedulableItemDescription = "ContentType_SchedulableItem_Description";

        /// <summary>
        /// Translatable item content type name
        /// </summary>
        public static readonly string ContentTypeTranslatableItemName = "ContentType_TranslatableItem_Name";

        /// <summary>
        /// Translatable item content type description
        /// </summary>
        public static readonly string ContentTypeTranslatableItemDescription = "ContentType_TranslatableItem_Description";

        /// <summary>
        /// Navigation Content item content type name
        /// </summary>
        public static readonly string ContentTypeFeaturedItemName = "ContentType_FeaturedItem_Name";

        /// <summary>
        /// Navigation Content item content type name
        /// </summary>
        public static readonly string ContentTypeFeaturedItemDescription = "ContentType_FeaturedItem_Description";

        /// <summary>
        /// The content type content item name
        /// </summary>
        public static readonly string ContentTypeContentItemName = "ContentType_ContentItem_Name";

        /// <summary>
        /// The content type content item description
        /// </summary>
        public static readonly string ContentTypeContentItemDescription = "ContentType_ContentItem_Description";

        /// <summary>
        /// The content type news item name
        /// </summary>
        public static readonly string ContentTypeNewsItemName = "ContentType_NewsItem_Name";

        /// <summary>
        /// The content type news item description
        /// </summary>
        public static readonly string ContentTypeNewsItemDescription = "ContentType_NewsItem_Description";

        /// <summary>
        /// The content type node description title
        /// </summary>
        public static readonly string ContentTypeNodeDescriptionItemName = "ContentType_NodeDescriptionItem_Name";

        /// <summary>
        /// The content type node description description
        /// </summary>
        public static readonly string ContentTypeNodeDescriptionItemDescription = "ContentType_NodeDescriptionItem_Description";

        #region Pages
        /// <summary>
        /// The content type translatable page name
        /// </summary>
        public static readonly string ContentTypeTranslatablePageName = "ContentType_TranslatablePage_Name";

        /// <summary>
        /// The content type translatable page description
        /// </summary>
        public static readonly string ContentTypeTranslatablePageDescripion = "ContentType_TranslatablePage_Description";

        /// <summary>
        /// The content type news page name
        /// </summary>
        public static readonly string ContentTypeContentPageName = "ContentType_ContentPage_Name";

        /// <summary>
        /// The content type news page description
        /// </summary>
        public static readonly string ContentTypeContentPageDescription = "ContentType_ContentPage_Description";

        /// <summary>
        /// The content type news page name
        /// </summary>
        public static readonly string ContentTypeNewsPageName = "ContentType_NewsPage_Name";

        /// <summary>
        /// The content type news page description
        /// </summary>
        public static readonly string ContentTypeNewsPageDescription = "ContentType_NewsPage_Descrpition";
        #endregion

        #endregion

        #region Page Layouts

        /// <summary>
        /// Then page layout catalog title
        /// </summary>
        public static readonly string PageLayoutCatalogItemTitle = "PageLayout_CatalogItem_Title";

        /// <summary>
        /// Then page layout catalog description
        /// </summary>
        public static readonly string PageLayoutCatalogItemDescription = "PageLayout_CatalogItem_Description";

        #endregion
    }
}
