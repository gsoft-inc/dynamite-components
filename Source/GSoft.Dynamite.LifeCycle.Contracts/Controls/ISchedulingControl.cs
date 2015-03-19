using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Server.Search.WebControls;

namespace GSoft.Dynamite.LifeCycle.Contracts.Controls
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

        /// <summary>
        /// Method to build a date range filter used with the search keyword
        /// </summary>
        /// <param name="startDatePropertyName">The start date property name</param>
        /// <param name="endDatePropertyName">The end date property name</param>
        /// <returns>The refinement string</returns>
        string BuildDateRangeRefinersString(string startDatePropertyName, string endDatePropertyName);
    }
}
