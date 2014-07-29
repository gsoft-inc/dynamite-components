using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Portal.Contracts.WebParts;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace GSoft.Dynamite.Portal.SP.Publishing.WebParts.ResultScriptSchedule
{
    /// <summary>
    /// The result script web part
    /// </summary>
    [ToolboxItemAttribute(false)]
    public class ResultScriptSchedule : ResultScriptWebPart, IResultScriptSchedule
    {
        private const string WebpartCategory = "Publishing Schedule Control";
        private const string StartDatePropertyname = "Publishing Start Date Managed Property Name";
        private const string EndDatePropertyname = "Publishing End Date Managed Property Name";

        private ISchedulingControl shedulingControlHelper;
        private IResourceLocator resourceLocator;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ResultScriptSchedule()
        {
            this.ResolveDependencies();
        }

        /// <summary>
        /// Start date property name
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName(StartDatePropertyname), WebDescription(""), Category(WebpartCategory)]
        public string StartDatePropertyName { get; set; }

        /// <summary>
        /// End date property name
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName(EndDatePropertyname), WebDescription(""), Category(WebpartCategory)]
        public string EndDatePropertyName { get; set; }

        /// <summary>
        /// WebPart Description
        /// </summary>
        public override string Description
        {
            get { return this.resourceLocator.Find("WebPart_PublishingControlWebPart_ResultScript_Desc"); }
            set { }
        }

        /// <summary>
        /// Override ToolPart to get custom properties working 
        /// </summary>
        /// <returns>Table of ToolPart objects</returns>
        public override ToolPart[] GetToolParts()
        {
            var parts = new List<ToolPart>(base.GetToolParts()) { new CustomPropertyToolPart() };
            return parts.ToArray();
        }

        /// <summary>
        /// WebPart OnLoad
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnLoad(EventArgs e)
        {
            if (this.AppManager != null)
            {
                if (this.AppManager.QueryGroups.ContainsKey(this.QueryGroupName) &&
                    this.AppManager.QueryGroups[this.QueryGroupName].DataProvider != null)
                {
                    this.AppManager.QueryGroups[this.QueryGroupName].DataProvider.BeforeSerializeToClient += this.EnhanceQuery;
                }
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Modify the behavior of the original query
        /// </summary>
        /// <param name="sender">The data provider object</param>
        /// <param name="e">The event arguments</param>
        private void EnhanceQuery(object sender, ScriptWebPart.BeforeSerializeToClientEventArgs e)
        {
            var dataProvider = sender as DataProviderScriptWebPart;

            if (dataProvider != null)
            {
                var refinements = this.shedulingControlHelper.BuildDateRangeRefiners(this.StartDatePropertyName, this.EndDatePropertyName);

                if (refinements.Count > 0)
                {
                    dataProvider.FallbackRefinementFilters = refinements;
                }
            }
        }

        private void ResolveDependencies()
        {
            this.shedulingControlHelper = PublishingContainerProxy.Current.Resolve<ISchedulingControl>();
            this.resourceLocator = PublishingContainerProxy.Current.Resolve<IResourceLocator>();
        }
    }
}