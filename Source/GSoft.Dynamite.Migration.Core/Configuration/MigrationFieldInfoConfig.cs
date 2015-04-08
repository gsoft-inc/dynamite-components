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
        private readonly MigrationFieldInfos fieldInfos;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fieldInfos">The field definitions from the migration module</param>
        public MigrationFieldInfoConfig(MigrationFieldInfos fieldInfos)
        {
            this.fieldInfos = fieldInfos;
        }

        /// <summary>
        /// Property that return all the fields to create or configure in the document management module
        /// </summary>
        public IList<BaseFieldInfo> Fields 
        {
            get
            {
                return new List<BaseFieldInfo>()
                {
                    this.fieldInfos.InternalId()
                };
            }
        }
    }
}
