using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Fields.Types;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public static class PublishingFieldInfos
    {
        #region Field internal names

        /// <summary>
        /// Navigation field internal name
        /// </summary>
        private static readonly string NavigationFieldName = CommonFieldInfo.FieldPrefix + "Navigation";

        /// <summary>
        /// Summary field internal name
        /// </summary>
        private static readonly string SummaryFieldName = CommonFieldInfo.FieldPrefix + "Summary";

        /// <summary>
        /// Image Description field internal name
        /// </summary>
        private static readonly string ImageDescriptionFieldName = CommonFieldInfo.FieldPrefix + "ImageDescription";

        /// <summary>
        /// The publishing start date field name
        /// </summary>
        private static readonly string PublishingStartDateFieldName = CommonFieldInfo.FieldPrefix + "PublishingStartDate";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The navigation field information
        /// </summary>
        /// <returns>The Navigation field</returns>
        public static TaxonomyFieldInfo Navigation
        {
            get
            {
                return new TaxonomyFieldInfo(
                    NavigationFieldName,
                    new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"),
                    PublishingResources.FieldPortalNavigationName,
                    PublishingResources.FieldPortalNavigationDescription,
                    PublishingResources.FieldGroup)
                    {
                        Required = RequiredType.Required
                    };
            }
        }

        /// <summary>
        /// The summary field information
        /// </summary>
        /// <returns>The Summary field</returns>
        public static NoteFieldInfo Summary
        {
            get
            {
                return new NoteFieldInfo(
                    SummaryFieldName,
                    new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"),
                    PublishingResources.FieldPortalSummaryName,
                    PublishingResources.FieldPortalSummaryDescription,
                    PublishingResources.FieldGroup);
            }
        }

        /// <summary>
        /// The image description field
        /// </summary>
        /// <returns>The ImageDescription field</returns>
        public static NoteFieldInfo ImageDescription
        {
            get
            {
                return new NoteFieldInfo(
                    ImageDescriptionFieldName,
                    new Guid("{23E12444-CD39-4604-B1B2-8D7F99A0836C}"),
                    PublishingResources.FieldPortalImageDescriptionName,
                    PublishingResources.FieldPortalImageDescriptionDescription,
                    PublishingResources.FieldGroup);
            }
        }

        /// <summary>
        /// The title slug field
        /// </summary>
        /// <returns>The TitleSlug field</returns>
        public static DateTimeFieldInfo PublishingStartDate
        {
            get
            {
                return new DateTimeFieldInfo(
                    PublishingStartDateFieldName,
                    new Guid("{AAB9602B-934B-4974-BB6B-A94992C7EDA5}"),
                    PublishingResources.FieldPublishingStartDateName,
                    PublishingResources.FieldPublishingStartDateDescription,
                    PublishingResources.FieldGroup)
                    {
                        Required = RequiredType.Required,
                        IsHiddenInDisplayForm = false,
                        IsHiddenInEditForm = false,
                        IsHiddenInListSettings = false,
                        IsHiddenInNewForm = false,
                        DefaultFormula = "=[Today]"
                    };
            }
        }

        /// <summary>
        /// The publishing page content field information.
        /// </summary>
        /// <returns>The field information.</returns>
        public static BaseFieldInfo PublishingPageContent
        {
            get
            {
                return new MinimalFieldInfo<string>(
                    PublishingFields.PublishingPageContent.InternalName,
                    PublishingFields.PublishingPageContent.Id);
            }
        }

        #endregion
    }
}
