using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Search.Contracts.Configuration;
using GSoft.Dynamite.Search.Contracts.Constants;
using GSoft.Dynamite.Search.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.Core.Services
{
    /// <summary>
    /// The service for the Browser title event receiver
    /// </summary>
    public class BrowserTitleBuilderService : IBrowserTitleBuilderService
    {
        private readonly ILogger logger;
        private readonly ISearchFieldInfoConfig searchFieldConfig;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="searchFieldConfig">Search module field info</param>
        public BrowserTitleBuilderService(ILogger logger, ISearchFieldInfoConfig searchFieldConfig)
        {
            this.logger = logger;
            this.searchFieldConfig = searchFieldConfig;
        }

        /// <summary>
        /// Sets the Browser Title Field
        /// </summary>
        /// <param name="web">The current Web</param>
        /// <param name="item">The current list item</param>
        public void SetBrowserTitle(SPWeb web, SPListItem item)
        {
            var browserTitleFieldName = this.searchFieldConfig.GetFieldById(SearchFieldInfos.BrowserTitle.Id).InternalName;
            var siteNameValue = web.Title;

            if (!string.IsNullOrEmpty(browserTitleFieldName) && item.Fields.ContainsField(browserTitleFieldName))
            {
                item[browserTitleFieldName] = item.Title + " | " + siteNameValue;
                this.logger.Info(
                    "BrowserTitleBuilderService.SetBrowserTitle: Set browser title '{0}' on item '{1}' in web '{2}'.",
                    item[browserTitleFieldName],
                    item.Title,
                    item.Web.Url);

                item.SystemUpdate();
            }
        }
    }
}
