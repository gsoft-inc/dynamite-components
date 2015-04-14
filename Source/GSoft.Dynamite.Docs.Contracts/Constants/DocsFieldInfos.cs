using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Common.Contract.Constants;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Docs.Contracts.Constants
{
    /// <summary>
    /// Fields configuration for the document management module
    /// </summary>
    public static class DocsFieldInfos
    {
        private static readonly string InternalIdFieldName = CommonFieldInfo.FieldPrefix + "InternalId";

        /// <summary>
        /// The Item Language field information
        /// </summary>
        /// <returns>The ContentAssociationKey field</returns>
        public static NumberFieldInfo InternalId
        {
            get
            {
                return new NumberFieldInfo(
                    InternalIdFieldName,
                    new Guid("{6A03E503-E761-41C6-A3B4-BCB4FF841A6B}"),
                    DocsResources.FieldInternalIdName,
                    DocsResources.FieldInternalIdDescription,
                    PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = true,
                    IsHiddenInListSettings = true,
                    IsHiddenInNewForm = true
                };
            }
        }
    }
}
