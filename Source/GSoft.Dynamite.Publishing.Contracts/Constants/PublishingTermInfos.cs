using System;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Term definitions for the publishing module
    /// </summary>
    public static class PublishingTermInfos
    {
        /// <summary>
        /// The news term
        /// </summary>
        /// <returns>The term</returns>
        public static TermInfo News
        {
            get 
            {
                return new TermInfo()
                {
                    Id = new Guid("a681794e-c2bc-4145-b95a-3122388d65bf"),
                    Label = "News"
                };
            }
        }
    }
}
