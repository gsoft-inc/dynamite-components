using System;
using System.Collections.Generic;
using GSoft.Dynamite.Definitions;
using GSoft.Dynamite.Publishing.Contracts.Keys;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermGroupInfo values
    /// </summary>
    public  class BasePublishingTermGroupInfos
    {
        private BasePublishingTermSetInfos _termSetInfoValues;

        public BasePublishingTermGroupInfos(BasePublishingTermSetInfos termSetInfoValues)
        {
            _termSetInfoValues = termSetInfoValues;
        }


        #region Navigation Term Group

        /// <summary>
        /// The navigation term group
        /// </summary>
        /// <returns>The term group</returns>
        public TermGroupInfo Navigation ()
        {
            return new TermGroupInfo()
            {
                Id = new Guid("6c3fb5cb-ea19-4a77-9c39-dc1583523f97"),
                Name = "Portal - Navigation",
                TermSets = new Dictionary<string, TermSetInfo>()
                {
                    {BasePublishingTermSetInfoKeys.GlobalNavigationTermSet,_termSetInfoValues.GlobalNavigation()}
                }
            };
        }

        #endregion

        #region Restricted Term Group

        /// <summary>
        /// The restricted term group
        /// </summary>
        /// <returns>The term group</returns>
        public TermGroupInfo Restricted()
        {
            return new TermGroupInfo()
            {
                Id = new Guid("5a4b4147-be07-4f1e-9b90-262ae89cd5d3"),
                Name = "Portal - Restricted",
                TermSets = new Dictionary<string, TermSetInfo>()
                {
                    {BasePublishingTermSetInfoKeys.RestrictedNewsTermSet, _termSetInfoValues.RestrictedNews()}
                }
            };
        }

        #endregion
    }
}
