using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Common.Contract.Configuration;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Publishing.Contracts.Stories;
using GSoft.Dynamite.Taxonomy;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Core.Stories
{
    /// <summary>
    /// PUB01 configuration for the cross-site publishing model.
    /// </summary>
    public class Pub01XSPConfig : IPub01Config
    {
        private readonly IGlobalConfig globalConfig;
        private readonly IFieldHelper fieldHelper;
        private readonly IContentTypeHelper contentTypeHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="Pub01XSPConfig" /> class.
        /// </summary>
        /// <param name="globalConfig">The global configuration.</param>
        /// <param name="fieldHelper">The field helper.</param>
        /// <param name="contentTypeHelper">The content type helper.</param>
        public Pub01XSPConfig(IGlobalConfig globalConfig, IFieldHelper fieldHelper, IContentTypeHelper contentTypeHelper)
        {
            this.globalConfig = globalConfig;
            this.fieldHelper = fieldHelper;
            this.contentTypeHelper = contentTypeHelper;
        }

        #region Fields

        /// <summary>
        /// Navigation field internal name
        /// </summary>
        private string NavigationFieldName
        {
            get
            {
                return this.globalConfig.FieldPrefix + "Navigation";
            }
        }

        /// <summary>
        /// Summary field internal name
        /// </summary>
        private string SummaryFieldName
        {
            get
            {
                return this.globalConfig.FieldPrefix + "Summary";
            }
        }

        /// <summary>
        /// Image Description field internal name
        /// </summary>
        private string ImageDescriptionFieldName
        {
            get
            {
                return this.globalConfig + "ImageDescription";
            }
        }

        /// <summary>
        /// Gets the title field information.
        /// </summary>
        /// <value>
        /// The title field information..
        /// </value>
        public TextFieldInfo TitleFieldInfo
        {
            get
            {
                return BuiltInFields.Title as TextFieldInfo;
            }
        }

        /// <summary>
        /// The navigation field information field information.
        /// </summary>
        /// <returns>The Navigation field information.</returns>
        public TaxonomyFieldInfo NavigationFieldInfo
        {
            get
            {
                return new TaxonomyFieldInfo(
                    this.NavigationFieldName,
                    new Guid("{256DF203-3855-497F-B514-4C99D5BE79C9}"),
                    PublishingResources.FieldPortalNavigationName,
                    PublishingResources.FieldPortalNavigationDescription,
                    PublishingResources.FieldGroup)
                                {
                                    TermStoreMapping = new TaxonomyContext()
                                    {
                                        TermSet = this.GlobalNavigationTermSetInfo
                                    },
                                    Required = RequiredType.Required
                                };
                            }
        }

        /// <summary>
        /// Gets the content field information.
        /// </summary>
        /// <value>
        /// The content field information.
        /// </value>
        public HtmlFieldInfo ContentFieldInfo
        {
            get
            {
                return PublishingFields.PublishingPageContent as HtmlFieldInfo;
            }
        }

        /// <summary>
        /// Gets the summary field information.
        /// </summary>
        /// <value>
        /// The summary field information.
        /// </value>
        public NoteFieldInfo SummaryFieldInfo
        {
            get
            {
                return new NoteFieldInfo(
                    this.SummaryFieldName,
                    new Guid("{BEA301A1-9285-4DC9-9ADF-77E5559B63ED}"),
                    PublishingResources.FieldPortalSummaryName,
                    PublishingResources.FieldPortalSummaryDescription,
                    PublishingResources.FieldGroup);
            }
        }

        /// <summary>
        /// Gets the image field information.
        /// </summary>
        /// <value>
        /// The image field information.
        /// </value>
        public ImageFieldInfo ImageFieldInfo
        {
            get
            {
                return PublishingFields.PublishingPageImage as ImageFieldInfo;
            }
        }

        /// <summary>
        /// Gets the image description.
        /// </summary>
        /// <value>
        /// The image description.
        /// </value>
        public NoteFieldInfo ImageDescriptionFieldInfo
        {
            get
            {
                return new NoteFieldInfo(
                    this.ImageDescriptionFieldName,
                    new Guid("{23E12444-CD39-4604-B1B2-8D7F99A0836C}"),
                    PublishingResources.FieldPortalImageDescriptionName,
                    PublishingResources.FieldPortalImageDescriptionDescription,
                    PublishingResources.FieldGroup);
            }
        } 

        #endregion

        #region Content Types

        public ContentTypeInfo BrowsableItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo TranslatableItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo DefaultItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo CatalogContentItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo TargetContentItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo NewsItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        }

        public ContentTypeInfo ContentItemContentTypeInfo
        {
            get { throw new NotImplementedException(); }
        } 

        #endregion

        #region Taxonomy

        /// <summary>
        /// Gets the navigatio term group information.
        /// </summary>
        /// <value>
        /// The navigatio term group information.
        /// </value>
        public TermGroupInfo NavigatioTermGroupInfo {
            get
            {
                return new TermGroupInfo(
                    new Guid("6c3fb5cb-ea19-4a77-9c39-dc1583523f97"),
                    "Portal - Navigation");
            }
        }

        /// <summary>
        /// Gets the restricted term group information.
        /// </summary>
        /// <value>
        /// The restricted term group information.
        /// </value>
        public TermGroupInfo RestrictedTermGroupInfo {
            get
            {
                return new TermGroupInfo(
                    new Guid("5a4b4147-be07-4f1e-9b90-262ae89cd5d3"),
                    "Portal - Restricted");
            }
        }

        /// <summary>
        /// Gets the global navigation term set information.
        /// </summary>
        /// <value>
        /// The global navigation term set information.
        /// </value>
        public TermSetInfo GlobalNavigationTermSetInfo {
            get
            {
                return new TermSetInfo(
                    new Guid("f92bc16f-f73b-4568-b6af-f8dd87044653"),
                    new Dictionary<CultureInfo, string>
                                {           
                                    { new CultureInfo(Language.French.Culture.LCID), "Navigation (FR)" },
                                    { new CultureInfo(Language.English.Culture.LCID), "Navigation (EN)" }
                                },
                    this.NavigatioTermGroupInfo);
            }
        }

        /// <summary>
        /// Gets the restricted news term set information.
        /// </summary>
        /// <value>
        /// The restricted news term set information.
        /// </value>
        public TermSetInfo RestrictedNewsTermSetInfo {
            get
            {
                return new TermSetInfo(
                    new Guid("700c0057-26b7-455c-a1de-7b5b7c4c0f71"),
                    new Dictionary<CultureInfo, string>
                                {           
                                    { new CultureInfo(Language.French.Culture.LCID), "Défault - Nouvelles" },
                                    { new CultureInfo(Language.English.Culture.LCID), "Default - News" },
                                },
                    this.RestrictedTermGroupInfo);
                        }
        }

        #endregion

        #region IPub01Config Implementation

        public ICollection<IFieldInfo> FieldInfos
        {
            get
            {
                return new IFieldInfo[]
                {
                    this.TitleFieldInfo,
                    this.NavigationFieldInfo,
                    this.ContentFieldInfo,
                    this.SummaryFieldInfo,
                    this.ImageFieldInfo,
                    this.ImageDescriptionFieldInfo
                };
            }
        }

        public ICollection<ContentTypeInfo> ContenTypeInfos
        {
            get
            {
                return new ContentTypeInfo[]
                {
                };
            }
        }

        #endregion

        /// <summary>
        /// Install sequence for PUB01.
        /// </summary>
        public void Install()
        {
            // Open authoring site and root web
            using (var authoringSite = new SPSite(this.globalConfig.AuthoringHostUrl))
            {
                using (var authoringRootWeb = authoringSite.OpenWeb())
                {
                    // 1. Ensure field creation
                    this.fieldHelper.EnsureField(authoringRootWeb.Fields, this.FieldInfos);
                }
            }
        }
    }
}
