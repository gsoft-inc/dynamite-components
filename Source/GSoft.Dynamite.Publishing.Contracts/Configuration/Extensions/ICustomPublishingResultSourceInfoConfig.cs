﻿using System.Collections.Generic;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration.Extensions
{
    public interface ICustomPublishingResultSourceInfoConfig
    {
        IDictionary<string, ResultSourceInfo> ResultSources();
    }
}
