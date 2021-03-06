﻿using System;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Fields settings for the multilingualism module
    /// </summary>
    public static class MultilingualismFieldInfos
    {
        private static readonly string ContentAssociationKeyFieldName = CommonFieldInfo.FieldPrefix + "ContentAssociationKey";
        private static readonly string ItemLanguageFieldName = CommonFieldInfo.FieldPrefix + "ItemLanguage";

        /// <summary>
        /// The ContentAssociationKey field information
        /// </summary>
        /// <returns>The ContentAssociationKey field</returns>
        public static GuidFieldInfo ContentAssociationKey
        {
            get
            {
                return new GuidFieldInfo(
                    ContentAssociationKeyFieldName,
                    new Guid("{71154E23-E1A9-48B7-8DC7-556F6F76E4EB}"),
                    MultilingualismResources.FieldContentAssociationKeyName,
                    MultilingualismResources.FieldContentAssociationKeyDescription,
                    PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = true,
                    IsHiddenInListSettings = false,
                    IsHiddenInNewForm = true
                };
            }
        }

        /// <summary>
        /// The Item Language field information
        /// </summary>
        /// <returns>The ContentAssociationKey field</returns>
        public static TextFieldInfo ItemLanguage
        {
            get
            {
                return new TextFieldInfo(
                    ItemLanguageFieldName,
                    new Guid("{75DC379D-2A78-4EC0-A95B-CFE04AF6631E}"),
                    MultilingualismResources.FieldItemLanguageName,
                    MultilingualismResources.FieldItemLanguageDescription,
                    PublishingResources.FieldGroup)
                {
                    Required = RequiredType.NotRequired,
                    IsHiddenInDisplayForm = false,
                    IsHiddenInEditForm = true,
                    IsHiddenInListSettings = false,
                    IsHiddenInNewForm = true
                };
            }
        }
    }
}
