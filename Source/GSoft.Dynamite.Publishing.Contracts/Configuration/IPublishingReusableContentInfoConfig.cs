using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.ReusableContent;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Contract for the configuration of the Reusable Content information
    /// </summary>
    public interface IPublishingReusableContentInfoConfig
    {
        /// <summary>
        /// A list of Reusable Content info
        /// </summary>
        IList<ReusableContentInfo> ReusableContents { get; }
    }
}
