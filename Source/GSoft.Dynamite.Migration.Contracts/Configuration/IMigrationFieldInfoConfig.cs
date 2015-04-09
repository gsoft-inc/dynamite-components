using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Migration.Contracts.Configuration
{
    /// <summary>
    /// Fields configuration for the migration module
    /// </summary>
    public interface IMigrationFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<BaseFieldInfo> Fields { get; }
    }
}
