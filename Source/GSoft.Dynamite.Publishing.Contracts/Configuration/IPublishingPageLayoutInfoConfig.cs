using System.Collections.Generic;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingPageLayoutInfoConfig
    {
        IList<PageLayoutInfo> PageLayouts { get; }
    }
}
