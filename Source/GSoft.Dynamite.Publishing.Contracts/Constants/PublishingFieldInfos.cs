using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public class PublishingFieldInfos
    {
        private readonly PublishingTermSetInfos termSetInfoValues;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="termSetInfoValues">The term set info objects configuration</param>
        public PublishingFieldInfos(PublishingTermSetInfos termSetInfoValues)
        {
            this.termSetInfoValues = termSetInfoValues;
        }

        #region Field prefix

        /// <summary>
        /// The Dynamite field prefix for all fields
        /// </summary>
        public static string FieldPrefix
        {
            get
            {
                return "Dynamite";
            }
        }

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
                PublishingResources.FieldPortalNavigationName,
                PublishingResources.FieldPortalNavigationDescription,
                PublishingResources.FieldGroup)
            {
                TermStoreMapping = new TaxonomyContext()
                {
                    TermSet = this.termSetInfoValues.GlobalNavigation()
                },
                /*DefaultValue = new TaxonomyFullValue()
                {
                    TermGroup = _termGroupInfoValues.Navigation(),
                    TermSet = _termSetInfoValues.GlobalNavigation(),
                },*/
                Required = RequiredType.Required
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
                PublishingResources.FieldPortalSummaryName,
                PublishingResources.FieldPortalSummaryDescription,
                PublishingResources.FieldGroup);
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
                PublishingResources.FieldPortalImageDescriptionName,
                PublishingResources.FieldPortalImageDescriptionDescription,
                PublishingResources.FieldGroup);
        }

        #endregion

        #region Field internal names

        /// <summary>
        /// Navigation field internal name
        /// </summary>
        private static readonly string NavigationFieldName = FieldPrefix + "Navigation";

        /// <summary>
        /// Summary field internal name
        /// </summary>
        private static readonly string SummaryFieldName = FieldPrefix + "Summary";

        /// <summary>
        /// Image Description field internal name
        /// </summary>
        private static readonly string ImageDescriptionFieldName = FieldPrefix + "ImageDescription";

        #endregion
    }
}
