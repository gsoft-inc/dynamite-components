using System;
using System.ComponentModel;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls.WebParts;
using Autofac;
using GSoft.Dynamite.Globalization;
using GSoft.Dynamite.Portal.Contracts.Utils;
using GSoft.Dynamite.Portal.Contracts.WebParts;

namespace GSoft.Dynamite.Portal.SP.Publishing.WebParts.ChildNodes
{
    /// <summary>
    /// The ChildNodes web part
    /// </summary>
    [ToolboxItemAttribute(false)]
    public partial class ChildNodes : WebPart, IChildNodes
    {
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
            var resourceLocator = PublishingContainerProxy.Current.Resolve<IResourceLocator>();
            var serializer = new JavaScriptSerializer();

            var nodes = navigationBuilder.GetContextualNavigationTerms();

            this.NodesJSON = serializer.Serialize(nodes);

            this.UniquePerRequestId = Guid.NewGuid();
        }
    }
}
