using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Option to use base CSS files from Components or not 
    /// </summary>
    public interface IBaseCssConfig
    {
        /// <summary>
        /// Determines whether to import GSoft.Dynamite.Design CSS file
        /// </summary>
        bool UseCoreDynamiteDesignCssFile { get; }
    }
}
