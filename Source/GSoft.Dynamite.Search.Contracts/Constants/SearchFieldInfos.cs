using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Fields.Types;

namespace GSoft.Dynamite.Search.Contracts.Constants
{
    /// <summary>
    /// Base FieldInfo values
    /// </summary>
    public class SearchFieldInfos
    {
        #region OOTB Fields
        /// <summary>
        /// The OOTB Browser Title Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public IFieldInfo BrowserTitle()
        {
            var browserTitle = PublishingFields.BrowserTitle;
            browserTitle.IsHiddenInNewForm = false;
            browserTitle.IsHiddenInEditForm = false;
            browserTitle.IsHiddenInListSettings = false;

            return browserTitle;
        }

        /// <summary>
        /// The OOTB Meta Description Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public IFieldInfo MetaDescription()
        {
            var metaDescription = PublishingFields.MetaDescription;
            metaDescription.IsHiddenInNewForm = false;
            metaDescription.IsHiddenInEditForm = false;
            metaDescription.IsHiddenInListSettings = false;

            return metaDescription;
        }

        /// <summary>
        /// The OOTB Meta Keywords Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public IFieldInfo MetaKeywords()
        {
            var metaKeywords = PublishingFields.MetaKeywords;
            metaKeywords.IsHiddenInNewForm = false;
            metaKeywords.IsHiddenInEditForm = false;
            metaKeywords.IsHiddenInListSettings = false;

            return metaKeywords;
        }

        /// <summary>
        /// The OOTB Hide From Internet Search Engines Field Info
        /// </summary>
        /// <returns>Field Info</returns>
        public IFieldInfo HideFromInternetSearchEngines()
        {
            var hideFromInternetSearchEngines = PublishingFields.HideFromInternetSearchEngines;
            hideFromInternetSearchEngines.IsHiddenInNewForm = false;
            hideFromInternetSearchEngines.IsHiddenInEditForm = false;
            hideFromInternetSearchEngines.IsHiddenInListSettings = false;

            return hideFromInternetSearchEngines;
        }
        #endregion
    }
}
