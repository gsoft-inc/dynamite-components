using System;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermInfo values
    /// </summary>
    public class BasePublishingTermInfos
    {
        private BasePublishingTermSetInfos termSetInfos;

        public BasePublishingTermInfos(BasePublishingTermSetInfos termSetInfos)
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
    }
}
