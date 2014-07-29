using System.Collections.Generic;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.Portal.Contracts.Utils
{
    /// <summary>
    /// Interface for the scheduling control
    /// </summary>
    public interface ISchedulingControl
    {
        /// <summary>
        /// Method to build a date range filter
        /// </summary>
        /// <param name="startDatePropertyName">The start date property name</param>
        /// <param name="endDatePropertyName">The end date property name</param>
        /// <returns>A list of refinement category</returns>
        List<RefinementCategory> BuildDateRangeRefiners(string startDatePropertyName, string endDatePropertyName);
    }
}
