using System;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Base TermInfo values
    /// </summary>
    public class BasePublishingTermInfos
    {
        /// <summary>
        /// The news term
        /// </summary>
        /// <returns>The term</returns>
        public TermInfo NewsLabel()
        {
            return new TermInfo()
            {
                Id = new Guid("a681794e-c2bc-4145-b95a-3122388d65bf"),
                Name = "News"
            };
        }
    }
}
