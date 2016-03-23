using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Design.Contracts.Configuration;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Default configuration to NOT use base CSS files from Components
    /// </summary>
    public class BaseCssConfig : IBaseCssConfig
    {
        /// <summary>
        /// Determines whether to import GSoft.Dynamite.Design CSS file
        /// </summary>
        public bool UseCoreDynamiteDesignCssFile
        {
            get { return false; }
        }
    }
}
