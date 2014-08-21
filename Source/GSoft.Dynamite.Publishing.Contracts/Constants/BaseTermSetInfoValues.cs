using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class BaseTermSetInfoValues
    {
        #region Global Navigation Term Set

        public static readonly TermSetInfo GlobalNavigation = new TermSetInfo()
        {
            Labels = new Dictionary<int, string>
            {
                {Language.French.Culture.LCID, "Navigation (EN)"},
                {Language.English.Culture.LCID, "Navigation (EN)"}
            }
        };

        #endregion

        #region Restricted News Term Set

        public static readonly TermSetInfo RestrictedNews = new TermSetInfo()
        {
            Labels = new Dictionary<int, string>
            {
                {Language.French.Culture.LCID, "Défault - Nouvelles"},
                {Language.English.Culture.LCID, "Default - News"}
            }
        };

        #endregion
    }
}
