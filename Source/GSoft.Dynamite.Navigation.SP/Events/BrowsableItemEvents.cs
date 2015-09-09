using System;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Events
{
    /// <summary>
    /// Defines events for the <c>browsable</c> page content type
    /// </summary>
    public class BrowsableItemEvents : SPItemEventReceiver
    {
        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            base.ItemAdded(properties);

            using (var childScope = NavigationContainerProxy.BeginWebLifetimeScope(properties.Web))
            {
                this.EventFiringEnabled = false;
                var logger = childScope.Resolve<ILogger>();

                try
                {
                    var slugService = childScope.Resolve<ISlugBuilderService>();

                    // Set slugs
                    slugService.SetFriendlyUrlSlug(properties.ListItem);
                }
                catch (Exception e)
                {
                    logger.Exception(e);
                }
                finally
                {
                    this.EventFiringEnabled = true;
                }
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
                var logger = childScope.Resolve<ILogger>();

                try
                {
                    var slugService = childScope.Resolve<ISlugBuilderService>();

                    // Set slugs
                    slugService.SetFriendlyUrlSlug(properties.ListItem);
                }
                catch (Exception e)
                {
                    logger.Exception(e);
                }
                finally
                {
                    this.EventFiringEnabled = true;
                }
            }
        }
    }
}
