using System;
using System.Collections.Generic;
using GSoft.Dynamite.Catalogs;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Events;
using GSoft.Dynamite.Fields;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Targeting.Contracts.Configuration
{
    /// <summary>
    /// Targeting configuration for content (fields, content types, etc.)
    /// </summary>
    public interface ITargetingContentConfig
    {
        #region Artifact collections

        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<BaseFieldInfo> Fields { get; }

        /// <summary>
        /// Property that return all the content types to create or configure in the document management module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }

        /// <summary>
        /// Property that return all the event receivers to create or configure in the navigation module
        /// </summary>
        IList<EventReceiverInfo> EventReceivers { get; }

        /// <summary>
        /// Property that return all the catalogs to use in the targeting module
        /// </summary>
        IList<CatalogInfo> Catalogs { get; } 

        #endregion

        #region Access methods

        /// <summary>
        /// Gets the field by identifier.
        /// </summary>
        /// <param name="fieldId">The field identifier.</param>
        /// <returns>The base field information.</returns>
        BaseFieldInfo GetFieldById(Guid fieldId);

        /// <summary>
        /// Gets the content type from the ContentTypes property where the id of that content type is passed by parameter.
        /// </summary>
        /// <param name="contentTypeId">The unique identifier of the content type we are looking for.</param>
        /// <returns>
        /// The content type information.
        /// </returns>
        ContentTypeInfo GetContentTypeById(SPContentTypeId contentTypeId);

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        CatalogInfo GetCatalogInfoByWebRelativeUrl(string webRelativeUrl);

        /// <summary>
        /// Gets the catalog information by web relative URL from this configuration.
        /// </summary>
        /// <param name="webRelativeUrl">The web relative URL.</param>
        /// <returns>The catalog information</returns>
        CatalogInfo GetCatalogInfoByWebRelativeUrl(Uri webRelativeUrl); 

        #endregion
    }
}
