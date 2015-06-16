using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Interface for the configuration of the reusable contents.
    /// </summary>
    [Obsolete]
    public interface IPublishingReusableContentConfig
    {
        /// <summary>
        /// Property that return all the names (key) and filename (both are the same) for all the reusable content to create
        /// </summary>
        IList<string> ReusableContentNames { get; }

        /// <summary>
        /// The category of the Reusable Content
        /// </summary>
        string Category { get; }

        /// <summary>
        /// The Relative path from /Layouts
        /// </summary>
        string RelativePath { get; }
    }
}
