using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Multilingualism.Contracts.Configuration;
using GSoft.Dynamite.Multilingualism.Contracts.Constants;
using GSoft.Dynamite.Multilingualism.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Taxonomy;

namespace GSoft.Dynamite.Multilingualism.SP.Events
{
    /// <summary>
    /// Defines events for variation-enabled lists.
    /// This should be hooked up to variation target label webs' lists only.
    /// </summary>
    public class VariationTargetListEvents : SPListEventReceiver
    {
        /// <summary>
        /// A field is being updated.
        /// This event receiver takes care of preventing updates to any TaxonomyField
        /// field definition.
        /// Variation propagation timer jobs tend to overwrite Taxonomy field definitions
        /// with the field definition from the source label web's Pages library.
        /// But we want to keep our target-web-specific list field taxonomy mapping.
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

            if (properties.Field is TaxonomyField
                && Process.GetCurrentProcess().ProcessName.ToUpperInvariant().Contains("OWSTIMER"))
            {
                // Prevent all updates to the any taxonomy field definition (typically, this will be
                // a field linked to one of our variation-label-specfic Navigation term sets).
                // We assume than any time a timer job attempts to modify our field definition
                // (as a variations timer job would), we should prevent that change from
                // being persisted.
                properties.Status = SPEventReceiverStatus.CancelNoError;
            }
        }
    }
}
