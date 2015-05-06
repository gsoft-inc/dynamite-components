using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    /// <summary>
    /// Fields configuration for the document management module
    /// </summary>
    public class DocsFieldInfoConfig : IDocsFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the fields to create or configure in the document management module
        /// </summary>
        public IList<BaseFieldInfo> Fields 
        {
            get
            {
                return new List<BaseFieldInfo>();
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
