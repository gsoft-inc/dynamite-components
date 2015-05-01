using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Fields configuration for the navigation module
    /// </summary>
    public static class NavigationFieldInfos
    {
        private static readonly string DateSlugFieldName = CommonFieldInfo.FieldPrefix + "DateSlug";
        private static readonly string TitleSlugFieldName = CommonFieldInfo.FieldPrefix + "TitleSlug";
        private static readonly string OccurrenceLinkLocationFieldName = CommonFieldInfo.FieldPrefix + "OccurrenceLinkLocation";

        /// <summary>
        /// The date slug field
        /// </summary>
        /// <returns>The DateSlug field</returns>
        public static TextFieldInfo DateSlug
        {
            get
            {
                return new TextFieldInfo(
                    DateSlugFieldName,
                    new Guid("{0D112FAD-6445-4002-8C8B-CF405F7C4935}"),
                    NavigationResources.FieldDateSlugName,
                    NavigationResources.FieldDateSlugDescription,
                    PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = true,
                    IsHiddenInListSettings = false,
                    IsHiddenInNewForm = true
                };
            }
        }

        /// <summary>
        /// The title slug field
        /// </summary>
        /// <returns>The TitleSlug field</returns>
        public static TextFieldInfo TitleSlug
        {
            get
            {
                return new TextFieldInfo(
                    TitleSlugFieldName,
                    new Guid("{8D3823D9-8F02-4640-8439-BF09D0A7333F}"),
                    NavigationResources.FieldTitleSlugName,
                    NavigationResources.FieldTitleSlugDescription,
                    PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = true,
                    IsHiddenInListSettings = false,
                    IsHiddenInNewForm = true
                };
            }
        }

        /// <summary>
        /// The Occurrence Link Location field.
        /// </summary>
        /// <returns>The OccurrenceLinkLocation field</returns>
        public static TaxonomyMultiFieldInfo OccurrenceLinkLocation
        {
            get
            {
                return new TaxonomyMultiFieldInfo(
                   OccurrenceLinkLocationFieldName,
                   new Guid("{C2E6B519-A2FF-429C-BAE5-1034E7A29545}"),
                   NavigationResources.FieldOccurrenceLinkLocationName,
                   NavigationResources.FieldOccurrenceLinkLocationDescription,
                   PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = false,
                    IsHiddenInListSettings = false,
                    IsHiddenInNewForm = false
                };
            }
        }
    }
}
