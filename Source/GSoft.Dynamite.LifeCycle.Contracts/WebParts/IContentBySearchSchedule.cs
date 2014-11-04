using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.LifeCycle.Contracts.WebParts
{
    /// <summary>
    /// The Content by search schedule interface. Define a web part with start and end date properties
    /// </summary>
    public interface IContentBySearchSchedule : IBaseWebPart
    {
        /// <summary>
        /// Add the SEO properties
        /// </summary>
        bool AddSEOPropertiesFromSearch { get; set; }

        /// <summary>
        /// Enable the redirect to 404 if no item found
        /// </summary>
        bool Is404Enable { get; set; }

        /// <summary>
        /// The start date property used for scheduling
        /// </summary>
        string StartDatePropertyName { get; set; }

        /// <summary>
        /// The end date property used for scheduling
        /// </summary>
        string EndDatePropertyName { get; set; }

        /// <summary>
        /// The property mapping
        /// </summary>
        string PropertyMappings { get; set; }

        /// <summary>
        /// The Show advanced link
        /// </summary>
        bool ShowAdvancedLink { get; set; }

        /// <summary>
        /// The number of item
        /// </summary>
        int NumberOfItems { get; set; }

        /// <summary>
        /// Show preferences link
        /// </summary>
        bool ShowPreferencesLink { get; set; }

        /// <summary>
        /// Id of the result type
        /// </summary>
        string ResultTypeId { get; set; }

        /// <summary>
        /// Item template id
        /// </summary>
        string ItemTemplateId { get; set; }

        /// <summary>
        /// Group display template id
        /// </summary>
        string GroupTemplateId { get; set; }

        /// <summary>
        /// Render display template id
        /// </summary>
        string RenderTemplateId { get; set; }

        /// <summary>
        /// Number of result per page
        /// </summary>
        int ResultsPerPage { get; set; }

        /// <summary>
        /// If we show the paging
        /// </summary>
        bool ShowPaging { get; set; }

        /// <summary>
        /// Show Result count
        /// </summary>
        bool ShowResultCount { get; set; }

        /// <summary>
        /// Show language options
        /// </summary>
        bool ShowLanguageOptions { get; set; }

        /// <summary>
        /// Show definitions
        /// </summary>
        bool ShowDefinitions { get; set; }

        /// <summary>
        /// Query group name
        /// </summary>
        string QueryGroupName { get; set; }

        /// <summary>
        /// Data provider
        /// </summary>
        string DataProviderJSON { get; set; }

        /// <summary>
        /// Show Alert Me
        /// </summary>
        bool ShowAlertMe { get; set; }
    }
}
