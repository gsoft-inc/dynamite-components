using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.LifeCycle.Contracts.Controls;
using GSoft.Dynamite.LifeCycle.Contracts.WebParts;
using Microsoft.Office.Server.Search.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace GSoft.Dynamite.LifeCycle.SP.WebParts.ContentBySearchSchedule
{
    /// <summary>
    /// Content Search Web Part that supports date search minutes and seconds ranges filters
    /// </summary>
    [ToolboxItemAttribute(false)]
    public class ContentBySearchSchedule : ContentBySearchWebPart, IContentBySearchSchedule
    {
        private const string WebpartCategory = "Publishing Schedule Control";
        private const string StartDatePropertyname = "Publishing Start Date Managed Property Name";
        private const string EndDatePropertyname = "Publishing End Date Managed Property Name";
        private const string WebPartDescriptionResourceKey = "WebPart_PublishingControlWebPart_CSWP_Description";

        private string description;

        /// <summary>
        /// The Mosaic mode to decide which data we get
        /// </summary>
        [WebBrowsable(true), WebDisplayName("Rediriger vers 404 si aucun item."), WebDescription("Cocher pour rediriger vers la page 404 si aucun item n'est trouve."), Personalizable(PersonalizationScope.Shared), Category("Advanced")]
        public bool Is404Enable { get; set; }

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
            get { return this.description; }
            set { this.description = value; }
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
            this.InitializeDescriptionResource();

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
        /// WebPart OnRender
        /// </summary>
        /// <param name="writer">The event arguments</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (this.GetNumResults() < 1 && this.Is404Enable && SPContext.Current.FormContext.FormMode == SPControlMode.Display)
            {
                var baseUri = new Uri(SPContext.Current.Site.Url);
                var requestUri = new Uri(baseUri, HttpContext.Current.Request.RawUrl);
                HttpContext.Current.Server.TransferRequest(string.Format("{0}?requestUrl={1}", SPContext.Current.Site.FileNotFoundUrl, requestUri));
            }
            else
            {
                base.Render(writer);
            }
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
                using (var scope = LifeCycleContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
                {
                    var schedulingControlHelper = scope.Resolve<ISchedulingControl>();
                    var refinements = schedulingControlHelper.BuildDateRangeRefiners(this.StartDatePropertyName, this.EndDatePropertyName);

                    if (refinements.Count > 0)
                    {
                        dataProvider.FallbackRefinementFilters = refinements;
                    } 
                }
            }
        }

        private int GetNumResults()
        {
            var syncResult = this.AppManager.GetSyncResult(this.QueryGroupName);
            var resultTable = syncResult.Filter("TableType", this.TargetResultTable).FirstOrDefault();

            return resultTable != null ? resultTable.TotalRows : -1;
        }

        private void InitializeDescriptionResource()
        {
            if (string.IsNullOrEmpty(this.description))
            {
                // Set the description from the resource value
                using (var scope = LifeCycleContainerProxy.BeginWebLifetimeScope(SPContext.Current.Web))
                {
                    var resourceLocator = scope.Resolve<IResourceLocator>();
                    this.description = resourceLocator.Find(WebPartDescriptionResourceKey);
                }
            }
        }
    }
}
