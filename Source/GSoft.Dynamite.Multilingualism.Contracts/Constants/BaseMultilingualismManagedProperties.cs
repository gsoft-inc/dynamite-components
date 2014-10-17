using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Multilingualism.Contracts.Constants
{
    public static class BaseMultilingualismManagedProperties
    {
        /// <summary>
        /// The content association key managed property name
        /// </summary>
        public static readonly ManagedPropertyInfo ContentAssociationKey = new ManagedPropertyInfo("ContentAssociationKeyOWSGUID");

        /// <summary>
        /// The item language
        /// </summary>
        public static readonly ManagedPropertyInfo ItemLanguage = new ManagedPropertyInfo("ItemLanguageOWSTEXT");
    }
}
