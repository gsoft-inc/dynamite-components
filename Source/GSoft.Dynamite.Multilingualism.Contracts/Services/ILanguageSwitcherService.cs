using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Navigation;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;

namespace GSoft.Dynamite.Multilingualism.Contracts.Services
{
    public interface ILanguageSwitcherService
    {
        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        string Label { get; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        Uri Url { get; }

        /// <summary>
        /// Gets or sets a value indicating whether [is visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is visible]; otherwise, <c>false</c>.
        /// </value>
        bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the application cache expiration in seconds.
        /// </summary>
        /// <value>
        /// The application cache expiration in seconds.
        /// </value>
        int AppCacheExpirationInSeconds { get; set; }

        /// <summary>
        /// Gets the peer variation labels for the current web.
        /// </summary>
        /// <param name="currentUrl">The current URL.</param>
        /// <param name="variationsContext">The variations context.</param>
        /// <param name="currentUser">The current user.</param>
        /// <returns>A collection of variation labels.</returns>
        IList<VariationLabel> GetPeerVariationLabels(Uri currentUrl, Variations variationsContext, SPUser currentUser);

        /// <summary>
        /// Gets the peer URL for a given variation label (for current context's item).
        /// </summary>
        /// <param name="label">The variation label.</param>
        /// <param name="associationKey">Key that links variation items together.</param>
        /// <returns>
        /// The peer variation URL.
        /// </returns>
        Uri GetPeerUrl(VariationLabel label, string associationKey);
    }
}
