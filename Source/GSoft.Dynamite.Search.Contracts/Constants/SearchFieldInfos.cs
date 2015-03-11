﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Search.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public class SearchFieldInfos
    {
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

        #region OOTB Fields
        /// <summary>
        /// The OOTB Browser Title Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public BaseFieldInfo BrowserTitle()
        {
            return new TextFieldInfo(
                 BrowserTitleName,
                 new Guid("{6A4AA5E6-B714-4BAA-B56E-E5F316A11AAF}"),
                 SearchResources.FieldBrowserTitleName,
                 SearchResources.FieldBrowserTitleDescription,
                 PublishingResources.FieldGroup
                 )
            {
                Required = RequiredType.NotRequired
            };
        }

        /// <summary>
        /// The OOTB Meta Description Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public BaseFieldInfo MetaDescription()
        {
            return new TextFieldInfo(
                 MetaDescriptionName,
                 new Guid("{F61DE7B0-8A48-4EEF-955E-71641887AE3C}"),
                 SearchResources.FieldMetaDescriptionName,
                 SearchResources.FieldMetaDescriptionDescription,
                 PublishingResources.FieldGroup
                 )
            {
                Required = RequiredType.NotRequired
            };
        }

        /// <summary>
        /// The OOTB Meta Keywords Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public BaseFieldInfo MetaKeywords()
        {
            return new TextFieldInfo(
                 MetaKeywordsName,
                 new Guid("{26AD764E-0328-434F-8C34-D56DA997FC88}"),
                 SearchResources.FieldMetaKeywordsName,
                 SearchResources.FieldMetaKeywordsDescription,
                 PublishingResources.FieldGroup
                 )
            {
                Required = RequiredType.NotRequired
            };
        }

        /// <summary>
        /// The OOTB Hide From Internet Search Engines Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public BaseFieldInfo HideFromInternetSearchEngines()
        {
            return new BooleanFieldInfo(
                 MetaKeywordsName,
                 new Guid("{F2D201C1-C8AF-421A-9646-ACD6B313BEAD}"),
                 SearchResources.FieldMetaKeywordsName,
                 SearchResources.FieldMetaKeywordsDescription,
                 PublishingResources.FieldGroup
                 )
            {
                Required = RequiredType.NotRequired
            };
        }
        #endregion

        #region Field internal Name

        /// <summary>
        /// Browser Title Internal name.
        /// </summary>
        private static readonly string BrowserTitleName = FieldPrefix + "BrowserTitle";

        /// <summary>
        /// Meta Description Internal name.
        /// </summary>
        private static readonly string MetaDescriptionName = FieldPrefix + "MetaDescription";

        /// <summary>
        /// Meta Keywords Internal name.
        /// </summary>
        private static readonly string MetaKeywordsName = FieldPrefix + "MetaKeywords";

        /// <summary>
        /// Meta Description Internal name.
        /// </summary>
        private static readonly string HideFromInternetSearchEnginesName = FieldPrefix + "RobotsNoIndex";

        #endregion
    }
}
