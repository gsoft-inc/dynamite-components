using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Globalization;
using Microsoft.SharePoint;
using GSoft.Dynamite.FieldTypes;
using GSoft.Dynamite.ValueTypes;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public class BasePublishingFieldInfos
    {
        private readonly IResourceLocator resourceLocator;
        private readonly string resourceFileName = BasePublishingResources.Global;
        private readonly BasePublishingTermGroupInfos termGroupInfoValues;
        private readonly BasePublishingTermSetInfos termSetInfoValues;

        public BasePublishingFieldInfos(IResourceLocator resourceLocator, BasePublishingTermGroupInfos termGroupInfoValues, BasePublishingTermSetInfos termSetInfoValues)
        {
            this.termGroupInfoValues = termGroupInfoValues;
            this.termSetInfoValues = termSetInfoValues;
            this.resourceLocator = resourceLocator;

        }

        #region Field prefix

        public static readonly string FieldPrefix = "Dynamite";

        #endregion

        #region Field internal names

        private static readonly string NavigationFieldName = FieldPrefix + "Navigation";

        private static readonly string SummaryFieldName = FieldPrefix + "Summary";

        private static readonly string ImageDescriptionFieldName = FieldPrefix + "ImageDescription";

        #endregion

        #region FieldInfo reference objects

        /// <summary>
        /// The navigation field information
        /// </summary>
        /// <returns>The Navigation field</returns>
        public TaxonomyFieldInfo Navigation()
        {
            return new TaxonomyFieldInfo(
                NavigationFieldName, 
                new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"),
                BasePublishingResources.FieldPortalNavigationName,
                BasePublishingResources.FieldPortalNavigationDescription,
                BasePublishingResources.FieldGroup
                )
            {
                TermStoreMapping = new TaxonomyContext()
                {
                    Group = termGroupInfoValues.Navigation(),
                    TermSet = termSetInfoValues.GlobalNavigation()
                },
                /*DefaultValue = new TaxonomyFullValue()
                {
                    TermGroup = _termGroupInfoValues.Navigation(),
                    TermSet = _termSetInfoValues.GlobalNavigation(),
                },*/
                Required = RequiredTypes.Required
            };
        }

        /// <summary>
        /// The summary field information
        /// </summary>
        /// <returns>The Summary field</returns>
        public NoteFieldInfo Summary()
        {
            return new NoteFieldInfo(
                SummaryFieldName,
                new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"),
                BasePublishingResources.FieldPortalSummaryName,
                BasePublishingResources.FieldPortalSummaryDescription,
                BasePublishingResources.FieldGroup);
        }

        /// <summary>
        /// The image description field
        /// </summary>
        /// <returns>The ImageDescription field</returns>
        public NoteFieldInfo ImageDescription()
        {
            return new NoteFieldInfo(
                ImageDescriptionFieldName,
                new Guid("{23E12444-CD39-4604-B1B2-8D7F99A0836C}"),
                BasePublishingResources.FieldPortalImageDescriptionName,
                BasePublishingResources.FieldPortalImageDescriptionDescription,
                BasePublishingResources.FieldGroup
                ); ;
        }

        #endregion
    }
}
