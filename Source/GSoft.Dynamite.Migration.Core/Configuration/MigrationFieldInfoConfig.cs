using System.Collections.Generic;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Migration.Contracts.Configuration;
using GSoft.Dynamite.Migration.Contracts.Constants;

namespace GSoft.Dynamite.Migration.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the migration module
    /// </summary>
    public class MigrationFieldInfoConfig : IMigrationFieldInfoConfig
    {
        private readonly MigrationFieldInfos migrationFieldInfos;

        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationFieldInfoConfig"/> class.
        /// </summary>
        /// <param name="migrationFieldInfos">The migration field information.</param>
        public MigrationFieldInfoConfig(MigrationFieldInfos migrationFieldInfos)
        {
            this.migrationFieldInfos = migrationFieldInfos;
        }

        /// <summary>
        /// Property that return all the fields to create or configure in the migration module
        /// </summary>
        public IList<BaseFieldInfo> Fields 
        {
            get
            {
                return new List<BaseFieldInfo>()
                {
                    this.migrationFieldInfos.InternalId()
                };
            }
        }
    }
}
