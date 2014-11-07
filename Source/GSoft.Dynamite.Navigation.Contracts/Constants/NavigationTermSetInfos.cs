using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Base TermSetInfo values
    /// </summary>
    public class NavigationTermSetInfos
    {
        private readonly NavigationTermGroupInfos termGroupInfos;

        /// <summary>
        /// Initializes properties
        /// </summary>
        /// <param name="termGroupInfos">TermGroup Info</param>
        public NavigationTermSetInfos(NavigationTermGroupInfos termGroupInfos)
        {
            this.termGroupInfos = termGroupInfos;
        }

        /// <summary>
        /// The Navigation Controls TermSet
        /// </summary>
        /// <returns>TermSet Info</returns>
        public TermSetInfo NavigationControls()
        {
            return new TermSetInfo(
                new Guid("8f547d50-5f96-4741-a105-2d1fa91e3165"),
                new Dictionary<CultureInfo, string>
                {           
                    { new CultureInfo(Language.English.Culture.LCID), "Navigation Controls" }
                },
                this.termGroupInfos.Keywords());
        }

    }
}
