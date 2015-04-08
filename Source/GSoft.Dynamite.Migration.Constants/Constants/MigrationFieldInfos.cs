﻿using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Migration.Contracts.Constants
{
    /// <summary>
    /// Fields configuration for the migration module
    /// </summary>
    public class MigrationFieldInfos
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
                MigrationResources.FieldInternalIdName,
                MigrationResources.FieldInternalIdDescription,
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
