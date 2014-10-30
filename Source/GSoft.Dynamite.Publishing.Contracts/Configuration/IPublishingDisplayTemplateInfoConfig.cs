using System.Collections.Generic;
using GSoft.Dynamite.Branding;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IPublishingDisplayTemplateInfoConfig
    {
        IList<DisplayTemplateInfo> DisplayTemplates();
    }
}
