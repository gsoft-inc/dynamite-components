using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Search.Contracts.Services;

namespace GSoft.Dynamite.Search.SP.Events
{
    public class BrowsableItemEvents : SPItemEventReceiver
    {
        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);
            this.EventFiringEnabled = false;

            using (var childScope = SearchContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                var browserTitleService = childScope.Resolve<IBrowserTitleBuilderService>();

                // Set slugs
                browserTitleService.SetBrowserTitle(properties.Web, properties.ListItem);

                this.EventFiringEnabled = true;
            }
        }

        /// <summary>
        /// Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents properties of the event handler.</param>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            base.ItemUpdated(properties);
            this.EventFiringEnabled = false;
            using (var childScope = SearchContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                var browserTitleService = childScope.Resolve<IBrowserTitleBuilderService>();

                // Set slugs
                browserTitleService.SetBrowserTitle(properties.Web, properties.ListItem);

                this.EventFiringEnabled = true;
            }
        }
    }
}
