using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public static class BaseFieldInfoValues
    {
        #region Field prefix

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string FieldPrefix = "Portal";

        #endregion

        #region Field internal names

        private static readonly string NavigationFieldName = FieldPrefix + "Navigation";

        private static readonly string SummaryFieldName = FieldPrefix + "Summary";

        private static readonly string ImageDescriptionFieldName = FieldPrefix + "ImageDescription";

        #endregion

        #region Built-in field internal name

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string TitleFieldName = "Title";

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string PublishingPageContentFieldName = "PublishingPageContent";

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string PublishingPageImageFieldName = "PublishingPageImage";

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string PublishingStartDateFieldName = "PublishingStartDate";

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string PublishingEndDateFieldName = "PublishingEndDate";

        // ReSharper disable once ConvertToConstant.Local
        private static readonly string UrlFieldName = "URL";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The navigation field information
        /// </summary>
        public static readonly TaxonomyFieldInfo Navigation = new TaxonomyFieldInfo()
        {
            InternalName = NavigationFieldName,
            Id =new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}")  ,
        };

        /// <summary>
        /// The summary field information
        /// </summary>
        public static readonly TextFieldInfo Summary = new TextFieldInfo()
        {
            InternalName = SummaryFieldName,
            Id = new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"),
            IsMultiLine = true
        };

        /// <summary>
        /// The summary field information
        /// </summary>
        public static readonly TextFieldInfo ImageDescription = new TextFieldInfo()
        {
            InternalName = ImageDescriptionFieldName,
            Id = new Guid("{23E12444-CD39-4604-B1B2-8D7F99A0836C}"),
            IsMultiLine = true
        };

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
        /// The URL field information
        /// </summary>
        public static readonly FieldInfo Url = new FieldInfo(UrlFieldName, SPBuiltInFieldId.URL);

        #endregion
    }
}
