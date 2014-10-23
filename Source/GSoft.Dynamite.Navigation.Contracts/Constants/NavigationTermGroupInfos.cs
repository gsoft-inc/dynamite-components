using System;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Navigation.Contracts.Constants
{
    /// <summary>
    /// Base TermGroupInfo values
    /// </summary>
    public class NavigationTermGroupInfos
    {
        /// <summary>
        /// The Keywords Term Group
        /// </summary>
        /// <returns>TermGroup Info</returns>
        public TermGroupInfo Keywords()
        {
            return new TermGroupInfo(
                new Guid("a124883e-68c3-44fd-9112-0eff6b9411d1"),
                "Portal - Keywords");
        }
    }
}
