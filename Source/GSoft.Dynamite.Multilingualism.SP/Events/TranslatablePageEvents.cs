using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Multilingualism.SP.Events
{
    /// <summary>
    /// Events for the translatable page content type
    /// </summary>
    public class TranslatablePageEvents : SPItemEventReceiver
    {
        // Even though these events are ASYNC and we typically shouldn't care about their sequence,
        // we still care about avoiding overlap between multiple threads processing these events in parallel.
        // We use this lock to ensure these events are always executed in a sequence instead of simultaneously.
        private static object eventLock = new object();

        /// <summary>
        /// Asynchronous After event that occurs after a new item has been added to its containing object.
        /// Be careful, on a document library like pages library, ItemAdded NOT FIRING on the "New document" option on the ribbon. Use ItemUpdated instead
        /// </summary>
        /// <param name="properties">Event properties</param>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            lock (eventLock)
            {
                base.ItemAdded(properties);

                using (var childScope = MultilingualismContainerProxy.BeginWebLifetimeScope(properties.Web))
                {
                    this.EventFiringEnabled = false;
                    var logger = childScope.Resolve<ILogger>();

                    try
                    {
                        var item = properties.ListItem;

                        var contentAssociationHelper = childScope.Resolve<IContentAssocationService>();
                        var multilingualismFieldConfig = childScope.Resolve<IMultilingualismFieldInfoConfig>();

                        // Set source association unique identifier
                        item = contentAssociationHelper.SetSourceGuid(item, MultilingualismFieldInfos.ContentAssociationKey.InternalName);

                        // Set the translation language for the detected language managed property
                        item = contentAssociationHelper.SetTranslationLanguage(item, MultilingualismFieldInfos.ItemLanguage.InternalName);

                        // Set source item creator/author since the variation system
                        // overwrites the created by value
                        // TODO when comes the LifeCycle Module
                        item.Update();
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

        /// <summary>
        /// Asynchronous After event that occurs after an existing item is changed, for example, when the user changes data in one or more fields.
        /// </summary>
        /// <param name="properties">An <see cref="T:Microsoft.SharePoint.SPItemEventProperties" /> object that represents properties of the event handler.</param>
        public override void ItemUpdated(SPItemEventProperties properties)
        {
            lock (eventLock)
            {
                base.ItemUpdated(properties);

                using (var childScope = MultilingualismContainerProxy.BeginWebLifetimeScope(properties.Web))
                {
                    this.EventFiringEnabled = false;
                    var logger = childScope.Resolve<ILogger>();

                    try
                    {
                        // Refetch item to avoid save conflicts
                        var item = properties.ListItem;

                        var contentAssociationHelper = childScope.Resolve<IContentAssocationService>();
                        var multilingualismFieldConfig = childScope.Resolve<IMultilingualismFieldInfoConfig>();

                        // Set source association unique identifier
                        item = contentAssociationHelper.SetSourceGuid(item, MultilingualismFieldInfos.ContentAssociationKey.InternalName);

                        // Set the translation language for the detected language managed property
                        item = contentAssociationHelper.SetTranslationLanguage(item, MultilingualismFieldInfos.ItemLanguage.InternalName);

                        item.Update();
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
}
