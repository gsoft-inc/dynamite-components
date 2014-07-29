namespace GSoft.Dynamite.Portal.Contracts.Constants
{
    /// <summary>
    /// Constants for the Managed properties
    /// </summary>
    public static class PortalManagedProperties
    {
        /// <summary>
        /// The item url template when rewriting them
        /// </summary>
        public static readonly string ItemUrlRewriteTemplate = string.Format("/[{0}]/[{1}]/[{2}]", PortalDateSlug, ListItemID, PortalSlug);

        /// <summary>
        /// The content association key managed property name
        /// </summary>
        public static readonly string ContentAssociationKey = "ContentAssociationKeyOWSGUID";

        /// <summary>
        /// The navigation managed property name
        /// </summary>
        public static readonly string PortalNavigation = "owstaxIdPortalNavigation";

        /// <summary>
        /// The item language
        /// </summary>
        public static readonly string ItemLanguage = "ItemLanguageOWSTEXT";

        /// <summary>
        /// The title
        /// </summary>
        public static readonly string Title = "Title";

        /// <summary>
        /// The PublishingImage
        /// </summary>
        public static readonly string PublishingImage = "PublishingImage";

        /// <summary>
        /// The Date slug for the url
        /// </summary>
        public static readonly string PortalDateSlug = "PortalDateSlugOWSTEXT";

        /// <summary>
        /// The list item id
        /// </summary>
        public static readonly string ListItemID = "ListItemID";

        /// <summary>
        /// The Text Slug for the URL
        /// </summary>
        public static readonly string PortalSlug = "PortalSlugOWSTEXT";

        /// <summary>
        /// The portal subject
        /// </summary>
        public static readonly string PortalSubject = "PortalSubjectOWSTEXT";
                
        /// <summary>
        /// The portal summary field
        /// </summary>
        public static readonly string PortalSummary = "PortalSummaryOWSMTXT";

        /// <summary>
        /// Publishing start date
        /// </summary>
        public static readonly string SchedulingStartDate = "SchedulingStartDateOWSDATE";

        /// <summary>
        /// Publishing end date
        /// </summary>
        public static readonly string SchedulingEndDate = "SchedulingEndDateOWSDATE";

        /// <summary>
        /// The friendly URL required properties
        /// </summary>
        public static readonly string[] FriendlyUrlRequiredProperties = new[] { PortalNavigation, "Path", "spSiteUrl", "ListID" };
    }
}
