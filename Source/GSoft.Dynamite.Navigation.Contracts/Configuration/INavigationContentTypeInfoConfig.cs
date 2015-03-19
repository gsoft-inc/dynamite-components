using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    /// <summary>
    /// Content types configuration for the navigation module
    /// </summary>
    public interface INavigationContentTypeInfoConfig
    {
        /// <summary>
        /// Property that return all the content types to create or configure in the navigation module
        /// </summary>
        IList<ContentTypeInfo> ContentTypes { get; }
    }
}
