using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions
{
    public interface ICustomPublishingDisplayTemplateConfig
    {
        IList<DisplayTemplateInfo> DisplayTemplates();
    }
}
