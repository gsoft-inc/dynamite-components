using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    /// <summary>
    /// Term sets configuration for the multilingualism module
    /// </summary>
    public class MultilingualismTermSetInfos
    {
        private readonly PublishingTermGroupInfos termGroupInfos;

        /// <summary>
        /// Initializes properties
        /// </summary>
        /// <param name="termGroupInfos">TermGroup Info</param>
        public MultilingualismTermSetInfos(PublishingTermGroupInfos termGroupInfos)
        {
            this.termGroupInfos = termGroupInfos;
        }

        /// <summary>
        /// The Navigation Controls TermSet
        /// </summary>
        /// <returns>TermSet Info</returns>
        public TermSetInfo NavigationFrench()
        {
            return new TermSetInfo(
                new Guid("ec024dae-b413-4c85-a407-b058ad7f6554"),
                new Dictionary<CultureInfo, string>
                {           
                    { new CultureInfo(Language.French.Culture.LCID), "Navigation (FR)" },
                    { new CultureInfo(Language.English.Culture.LCID), "Navigation (FR)" }
                },
                this.termGroupInfos.Navigation());
        }
    }
}
