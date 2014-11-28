using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Globalization.Variations;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Events
{
    public class TargetContentItemEvents : SPItemEventReceiver
    {
        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
        /// Be careful, on a document library like pages libray, ItemAdded NOT FIRING on the "New document" option on the ribbon. Use ItemUpdated instead
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);

            using (var childScope = NavigationContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                this.EventFiringEnabled = false;

                var navigationTermService = childScope.Resolve<INavigationTermBuilderService>();
                var variationHelper = childScope.Resolve<IVariationHelper>();

                var item = properties.ListItem;

                // If the content is created at the source label, create the unique identifier
                if (variationHelper.IsCurrentWebSourceLabel(item.Web))
                {
                    // Create term in other term sets
                    navigationTermService.SyncNavigationTerm(properties.Web.Site, properties.ListItem);
                }

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

            using (var childScope = NavigationContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                this.EventFiringEnabled = false;

                var navigationTermService = childScope.Resolve<INavigationTermBuilderService>();
                var variationHelper = childScope.Resolve<IVariationHelper>();

                var item = properties.ListItem;

                // If the content is created at the source label, sync the term
                if (variationHelper.IsCurrentWebSourceLabel(item.Web))
                {
                    // Create term in other term sets
                    navigationTermService.SyncNavigationTerm(properties.Web.Site, properties.ListItem);
                }

                this.EventFiringEnabled = true;
            }
        }

        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);

            using (var childScope = NavigationContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                this.EventFiringEnabled = false;

                var navigationTermService = childScope.Resolve<INavigationTermBuilderService>();
                var variationHelper = childScope.Resolve<IVariationHelper>();

                var item = properties.ListItem;

                // If the content is created at the source label, delete the term
                if (variationHelper.IsCurrentWebSourceLabel(item.Web))
                {
                    // Set Term driven page
                    navigationTermService.DeleteAssociatedPageTerm(properties.Web.Site, item);
                }

                this.EventFiringEnabled = true;
            }
        }
    }
}
