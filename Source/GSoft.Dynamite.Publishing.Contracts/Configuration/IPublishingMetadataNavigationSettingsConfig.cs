using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Lists;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingMetadataNavigationSettingsConfig
    {
        /// <summary>
        /// Property that return all the lists to create
        /// </summary>
        IList<MetadataNavigationSettingsInfo> MetadataNavigationSettings { get; }
    }
}
