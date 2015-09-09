using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.Configuration
{
    /// <summary>
    /// Web part configurations used in the publishing module. 
    /// These configurations will be used in the pages configuration.
    /// </summary>
    public interface IPublishingWebPartInfoConfig
    {
        /// <summary>
        /// Property that returns all web part configurations for the publishing module.
        /// </summary>
        IList<WebPartInfo> WebParts { get; }

        /// <summary>
        /// Gets the web part information by title from this configuration.
        /// </summary>
        /// <param name="title">The title of the web part.</param>
        /// <returns>The web part information</returns>
        WebPartInfo GetWebPartInfoByTitle(string title);

        /// <summary>
        /// Gets the web part information by title and culture.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The web part information.</returns>
        WebPartInfo GetWebPartInfoByTitle(string title, CultureInfo culture);
    }
}
