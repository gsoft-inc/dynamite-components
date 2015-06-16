using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using GSoft.Dynamite.ReusableContent;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Class for the configuration of the Reusable Content information
    /// </summary>
    public class PublishingReusableContentInfoConfig : IPublishingReusableContentInfoConfig
    {
        /// <summary>
        /// A list of Reusable Content Info to Ensure in the Feature. Can be extended or overwrite via the dependency injection pattern.
        /// </summary>
        public IList<ReusableContentInfo> ReusableContents
        {
            get
            {
                return new List<ReusableContentInfo>() 
                {
                    PublishingReusableContentInfos.HelloWorld
                };
            }
        }
    }
}
