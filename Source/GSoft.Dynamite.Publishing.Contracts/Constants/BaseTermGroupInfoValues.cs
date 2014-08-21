using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public static class BaseTermGroupInfoValues
    {
        #region Navigation Term Group

        public static readonly TermGroupInfo Navigation = new TermGroupInfo()
        {
            Name = "Portal - Navigation",
            TermSets = new Dictionary<string, TermSetInfo>()
            {
                {BaseTermSetInfoKeys.GlobalNavigationTermSet,BaseTermSetInfoValues.GlobalNavigation}
            }
        };

        #endregion

        #region Restricted Term Group

        public static readonly TermGroupInfo Restricted = new TermGroupInfo()
        {
            Name = "Portal - Restricted",
            TermSets = new Dictionary<string, TermSetInfo>()
            {
                {BaseTermSetInfoKeys.RestrictedNewsTermSet,BaseTermSetInfoValues.RestrictedNews}
            }
        };

        #endregion
    }
}
