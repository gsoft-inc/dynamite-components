using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IBasePublishingDisplayTemplateInfoConfig
    {
        IList<DisplayTemplateInfo> DisplayTemplates();
    }
}
