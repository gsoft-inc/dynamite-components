using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermSetInfo values
    /// </summary>
    public class BasePublishingTermSetInfos
    {
        private BasePublishingTermGroupInfos termGroupInfos;

        /// <summary>
        /// 
        /// </summary>
        public BasePublishingTermSetInfos(BasePublishingTermGroupInfos termGroupInfos)
        {
            this.termGroupInfos = termGroupInfos;
        }

        #region Global Navigation Term Set

        /// <summary>
        /// The global navigation term set
        /// </summary>
        /// <returns>The term set</returns>
        public TermSetInfo GlobalNavigation()
        {   
            return new TermSetInfo(
                new Guid("f92bc16f-f73b-4568-b6af-f8dd87044653"),
                new Dictionary<CultureInfo, string>{           
                    {new CultureInfo(Language.French.Culture.LCID), "Navigation (FR)"},
                    {new CultureInfo(Language.English.Culture.LCID), "Navigation (EN)"}
                },
                this.termGroupInfos.Navigation());
        }

        #endregion

        #region Restricted News Term Set

        /// <summary>
        /// The restricted navigation term set
        /// </summary>
        /// <returns>The term set</returns>
        public TermSetInfo RestrictedNews()
        {
            return new TermSetInfo(
                new Guid("700c0057-26b7-455c-a1de-7b5b7c4c0f71"),
                new Dictionary<CultureInfo, string>{           
                    {new CultureInfo(Language.French.Culture.LCID), "Défault - Nouvelles"},
                    {new CultureInfo(Language.English.Culture.LCID), "Default - News"},
                },
                this.termGroupInfos.Restricted()
                );
        }
        
        #endregion
    }
}
