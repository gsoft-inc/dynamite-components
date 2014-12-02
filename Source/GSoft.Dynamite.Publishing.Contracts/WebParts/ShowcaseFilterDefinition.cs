using System;

namespace GSoft.Dynamite.Publishing.Contracts.WebParts
{
    /// <summary>
    /// Filter definition for the Product showcase
    /// </summary>
    [Serializable]
    public class ShowcaseFilterDefinition
    {
        /// <summary>
        /// Constructor for a filter definition
        /// </summary>
        /// <param name="property">The property to filter on</param>
        /// <param name="viewModel">The JavaScript ViewModel type that represent the filter implementation</param>
        public ShowcaseFilterDefinition(string property, string viewModel)
        {
            this.Property = property;
            this.JavaScriptViewModelFilterType = viewModel;
        }

        /// <summary>
        /// Property to filter on
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// The JavaScript method representing the view model implementation of the Filter
        /// </summary>
        public string JavaScriptViewModelFilterType { get; set; }
    }
}
