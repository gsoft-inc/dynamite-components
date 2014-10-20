using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Design.Contracts.Configuration;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Configuration for the master page
    /// </summary>
    public class BaseDesignMasterPageConfig : IBaseDesignMasterPageConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public string Filename { get; set; }
    }
}
