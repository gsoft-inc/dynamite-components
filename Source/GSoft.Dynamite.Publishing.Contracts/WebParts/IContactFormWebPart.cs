using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Publishing.Contracts.WebParts
{
    /// <summary>
    /// The public interface of ContactFormWebPart
    /// </summary>
    public interface IContactFormWebPart
    {
        /// <summary>
        /// The email address
        /// </summary>
        string EmailAddress { get; set; }

        /// <summary>
        /// The contact form template
        /// </summary>
        string ContactFormTemplate { get; set; }
        
        /// <summary>
        /// he name of the view model JavaScript class to use
        /// </summary>
        string JavaScriptViewModel { get; set; }

        /// <summary>
        /// The name of the resource for the success message
        /// </summary>
        string SuccessMessage { get; set; }

        string ValidationRules { get; set; }

        /// <summary>
        /// The name of the resource for the error message
        /// </summary>
        string ErrorMessage { get; set; }
    }
}
