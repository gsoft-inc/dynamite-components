using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Configuration contract for masterpage
    /// </summary>
    public interface IBaseDesignMasterPageConfig
    {
        string Filename { get; set; }
    }
}
