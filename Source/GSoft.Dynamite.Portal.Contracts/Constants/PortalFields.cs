using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Utils;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Constants
{
    /// <summary>
    /// Fields for the Portal Solution
    /// </summary>
    public static class PortalFields
    {
        #region Field prefix
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string FieldPrefix = "Portal";
        #endregion

        #region Field internal names
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string NavigationFieldName = FieldPrefix + "Navigation";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SlugFieldName = FieldPrefix + "Slug";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string DateSlugFieldName = FieldPrefix + "DateSlug";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string ContentAssociationKeyFieldName = "ContentAssociationKey";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string ItemLanguageFieldName = "ItemLanguage";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SchedulingStartDateName = "SchedulingStartDate";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SchedulingEndDateName = "SchedulingEndDate";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string IsNavigationMenuItemFieldName = "IsNavigationMenuItem";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SubjectFieldName = FieldPrefix + "Subject";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SummaryFieldName = FieldPrefix + "Summary";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string IsTopNewsFieldName = "IsTopNews";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string TopNewsOrderFieldName = "TopNewsOrder";

        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PageAssociationKeyFieldName = FieldPrefix + "PageAssociationKey";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PageLanguageFieldName = FieldPrefix + "PageLanguage";
        #endregion

        #region Built-in field internal name
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string TitleFieldName = "Title";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PublishingPageContentFieldName = "PublishingPageContent";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PublishingPageImageFieldName = "PublishingPageImage";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PublishingImageCaptionFieldName = "PublishingImageCaption";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PublishingStartDateFieldName = "PublishingStartDate";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string PublishingEndDateFieldName = "PublishingEndDate";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string ArticleStartDateFieldName = "ArticleStartDate";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SummaryLinksName = "SummaryLinks";
        [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1202:ElementsMustBeOrderedByAccess", Justification = "Reviewed.")]
        private static readonly string SummaryLinks2Name = "SummaryLinks2";
        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The navigation field information
        /// </summary>
        public static readonly FieldInfo Navigation = new FieldInfo(NavigationFieldName, new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"));

        /// <summary>
        /// The slug field information
        /// </summary>
        public static readonly FieldInfo Slug = new FieldInfo(SlugFieldName, new Guid("{56B7A62A-0FA0-49C2-8B1E-ECD2232FE67D}"));

        /// <summary>
        /// The date slug
        /// </summary>
        public static readonly FieldInfo DateSlug = new FieldInfo(DateSlugFieldName, new Guid("{514741C8-108B-4C44-84B8-719354B9EA66}"));

        /// <summary>
        /// The content association key field information
        /// </summary>
        public static readonly FieldInfo ContentAssociationKey = new FieldInfo(ContentAssociationKeyFieldName, new Guid("{71154E23-E1A9-48B7-8DC7-556F6F76E4EB}"));

        /// <summary>
        /// The item language field information
        /// </summary>
        public static readonly FieldInfo ItemLanguage = new FieldInfo(ItemLanguageFieldName, new Guid("{720BA9A0-7633-41AE-909E-C8F8CD29E5CA}"));

        /// <summary>
        /// The scheduling start date
        /// </summary>
        public static readonly FieldInfo SchedulingStartDate = new FieldInfo(SchedulingStartDateName, new Guid("{90B42FB6-A738-48DC-AD7B-10D27B410A23}"));

        /// <summary>
        /// The scheduling end date
        /// </summary>
        public static readonly FieldInfo SchedulingEndDate = new FieldInfo(SchedulingEndDateName, new Guid("{F0C31EB2-EFA2-4EE6-9F78-287C60B817CB}"));

        /// <summary>
        /// The navigation item field information
        /// </summary>
        public static readonly FieldInfo IsNavigationMenuItem = new FieldInfo(IsNavigationMenuItemFieldName, new Guid("{BCFF01F8-2FAC-4A0F-A47A-CA714CC88C39}"));

        /// <summary>
        /// The subject field information
        /// </summary>
        public static readonly FieldInfo Subject = new FieldInfo(SubjectFieldName, new Guid("{7155D29A-8015-47F6-84D8-71125D825F38}"));

        /// <summary>
        /// The summary field information
        /// </summary>
        public static readonly FieldInfo Summary = new FieldInfo(SummaryFieldName, new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"));

        /// <summary>
        /// The IsTopNews field information
        /// </summary>
        public static readonly FieldInfo IsTopNews = new FieldInfo(IsTopNewsFieldName, new Guid("{F5A9FD89-0AB5-4394-8152-0F61A39FC56C}"));
        
        /// <summary>
        /// The TopNewsOrder field information
        /// </summary>
        public static readonly FieldInfo TopNewsOrder = new FieldInfo(TopNewsOrderFieldName, new Guid("{D1E5868D-9BFC-4088-BDA8-F6F698E156FB}"));

        /// <summary>
        /// The page association key
        /// </summary>
        public static readonly FieldInfo PageAssociationKey = new FieldInfo(PageAssociationKeyFieldName, Guid.Empty);

        /// <summary>
        /// The Summary Links
        /// </summary>
        public static readonly FieldInfo SummaryLinks = new FieldInfo(SummaryLinksName, new Guid("{B3525EFE-59B5-4f0f-B1E4-6E26CB6EF6AA}"));

        /// <summary>
        /// The Summary Links 2
        /// </summary>
        public static readonly FieldInfo SummaryLinks2 = new FieldInfo(SummaryLinks2Name, new Guid("{27761311-936A-40ba-80CD-CA5E7A540A36}"));

        #endregion

        #region Built-in FieldInfo reference objects

        /// <summary>
        /// The title field information
        /// </summary>
        public static readonly FieldInfo Title = new FieldInfo(TitleFieldName, SPBuiltInFieldId.Title);

        /// <summary>
        /// The publishing page content field information
        /// </summary>
        public static readonly FieldInfo PublishingPageContent = new FieldInfo(PublishingPageContentFieldName, new Guid("{F55C4D88-1F2E-4ad9-AAA8-819AF4EE7EE8}"));

        /// <summary>
        /// The publishing page image field information
        /// </summary>
        public static readonly FieldInfo PublishingPageImage = new FieldInfo(PublishingPageImageFieldName, new Guid("{3DE94B06-4120-41A5-B907-88773E493458}"));

        /// <summary>
        /// The publishing start date field information
        /// </summary>
        public static readonly FieldInfo PublishingStartDate = new FieldInfo(PublishingStartDateFieldName, new Guid("{51D39414-03DC-4BD0-B777-D3E20CB350F7}"));

        /// <summary>
        /// The publishing end date field information
        /// </summary>
        public static readonly FieldInfo PublishingEndDate = new FieldInfo(PublishingEndDateFieldName, new Guid("{A990E64F-FAA3-49C1-AAFA-885FDA79DE62}"));

        /// <summary>
        /// The publishing end date field information
        /// </summary>
        public static readonly FieldInfo PublishingImageCaption = new FieldInfo(PublishingImageCaptionFieldName, new Guid("{66F500E9-7955-49ab-ABB1-663621727D10}"));

        /// <summary>
        /// The publishing end date field information
        /// </summary>
        public static readonly FieldInfo ArticleStartDate = new FieldInfo(ArticleStartDateFieldName, new Guid("{71316CEA-40A0-49f3-8659-F0CEFDBDBD4F}"), RequiredTypes.Required);

        /// <summary>
        /// The publishing end date field information
        /// </summary>
        public static readonly FieldInfo PageLanguage = new FieldInfo(PageLanguageFieldName, Guid.Empty);
        #endregion
    }
}
