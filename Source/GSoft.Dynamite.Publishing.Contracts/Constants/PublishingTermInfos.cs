using System;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Term definitions for the publishing module
    /// </summary>
    public class PublishingTermInfos
    {
        private PublishingTermSetInfos termSetInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="termSetInfos">The term set info objects configuration</param>
        public PublishingTermInfos(PublishingTermSetInfos termSetInfos)
        {
            this.termSetInfos = termSetInfos;
        }

        /// <summary>
        /// The news term
        /// </summary>
        /// <returns>The term</returns>
        public TermInfo NewsLabel()
        {
            return new TermInfo(new Guid("a681794e-c2bc-4145-b95a-3122388d65bf"), "News", this.termSetInfos.RestrictedNews());
        }

        /// <summary>
        /// The about term
        /// </summary>
        /// <returns>The term</returns>
        public TermInfo AboutLabel()
        {
            return new TermInfo(new Guid("870c52df-0ef0-4297-b9e8-0e965ac7c7c2"), "About", this.termSetInfos.GlobalNavigation());
        }
    }
}
