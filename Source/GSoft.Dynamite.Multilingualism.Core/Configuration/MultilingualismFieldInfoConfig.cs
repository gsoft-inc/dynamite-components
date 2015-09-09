using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;

namespace GSoft.Dynamite.Multilingualism.Core.Configuration
{
    /// <summary>
    /// Re-implementation of the base publishing field info config to add multilingualism site column
    /// </summary>
    public class MultilingualismFieldInfoConfig : IMultilingualismFieldInfoConfig
    {
        /// <summary>
        /// Property to return the fields needed for the solution
        /// </summary>
        public IList<BaseFieldInfo> Fields
        {
            get
            {
                // Get the base publishing field info 
                var baseFieldInfo = new List<BaseFieldInfo>
                {
                    MultilingualismFieldInfos.ContentAssociationKey,
                    MultilingualismFieldInfos.ItemLanguage
                };

                return baseFieldInfo;
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
