using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Search;
using GSoft.Dynamite.Search.Enums;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public class PublishingFacetedNavigationInfos
    {
        private readonly PublishingManagedPropertyInfos managedPropertyInfos;
        private readonly PublishingDisplayTemplateInfos displayTemplateInfos;
        private readonly PublishingTermInfos termInfo;

        public PublishingFacetedNavigationInfos(PublishingTermInfos termInfo, PublishingManagedPropertyInfos managedPropertyInfos, PublishingDisplayTemplateInfos displayTemplateInfos)
        {
            this.managedPropertyInfos = managedPropertyInfos;
            this.displayTemplateInfos = displayTemplateInfos;
            this.termInfo = termInfo;
        }

        public FacetedNavigationInfo News
        {
            get
            {
                var refiners = new List<RefinerInfo>()
                {
                    {new RefinerInfo(this.managedPropertyInfos.NavigationText.Name, RefinerType.Text, false)},
                    {new RefinerInfo("Created", RefinerType.DateTime, false)},
                };

                return new FacetedNavigationInfo(this.termInfo.NewsLabel(), refiners);
            }
        }}
}
