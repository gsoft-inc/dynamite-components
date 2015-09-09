using System;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Navigation.Contracts.Services;
using GSoft.Dynamite.Publishing.Contracts.Constants;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.SP.Events
{
    /// <summary>
    /// Defines events for the Pages libraries.
    /// This should be hooked up to variation target label webs' Pages library only.
    /// </summary>
    public class VariationTargetPagesLibraryEvents : SPListEventReceiver
    {
        /// <summary>
        /// A field is being updated.
        /// This event receiver takes care of preventing updates to the DynamiteNavigation
        /// field definition.
        /// Variation propagation timer jobs tend to overwrite Taxonomy field definitions
        /// with the field definition from the source label web's Pages library.
        /// But we want to keep our target-web-specific Pages list field taxonomy mapping.
        /// This way, when users use a taxonomy picker on a target web's list item, they choose
        /// from the same term set as the one driving taxonomy navigation on that target site.
        /// RATIONALE: this is all meant to allow the target webs' navigation term set to evolve
        /// some independent leaf navigation nodes - independent from the usual term synchronization
        /// which starts at the source web.
        /// </summary>
        /// <param name="properties">List field updating event properties</param>
        public override void FieldUpdating(SPListEventProperties properties)
        {
            base.FieldUpdating(properties);

            if (properties.Field.InternalName == PublishingFieldInfos.Navigation.InternalName
                && System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpperInvariant().Contains("OWSTIMER"))
            {
                // Prevent all updates to the navigation field definition.
                // We assume than any time a timer job attempts to modify our field definition
                // (as a variations timer job would), we should prevent that change from
                // being persisted.
                properties.Status = SPEventReceiverStatus.CancelNoError;
            }
        }
    }
}
