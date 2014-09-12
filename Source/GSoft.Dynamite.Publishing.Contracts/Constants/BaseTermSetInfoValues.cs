using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermSetInfo values
    /// </summary>
    public class BaseTermSetInfoValues
    {
        private readonly BaseTermInfoValues _termInfoValues;

        public BaseTermSetInfoValues(BaseTermInfoValues termInfoValues)
        {
            _termInfoValues = termInfoValues;
        }

        #region Global Navigation Term Set

        /// <summary>
        /// The global navigation term set
        /// </summary>
        /// <returns>The term set</returns>
        public TermSetInfo GlobalNavigation()
        {   
            return new TermSetInfo()
            {
                Id = new Guid("f92bc16f-f73b-4568-b6af-f8dd87044653"),
                Labels = new Dictionary<CultureInfo, string>{           
                    {new CultureInfo(Language.French.Culture.LCID), "Navigation (EN)"},
                    {new CultureInfo(Language.English.Culture.LCID), "Navigation (EN)"}
                }
            };
        }

        #endregion

        #region Restricted News Term Set

        /// <summary>
        /// The restricted navigation term set
        /// </summary>
        /// <returns>The term set</returns>
        public TermSetInfo RestrictedNews()
        {
            return new TermSetInfo()
            {
                Id = new Guid("700c0057-26b7-455c-a1de-7b5b7c4c0f71"),
                Labels = new Dictionary<CultureInfo, string>{           
                    {new CultureInfo(Language.French.Culture.LCID), "Défault - Nouvelles"},
                    {new CultureInfo(Language.English.Culture.LCID), "Default - News"}
                },
                Terms = new Dictionary<string, TermInfo>
                {
                    {"NewsLabel", _termInfoValues.NewsLabel()}
                }
            };
        }
        
        #endregion
    }
}
