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
    public interface IDesignConfig
    {
        /// <summary>
        /// The MasterPage HTMT Filename eg: GSoft.Dynamite.html
        /// </summary>
        string MasterPageHTMLFilename { get; }

        /// <summary>
        /// The MasterPage MASTER Filename eg: GSoft.Dynamite.master
        /// </summary>
        string MasterPageMASTERFilename { get; }

        /// <summary>
        /// The Logo URL eg: /Style%20Library/GSoft.Dynamite.Component/Images/dynamite-logo.png
        /// </summary>
        string LogoUrl { get; }

        /// <summary>
        /// The Logo description (on mouse over)
        /// </summary>
        string LogoUrlDescription { get; }

        /// <summary>
        /// The SPColor file URL eg: /_catalogs/theme/15/GSoft.Dynamite.spcolor
        /// </summary>
        string SPColorUrl { get; }

        /// <summary>
        /// The SPFont file URL eg: /_catalogs/theme/15/GSoft.Dynamite.spfont
        /// </summary>
        string SPFontUrl { get; }
    }
}
