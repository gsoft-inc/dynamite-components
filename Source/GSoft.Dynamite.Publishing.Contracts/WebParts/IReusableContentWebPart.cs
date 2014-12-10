using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.WebParts;

namespace GSoft.Dynamite.Publishing.Contracts.WebParts
{
    /// <summary>
    /// The public interface of the Reusable Content Web Part
    /// </summary>
    public interface IReusableContentWebPart : IBaseWebPart
    {
        /// <summary>
        /// The key of the item from the Reusable Content list in
        /// the RootWeb of the site collection
        /// </summary>
        string ReusableContentTitle { get; set; }
    }
}
