using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Contracts.Constants;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Configuration for the master page
    /// </summary>
    public class DesignConfig : IDesignConfig
    {
        public DesignConfig()
        {
        }

        /// <summary>
        /// The MasterPage HTMT Filename eg: GSoft.Dynamite.html
        /// </summary>
        public string MasterPageHTMLFilename
        {
            get { return DesignInfos.MasterPageHTMLFilename; }
        }

        /// <summary>
        /// The MasterPage MASTER Filename eg: GSoft.Dynamite.master
        /// </summary>
        public string MasterPageMASTERFilename
        {
            get { return DesignInfos.MasterPageMASTERFilename; }
        }

        /// <summary>
        /// The Logo URL eg: /Style%20Library/GSoft.Dynamite.Component/Images/dynamite-logo.png
        /// </summary>
        public string LogoUrl
        {
            get { return DesignInfos.LogoUrl; }
        }

        /// <summary>
        /// The Logo description (on mouse over)
        /// </summary>
        public string LogoUrlDescription
        {
            get { return DesignInfos.LogoUrlDescription; }
        }

        /// <summary>
        /// The SPColor file URL eg: /_catalogs/theme/15/GSoft.Dynamite.spcolor
        /// </summary>
        public string SPColorUrl
        {
            get { return DesignInfos.SPColorUrl; }

        }

        /// <summary>
        /// The SPFont file URL eg: /_catalogs/theme/15/GSoft.Dynamite.spfont
        /// </summary>
        public string SPFontUrl
        {
            get { return DesignInfos.SPFontUrl; }
        }
    }
}
