using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Definitions.Values;
using GSoft.Dynamite.Globalization;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public class BasePublishingFieldInfos
    {
        private readonly IResourceLocator _resourceLocator;
        private readonly string _resourceFileName = BasePublishingResources.Global;
        private readonly BasePublishingTermGroupInfos _termGroupInfoValues;
        private readonly BasePublishingTermSetInfos _termSetInfoValues;

        public BasePublishingFieldInfos(IResourceLocator resourceLocator, BasePublishingTermGroupInfos termGroupInfoValues, BasePublishingTermSetInfos termSetInfoValues)
        {
            _termGroupInfoValues = termGroupInfoValues;
            _termSetInfoValues = termSetInfoValues;
            _resourceLocator = resourceLocator;

        }

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
        /// <returns>The Navigation field</returns>
        public TaxonomyFieldInfo Navigation()
        {
            return new TaxonomyFieldInfo()
            {
                DisplayName = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalNavigationName),
                Description = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalNavigationDescription),
                Group = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldGroup),
                InternalName = NavigationFieldName,
                Id =new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"),
                // Default managed metadata mapping configuration
                DefaultValue = new TaxonomyFieldInfoValue()
                {
                    TermGroup = _termGroupInfoValues.Navigation(),
                    TermSet = _termSetInfoValues.GlobalNavigation()
                },
                RequiredType = RequiredTypes.Required
            };
        }

        /// <summary>
        /// The summary field information
        /// </summary>
        /// <returns>The Summary field</returns>
        public TextFieldInfo Summary()
        {
            return new TextFieldInfo()
            {

                DisplayName = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalSummaryName),
                Description = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalSummaryDescription),
                Group = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldGroup),
                InternalName = SummaryFieldName,
                Id = new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"),
                IsMultiLine = true,
            };
        }

        /// <summary>
        /// The image description field
        /// </summary>
        /// <returns>The ImageDescription field</returns>
        public TextFieldInfo ImageDescription()
        {
            return new TextFieldInfo()
            {
                DisplayName = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalImageDescriptionName),
                Description = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldPortalImageDescriptionDescription),
                Group = _resourceLocator.GetResourceString(_resourceFileName, BasePublishingResources.FieldGroup),
                InternalName = ImageDescriptionFieldName,
                Id = new Guid("{23E12444-CD39-4604-B1B2-8D7F99A0836C}"),
                IsMultiLine = true
            };
        }

        #endregion

        #region Built-in FieldInfo reference objects

        /// <summary>
        /// The title field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo Title(){ return new FieldInfo(TitleFieldName, SPBuiltInFieldId.Title); }

        /// <summary>
        /// The publishing page content field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo PublishingPageContent(){ return new FieldInfo(PublishingPageContentFieldName, new Guid("{F55C4D88-1F2E-4ad9-AAA8-819AF4EE7EE8}"));}

        /// <summary>
        /// The publishing page image field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo PublishingPageImage(){ return new FieldInfo(PublishingPageImageFieldName, new Guid("{3DE94B06-4120-41A5-B907-88773E493458}"));}

        /// <summary>
        /// The publishing start date field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo PublishingStartDate(){ return new FieldInfo(PublishingStartDateFieldName, new Guid("{51D39414-03DC-4BD0-B777-D3E20CB350F7}"));}

        /// <summary>
        /// The publishing end date field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo PublishingEndDate(){ return new FieldInfo(PublishingEndDateFieldName, new Guid("{A990E64F-FAA3-49C1-AAFA-885FDA79DE62}"));}

        /// <summary>
        /// The URL field information
        /// </summary>
        /// <returns>The field definition</returns>
        public FieldInfo Url(){ return new FieldInfo(UrlFieldName, SPBuiltInFieldId.URL);}

        #endregion
    }
}
