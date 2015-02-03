using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Publishing.Contracts.WebParts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactFormWebPart
    {
        /// <summary>
        /// 
        /// </summary>
        string EmailAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ContactFormTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string EmailTemplate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string JavaScriptViewModel { get; set; }
    }
}
