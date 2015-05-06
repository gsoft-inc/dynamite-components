using System;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Contracts.Constants
{
    /// <summary>
    /// Common taxonomy term set information.
    /// </summary>
    public static class CommonTermSetInfo
    {
        /// <summary>
        /// Gets the english navigation term set information.
        /// </summary>
        /// <value>
        /// The term set information.
        /// </value>
        public static TermSetInfo EnglishNavigation
        {
            get
            {
                return new TermSetInfo(
                    new Guid("f92bc16f-f73b-4568-b6af-f8dd87044653"),
                    "Navigation (EN)",
                    CommonTermGroupInfo.Navigation);
            }
        }

        /// <summary>
        /// Gets the french navigation term set information.
        /// </summary>
        /// <value>
        /// The term set information.
        /// </value>
        public static TermSetInfo FrenchNavigation
        {
            get
            {
                return new TermSetInfo(
                    new Guid("ec024dae-b413-4c85-a407-b058ad7f6554"),
                    "Navigation (FR)",
                    CommonTermGroupInfo.Navigation);
            }
        }

        /// <summary>
        /// The Navigation Controls TermSet
        /// </summary>
        /// <returns>TermSet Info</returns>
        public static TermSetInfo NavigationControls
        {
            get
            {
                return new TermSetInfo(
                    new Guid("8f547d50-5f96-4741-a105-2d1fa91e3165"),
                    "Navigation Controls",
                    CommonTermGroupInfo.Keywords);
            }
        }
    }
}
