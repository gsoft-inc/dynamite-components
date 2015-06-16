using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration sample for the reusable Content 
    /// </summary>
    [Obsolete]
    public class PublishingReusableContentConfig : IPublishingReusableContentConfig
    {
        /// <summary>
        /// List of all the filename and keys of the reusable content
        /// </summary>
        public IList<string> ReusableContentNames
        {
            get
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// The category of the Reusable Content
        /// </summary>
        public string Category
        {
            get
            {
                return "Home";
            }
        }

        /// <summary>
        /// The Relative path from /Layouts
        /// </summary>
        public string RelativePath
        {
            get
            {
                return "GSoft.Dynamite/Html";
            }
        }
    }
}
