using System;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermGroupInfo values
    /// </summary>
    public  class BasePublishingTermGroupInfos
    {
        #region Navigation Term Group

        /// <summary>
        /// The navigation term group
        /// </summary>
        /// <returns>The term group</returns>
        public TermGroupInfo Navigation()
        {
            return new TermGroupInfo(
                new Guid("6c3fb5cb-ea19-4a77-9c39-dc1583523f97"),
                "Portal - Navigation");
        }

        #endregion

        #region Restricted Term Group

        /// <summary>
        /// The restricted term group
        /// </summary>
        /// <returns>The term group</returns>
        public TermGroupInfo Restricted()
        {
            return new TermGroupInfo(
                new Guid("5a4b4147-be07-4f1e-9b90-262ae89cd5d3"),
                "Portal - Restricted");
        }

        #endregion
    }
}
