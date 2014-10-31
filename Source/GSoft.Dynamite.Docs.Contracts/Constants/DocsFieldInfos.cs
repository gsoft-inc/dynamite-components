using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Docs.Contracts.Constants
{
    public class DocsFieldInfos
    {
        private static readonly string InternalIdFieldName = PublishingFieldInfos.FieldPrefix + "InternalId";

        /// <summary>
        /// The Item Language field information
        /// </summary>
        /// <returns>The ContentAssociationKey field</returns>
        public NumberFieldInfo InternalId()
        {
            return new NumberFieldInfo(
                InternalIdFieldName,
                new Guid("{6A03E503-E761-41C6-A3B4-BCB4FF841A6B}"),
                DocsResources.FieldInternalIdName,
                DocsResources.FieldInternalIdDescription,
                PublishingResources.FieldGroup
                )
            {
                Required = RequiredTypes.NotRequired,
                IsHiddenInDisplayForm = false,
                IsHiddenInEditForm = true,
                IsHiddenInListSettings = true,
                IsHiddenInNewForm = true
            };
        }
    }
}
