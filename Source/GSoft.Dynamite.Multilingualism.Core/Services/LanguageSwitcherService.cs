using System;
using System.Collections.Generic;
using System.Globalization;
using GSoft.Dynamite.Cache;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using GSoft.Dynamite.Navigation;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Multilingualism.Core.Services
{
    public class LanguageSwitcherService : ILanguageSwitcherService
    {
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LanguageSwitcherService" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="cacheHelper">The application cache helper.</param>
        public LanguageSwitcherService(ILogger logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        public string Label { get; private set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is visible]; otherwise, <c>false</c>.
        /// </value>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the application cache expiration in seconds.
        /// </summary>
        /// <value>
        /// The application cache expiration in seconds.
        /// </value>
        public int AppCacheExpirationInSeconds { get; set; }

        /// <summary>
        /// Gets the peer variation labels for the current web.
        /// </summary>
        /// <param name="currentUrl">The current URL.</param>
        /// <param name="variationsContext">The variations context.</param>
        /// <param name="currentUser">The current user.</param>
        /// <returns>A collection of variation labels.</returns>
        public IList<VariationLabel> GetPeerVariationLabels(Uri currentUrl, Variations variationsContext, SPUser currentUser)
        {
            try
            {
                using (new SPMonitoredScope("LanguageSwitcherService::GetPeerVariationLabels"))
                {
                    var labels = new List<VariationLabel>();
                    var spawnedLabels = variationsContext.UserAccessibleLabels;
                    foreach (var label in spawnedLabels)
                    {
                        try
                        {
                            // if it isn't the current label
                            var labelUrl = new Uri(label.TopWebUrl);
                            if (!currentUrl.AbsoluteUri.StartsWith(labelUrl.AbsoluteUri, StringComparison.OrdinalIgnoreCase))
                            {
                                labels.Add(label);
                            }
                        }
                        catch
                        {
                            // SharePoint throws an error on GetPeer when the control is called from a layout page
                            this.logger.Info("Language toggle control cannot be rendered at '{0}'.", currentUrl);
                            this.IsVisible = false;
                        }
                    }

                    return labels;
                }
            }
            catch
            {
                // SharePoint throws an error on the call for UserAccessibleLabels if there are no labels
                this.logger.Warn("Language toggle control cannot find any user accessible labels at '{0}' for user login {1}.", currentUrl.AbsoluteUri, currentUser.LoginName);

                this.IsVisible = false;
                return new List<VariationLabel>();
            }
        }

        /// <summary>
        /// Gets the peer URL for a given variation label.
        /// </summary>
        /// <param name="label">The variation label.</param>
        /// <param name="catalogNavigationContext">The catalog navigation context.</param>
        /// <returns>
        /// The peer variation URL.
        /// </returns>
        public Uri GetPeerUrl(VariationLabel label, ICatalogNavigation catalogNavigationContext)
        {
            try
            {
                using (new SPMonitoredScope("LanguageToggleViewModel::GetPeerUrl"))
                {
                    return catalogNavigationContext.GetVariationPeerUrl(label);
                }
            }
            catch (Exception exception)
            {
                this.logger.Error(exception.Message);
                return new Uri(label.TopWebUrl);
            }
        }
    }
}
