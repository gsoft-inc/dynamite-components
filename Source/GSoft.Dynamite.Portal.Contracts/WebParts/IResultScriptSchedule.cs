using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Portal.Contracts.WebParts
{
    /// <summary>
    /// The public interface of the web part <c>ResultScriptSchedule</c>
    /// </summary>
    public interface IResultScriptSchedule : IBaseWebPart
    {
        /// <summary>
        /// The start date property used for scheduling
        /// </summary>
        string StartDatePropertyName { get; set; }

        /// <summary>
        /// The end date property used for scheduling
        /// </summary>
        string EndDatePropertyName { get; set; }

        /// <summary>
        /// The Show advanced link
        /// </summary>
        bool ShowAdvancedLink { get; set; }
        
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

        /// <summary>
        /// Max Pages Before Current
        /// </summary>
        int MaxPagesBeforeCurrent { get; set; }

        /// <summary>
        /// The Empty Message
        /// </summary>
        string EmptyMessage { get; set; }

        /// <summary>
        /// The Item Body Template id
        /// </summary>
        string ItemBodyTemplateId { get; set; }

    }
}
