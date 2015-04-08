using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Term Group definitions for the publishing module
    /// </summary>
    public class PublishingTermSetInfos
    {
        /// <summary>
        /// The restricted navigation term set
        /// </summary>
        /// <returns>The term set</returns>
        public TermSetInfo RestrictedNews()
        {
            return new TermSetInfo(
                    new Guid("700c0057-26b7-455c-a1de-7b5b7c4c0f71"),
                    new Dictionary<CultureInfo, string>
                    {           
                        { new CultureInfo(Language.French.Culture.LCID), "Défault - Nouvelles" },
                        { new CultureInfo(Language.English.Culture.LCID), "Default - News" },
                    },
                    this.termGroupInfos.Restricted());
        }
    }
}
