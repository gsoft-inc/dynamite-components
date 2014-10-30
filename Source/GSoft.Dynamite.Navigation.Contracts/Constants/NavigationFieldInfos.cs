using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    public class NavigationFieldInfos
    {
        private readonly NavigationTermGroupInfos navigationTermGroupInfos;
        private readonly NavigationTermSetInfos navigationTermSetInfos;

        private static readonly string DateSlugFieldName = PublishingFieldInfos.FieldPrefix + "DateSlug";
        private static readonly string TitleSlugFieldName = PublishingFieldInfos.FieldPrefix + "TitleSlug";
        private static readonly string PublishingStartDateFieldName = PublishingFieldInfos.FieldPrefix + "PublishingStartDate";
        private static readonly string OccurrenceLinkLocationFieldName = PublishingFieldInfos.FieldPrefix + "OccurrenceLinkLocation";

        public NavigationFieldInfos(NavigationTermGroupInfos navigationTermGroupInfos, NavigationTermSetInfos navigationTermSetInfos)
        {
            this.navigationTermGroupInfos = navigationTermGroupInfos;
            this.navigationTermSetInfos = navigationTermSetInfos;
        }

        /// <summary>
        /// The date slug field
        /// </summary>
        /// <returns>The DateSlug field</returns>
        public TextFieldInfo DateSlug()
        {
            return new TextFieldInfo(
                DateSlugFieldName,
                new Guid("{0D112FAD-6445-4002-8C8B-CF405F7C4935}"),
                NavigationResources.FieldDateSlugName,
                NavigationResources.FieldDateSlugDescription,
                PublishingResources.FieldGroup
                )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = false,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = false,
                IsHiddenInNewForm = true
            };
        }

        /// <summary>
        /// The title slug field
        /// </summary>
        /// <returns>The TitleSlug field</returns>
        public TextFieldInfo TitleSlug()
        {
            return new TextFieldInfo(
                TitleSlugFieldName,
                new Guid("{8D3823D9-8F02-4640-8439-BF09D0A7333F}"),
                NavigationResources.FieldTitleSlugName,
                NavigationResources.FieldTitleSlugDescription,
                PublishingResources.FieldGroup
                )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = false,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = false,
                IsHiddenInNewForm = true
            };
        }

        /// <summary>
        /// The Occurrence Link Location field.
        /// </summary>
        /// <returns>The OccurrenceLinkLocation field</returns>
        public TaxonomyMultiFieldInfo OccurrenceLinkLocation()
        {
            return new TaxonomyMultiFieldInfo(
               OccurrenceLinkLocationFieldName,
               new Guid("{C2E6B519-A2FF-429C-BAE5-1034E7A29545}"),
               NavigationResources.FieldOccurrenceLinkLocationName,
               NavigationResources.FieldOccurrenceLinkLocationDescription,
               PublishingResources.FieldGroup
               )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = false,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = false,
                IsHiddenInNewForm = true,
                TermStoreMapping = new TaxonomyContext()
                {
                    TermSet = navigationTermSetInfos.NavigationControls()
                }
            };
        }

        /// <summary>
        /// The title slug field
        /// </summary>
        /// <returns>The TitleSlug field</returns>
        public DateTimeFieldInfo PublishingStartDate()
        {
            return new DateTimeFieldInfo(
                PublishingStartDateFieldName,
                new Guid("{AAB9602B-934B-4974-BB6B-A94992C7EDA5}"),
                NavigationResources.FieldPublishingStartDateName,
                NavigationResources.FieldPublishingStartDateDescription,
                PublishingResources.FieldGroup
                )
            {
                Required               = RequiredTypes.Required,
                IsHiddenInDisplayForm  = false,
                IsHiddenInEditForm = false,
                IsHiddenInListSettings = false,
                IsHiddenInNewForm = false,
                DefaultFormula = "=[Today]"
            };
        }
    }
}
