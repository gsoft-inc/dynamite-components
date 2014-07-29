using System;
using System.Collections.Generic;
using GSoft.Dynamite.Portal.Contracts.Utils;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Portal.Core.Utils
{
    /// <summary>
    /// Class to schedule date in refiners
    /// </summary>
    public class SchedulingControl : ISchedulingControl
    {
        /// <summary>
        /// Build a Date range refiner
        /// </summary>
        /// <param name="startDatePropertyName">The start date property name</param>
        /// <param name="endDatePropertyName">The end date property name</param>
        /// <returns>A list of refinement category</returns>
        public List<RefinementCategory> BuildDateRangeRefiners(string startDatePropertyName, string endDatePropertyName)
        {
            var refinements = new List<RefinementCategory>();
            var startDate = new RefinementCategory();
            var endDate = new RefinementCategory();

            if (!string.IsNullOrEmpty(startDatePropertyName) || !string.IsNullOrEmpty(endDatePropertyName))
            {
                var today = SPUtility.CreateISO8601DateTimeFromSystemDateTime(DateTime.Now.ToUniversalTime());

                if (!string.IsNullOrEmpty(startDatePropertyName))
                {
                    startDate.k = false;
                    startDate.n = startDatePropertyName;
                    startDate.o = "and";
                    startDate.t = new[] { "range(min," + today + ",to=\"le\")" };
                    refinements.Add(startDate);
                }

                if (!string.IsNullOrEmpty(endDatePropertyName))
                {
                    endDate.k = false;
                    endDate.n = endDatePropertyName;
                    endDate.o = "and";
                    endDate.t = new[] { "range(" + today + ",max, from=\"ge\")" };
                    refinements.Add(endDate);
                }
            }

            return refinements;
        }
    }
}
