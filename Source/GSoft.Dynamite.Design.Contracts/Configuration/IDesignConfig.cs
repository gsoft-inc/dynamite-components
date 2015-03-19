namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Configuration contract for master page
    /// </summary>
    public interface IDesignConfig
    {
        /// <summary>
        /// The MasterPage HTMT Filename e.g.: GSoft.Dynamite.html
        /// </summary>
        string MasterPageHTMLFilename { get; }

        /// <summary>
        /// The MasterPage MASTER Filename e.g.: GSoft.Dynamite.master
        /// </summary>
        string MasterPageMASTERFilename { get; }

        /// <summary>
        /// The Logo URL e.g.: <c>/Style%20Library/GSoft.Dynamite.Component/Images/dynamite-logo.png</c>
        /// </summary>
        string LogoUrl { get; }

        /// <summary>
        /// The Logo description (on mouse over)
        /// </summary>
        string LogoUrlDescription { get; }

        /// <summary>
        /// The SPColor file URL e.g.: <c>/_catalogs/theme/15/GSoft.Dynamite.spcolor</c>
        /// </summary>
        string SPColorUrl { get; }

        /// <summary>
        /// The SPFont file URL e.g.: <c>/_catalogs/theme/15/GSoft.Dynamite.spfont</c>
        /// </summary>
        string SPFontUrl { get; }
    }
}
