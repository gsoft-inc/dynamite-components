using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    public interface IBaseFieldInfoConfig
    {
        IDictionary<string, FieldInfo> Fields();
    }
}
