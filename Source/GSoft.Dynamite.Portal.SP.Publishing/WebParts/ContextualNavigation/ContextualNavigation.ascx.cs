using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using GSoft.Dynamite.Navigation;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Portal.Contracts.WebParts;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Publishing.WebParts.ContextualNavigation
{
    /// <summary>
    /// WebPart to display contextual navigation on where we are
    /// </summary>
    [ToolboxItemAttribute(false)]
    public partial class ContextualNavigation : WebPart, IContextualNavigation
    {
        /// <summary>
        /// Gets leafs.
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Display Navigation with same level pages"), WebDescription(""), DefaultValue(false), Category("Advanced")]
        public bool SearchPages { get; set; }

        /// <summary>
        /// Gets the Parent of the current node else use the current node as parent.
        /// </summary>
        [Personalizable(PersonalizationScope.Shared), WebBrowsable(true), WebDisplayName("Use Parent of the current node"), WebDescription(""), DefaultValue(false), Category("Advanced")]
        public bool IsParentNode { get; set; }

        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>
        /// The Nodes JSON.
        /// </value>
        public string NodesJSON { get; set; }

        /// <summary>
        /// A unique ID to distinguish this control instance from other instances in the same page
        /// </summary>
        public Guid UniquePerRequestId { get; set; }

        /// <summary>
        /// <c>OnInit</c> event handler
        /// </summary>
        /// <param name="e">the event arguments</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.InitializeControl();
        }

        /// <summary>
        /// Page load event handler
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var navigationBuilder = PublishingContainerProxy.Current.Resolve<INavigationBuilder>();
            var serializer = new JavaScriptSerializer();

            var nodes = navigationBuilder.GetContextualNavigationAndItems(SPContext.Current.Web, this.IsParentNode);

            this.NodesJSON = serializer.Serialize(nodes);

            this.UniquePerRequestId = Guid.NewGuid();
        }
    }
}
