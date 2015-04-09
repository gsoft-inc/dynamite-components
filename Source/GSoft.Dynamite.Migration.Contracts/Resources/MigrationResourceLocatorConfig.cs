using System.Collections.Generic;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Migration.Contracts.Constants;

namespace GSoft.Dynamite.Migration.Contracts.Resources
{
    /// <summary>
    /// Resource locator configuration for the migration module
    /// </summary>
    public class MigrationResourceLocatorConfig : IResourceLocatorConfig
    {
        private readonly ICollection<string> resourceFileKeys = new List<string>() { MigrationResources.Global };

        /// <summary>
        /// File Keys
        /// </summary>
        public ICollection<string> ResourceFileKeys
        {
            get { return this.resourceFileKeys; }
        }
    }
}
