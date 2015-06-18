using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Targeting.Contracts.Configuration;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Core.Configuration
{
    /// <summary>
    /// Authoring module content targeting configuration.
    /// </summary>
    public class AuthTargetingContentConfig : ITargetingContentConfig
    {
        #region Artifact collections

        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        public IList<BaseFieldInfo> Fields
        {
            get { return new List<BaseFieldInfo>(); }
        }

        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        public IList<ContentTypeInfo> ContentTypes
        {
            get { return new List<ContentTypeInfo>(); }
        }

        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        public IList<EventReceiverInfo> EventReceivers
        {
            get { return new List<EventReceiverInfo>(); }
        }

        /// <summary>
        /// Property that return all the catalogs to use in the targeting module
        /// </summary>
        public IList<CatalogInfo> Catalogs
        {
            get { return new List<CatalogInfo>(); }
        } 

        #endregion

        #region Collection access methods

        /// <summary>
        /// Gets the field from the Fields property where the id of that field is passed by parameter.
        /// </summary>
        /// <param name="fieldId">The unique identifier of the field we are looking for.</param>
        /// <returns>
        /// The field information.
        /// </returns>
        public BaseFieldInfo GetFieldById(Guid fieldId)
        {
            return this.Fields.Single(f => f.Id.Equals(fieldId));
        }

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        public ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId)
        {
            return this.ContentTypes.Single(c => c.ContentTypeId.Equals(contentTypeId));
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(string webRelativeUrl)
        {
            return this.GetCatalogInfoByWebRelativeUrl(new Uri(webRelativeUrl, UriKind.Relative));
        }

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        public CatalogInfo GetCatalogInfoByWebRelativeUrl(Uri webRelativeUrl)
        {
            return this.Catalogs.Single(c => c.WebRelativeUrl.Equals(webRelativeUrl));
        }

        #endregion
    }
}
