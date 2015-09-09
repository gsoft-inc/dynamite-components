using System.Globalization;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Design.Contracts.Configuration
{
    /// <summary>
    /// Home pages configuration used in the design module.
    /// </summary>
    public interface IHomePageConfig
    {
        /// <summary>
        /// Method that returns the appropriate home page according to its culture info
        /// </summary>
        /// <param name="cultureInfo">The home page's CultureInfo</param>
        /// <returns>Home page associated with <paramref name="cultureInfo"/>.</returns>
        PageInfo GetHomePageInfoByCulture(CultureInfo cultureInfo);
    }
}
