using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Search.Contracts.Services
{
    /// <summary>
    /// The interface for the Browser title event receiver
    /// </summary>
    public interface IBrowserTitleBuilderService
    {
        /// <summary>
        /// Sets the Browser Title Field
        /// </summary>
        /// <param name="web">The current Web</param>
        /// <param name="item">The current list item</param>
        void SetBrowserTitle(SPWeb web, SPListItem item);
    }
}
