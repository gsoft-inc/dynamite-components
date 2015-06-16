using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.ReusableContent;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// Holds the ReusableContentInfo we want to create by default.
    /// </summary>
    public static class PublishingReusableContentInfos
    {
        /// <summary>
        /// Hello World Reusable Content
        /// </summary>
        public static ReusableContentInfo HelloWorld
        {
            get
            {
                return new ReusableContentInfo("Hello World!", "Dynamite", true, true, "HelloWorld.html", "GSoft.Dynamite.Publishing/html");
            }
        }
    }
}
