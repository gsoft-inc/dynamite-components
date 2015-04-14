using System;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Contracts.Constants
{
    /// <summary>
    /// Common taxonomy term group information.
    /// </summary>
    public static class CommonTermGroupInfo
    {
        /// <summary>
        /// Gets the navigation term group information.
        /// </summary>
        /// <value>
        /// The term group information.
        /// </value>
        public static TermGroupInfo Navigation
        {
            get
            {
                return new TermGroupInfo(
                    new Guid("6c3fb5cb-ea19-4a77-9c39-dc1583523f97"),
                    "Portal - Navigation");
            }
        }

        /// <summary>
        /// The restricted term group information.
        /// </summary>
        /// <value>
        /// The term group information.
        /// </value>
        public static TermGroupInfo Restricted
        {
            get
            {
                return new TermGroupInfo(
                    new Guid("5a4b4147-be07-4f1e-9b90-262ae89cd5d3"),
                    "Portal - Restricted");
            }
        }

        /// <summary>
        /// The Keywords Term Group
        /// </summary>
        /// <returns>TermGroup Info</returns>
        public static TermGroupInfo Keywords
        {
            get
            {
                return new TermGroupInfo(
                    new Guid("a124883e-68c3-44fd-9112-0eff6b9411d1"),
                    "Portal - Keywords");
            }
        }
    }
}
