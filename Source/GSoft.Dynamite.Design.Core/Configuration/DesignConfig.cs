using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Contracts.Constants;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Configuration for the master page
    /// </summary>
    public class DesignConfig : IDesignConfig
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DesignConfig()
        {
        }

        /// <summary>
        /// The MasterPage HTMT Filename e.g.: GSoft.Dynamite.html
        /// </summary>
        public string MasterPageHTMLFilename
        {
            get { return DesignInfos.MasterPageHTMLFilename; }
        }

        /// <summary>
        /// The MasterPage MASTER Filename e.g.: GSoft.Dynamite.master
        /// </summary>
        public string MasterPageMASTERFilename
        {
            get { return DesignInfos.MasterPageMASTERFilename; }
        }

        /// <summary>
        /// The Logo URL e.g.: <c>/Style%20Library/GSoft.Dynamite.Component/Images/dynamite-logo.png</c>
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
        /// The SPColor file URL e.g.: <c>/_catalogs/theme/15/GSoft.Dynamite.spcolor</c>
        /// </summary>
        public string SPColorUrl
        {
            get { return DesignInfos.SPColorUrl; }
        }

        /// <summary>
        /// The SPFont file URL e.g.: <c>/_catalogs/theme/15/GSoft.Dynamite.spfont</c>
        /// </summary>
        public string SPFontUrl
        {
            get { return DesignInfos.SPFontUrl; }
        }
    }
}
