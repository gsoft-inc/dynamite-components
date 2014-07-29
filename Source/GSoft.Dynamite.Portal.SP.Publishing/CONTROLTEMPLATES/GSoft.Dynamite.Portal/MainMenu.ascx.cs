using System;
using System.Web.Script.Serialization;
using System.Web.UI;
using Autofac;
using GSoft.Dynamite.Portal.Contracts.Constants;
using GSoft.Dynamite.Portal.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.SP.Publishing.CONTROLTEMPLATES.GSoft.Dynamite.Portal
{
    /// <summary>
    /// User Control for a Main Menu
    /// </summary>
    public partial class MainMenu : UserControl
    {
        /// <summary>
        /// The number of level to flatten for specific UI purpose.
        /// Ex: if the number is 2, the second level will have the same parent as the first level
        /// Ex: if the number is 3, the second and third level will have the same parent as the first level
        /// </summary>
        public int NumberOfFlatLevel { get; set; }

        /// <summary>
        /// The raw data for the main menu
        /// </summary>
        public string MenuJSON { get; set; }

        /// <summary>
        /// Event receiver for the page load event
        /// </summary>
        /// <param name="sender">The object sending the event</param>
        /// <param name="e">The event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var navigationService = PublishingContainerProxy.Current.Resolve<INavigationService>();

            var serializer = new JavaScriptSerializer();

            this.NumberOfFlatLevel = 3;
            //this.MenuJSON = serializer.Serialize(navigationService.GetAllNavigationNodes(SPContext.Current.Web, PortalResultSources.AllMenuItems));
        }
    }
}
