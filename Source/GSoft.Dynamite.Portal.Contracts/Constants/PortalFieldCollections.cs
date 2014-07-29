using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Utils;

namespace GSoft.Dynamite.Portal.Contracts.Constants
{
    /// <summary>
    /// Field collections for content type definitions.
    /// </summary>
    public static class PortalFieldCollections
    {
        #region Content Type Fields
        /// <summary>
        /// The browsed Item Content Type fields 
        /// </summary>
        public static readonly ICollection<FieldInfo> BrowsableItemFields = new List<FieldInfo>()
        {
            BuiltInFields.TaxCatchAll,
            BuiltInFields.TaxCatchAllLabel,
            PortalFields.Navigation,
            PortalFields.Slug,
            PortalFields.DateSlug
        };

        /// <summary>
        /// The Translatable Item Content Type fields 
        /// </summary>
        public static readonly ICollection<FieldInfo> TranslatableItemFields = new List<FieldInfo>()
        {
            PortalFields.ContentAssociationKey,
            PortalFields.ItemLanguage
        };

        /// <summary>
        /// The Schedulable Item Content Type fields 
        /// </summary>
        public static readonly ICollection<FieldInfo> SchedulableItemFields = new List<FieldInfo>()
        {
            PortalFields.SchedulingStartDate,
            PortalFields.SchedulingEndDate
        };

        /// <summary>
        /// The MenuManageable Item Content Type fields 
        /// </summary>
        public static readonly ICollection<FieldInfo> FeaturedItemFields = new List<FieldInfo>()
        {
            PortalFields.IsNavigationMenuItem,
            PortalFields.IsTopNews,
            PortalFields.TopNewsOrder
        };

        /// <summary>
        /// The Content Item Content Type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> ContentItemFields = new List<FieldInfo>()
        {
            PortalFields.PublishingPageContent,
            PortalFields.PublishingPageImage,
            PortalFields.PublishingImageCaption,
            PortalFields.Subject,
            PortalFields.Summary
        };

        /// <summary>
        /// The news content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> NewsItemFields = new List<FieldInfo>()
        {
            PortalFields.ArticleStartDate
        };

        /// <summary>
        /// the node description content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> NodeDescriptionFields = new List<FieldInfo>()
        {
            PortalFields.PublishingPageContent
        };

        /// <summary>
        /// The translatable page content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> TranslatablePageFields = new List<FieldInfo>()
        {
            PortalFields.ContentAssociationKey
        };

        /// <summary>
        /// The content page content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> ContentPageFields = new List<FieldInfo>()
        {
        };

        /// <summary>
        /// The news page content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> NewsPageFields = new List<FieldInfo>()
        {
        };

        #endregion

        #region Ordered Fields

        /// <summary>
        /// The ordered news item content type fields
        /// </summary>
        public static readonly ICollection<FieldInfo> OrderedNewsItemFields = new List<FieldInfo>()
        {
            PortalFields.Title,
            PortalFields.Summary,
            PortalFields.ArticleStartDate,
            PortalFields.PublishingPageImage,
            PortalFields.PublishingPageContent,
            PortalFields.Navigation,
            PortalFields.Subject, 
            PortalFields.IsTopNews,
            PortalFields.TopNewsOrder,
            PortalFields.IsNavigationMenuItem,
            PortalFields.SchedulingStartDate,
            PortalFields.SchedulingEndDate,
            PortalFields.PublishingImageCaption
        };

        /// <summary>
        /// The ordered static content item fields
        /// </summary>
        public static readonly ICollection<FieldInfo> OrderedContentItemFields = new List<FieldInfo>()
        {
            PortalFields.Title,
            PortalFields.Summary,
            PortalFields.PublishingPageImage,
            PortalFields.PublishingPageContent,
            PortalFields.Navigation,
            PortalFields.Subject, 
            PortalFields.IsTopNews,
            PortalFields.TopNewsOrder,
            PortalFields.IsNavigationMenuItem,
            PortalFields.SchedulingStartDate,
            PortalFields.SchedulingEndDate,
            PortalFields.PublishingImageCaption
        };

        /// <summary>
        /// The ordered static content item fields
        /// </summary>
        public static readonly ICollection<FieldInfo> OrderedNodeDescriptionItemFields = new List<FieldInfo>()
        {
            PortalFields.Title,
            PortalFields.Navigation,
            PortalFields.PublishingPageContent,
            PortalFields.SchedulingStartDate,
            PortalFields.SchedulingEndDate
        };
        #endregion
    }
}
