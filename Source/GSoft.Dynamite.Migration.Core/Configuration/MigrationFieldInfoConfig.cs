using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Property that return all the fields to create or configure in the migration module
        /// </summary>
        public IList<BaseFieldInfo> Fields 
        {
            get
            {
                return new List<BaseFieldInfo>()
                {
                    MigrationFieldInfos.InternalId
                };
            }
        }

        /// <summary>
        /// Gets the field from the Fields property where the id of that field is passed by parameter.
        /// </summary>
        /// <param name="fieldId">The unique identifier of the field we are looking for.</param>
        /// <returns>
        /// The field information.
        /// </returns>
        public BaseFieldInfo GetFieldById(Guid fieldId)
        {
            return this.Fields.Single(f => f.Id.Equals(fieldId));
        }
    }
}
