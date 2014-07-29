    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Constants
{
    /// <summary>
    /// Holds the Content Types for the Portal solution
    /// </summary>
    public static class PortalContentTypes
    {
        #region Browsable Item
        /// <summary>
        /// Represents an item accessible from the navigation structure (Navigation TermSet)
        /// </summary>                                                                                 
        public static readonly SPContentTypeId BrowsableItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B44");
        #endregion

        #region Translatable Item
        /// <summary>
        /// Represents an item translatable with SharePoint variations
        /// (Inherit from browsed Item)
        /// </summary>
        public static readonly SPContentTypeId TranslatableItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B4401");
        #endregion

        #region Schedulable Item
        /// <summary>
        /// Represents an item accessible from the navigation structure
        /// (Inherit from Translatable Item)
        /// </summary>
        public static readonly SPContentTypeId SchedulableItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B440101");
        #endregion

        #region Featured Item
        /// <summary>
        /// Represents an item that can be inserted in the navigation menu via a boolean flag and can be featured in a top new widget
        /// (Inherit from Schedulable Item)        
        /// </summary>
        public static readonly SPContentTypeId FeaturedItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B44010101");
        #endregion

        #region Content Item
        /// <summary>
        /// The Content Item Content Type Id
        /// (Inherit from MenuManageable Item)
        /// </summary>
        public static readonly SPContentTypeId ContentItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B4401010101");
        #endregion

        #region News Item
        /// <summary>
        /// The News Item Content Type Id
        /// (Inherit from MenuManageable Item)   
        /// </summary>
        public static readonly SPContentTypeId NewsItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B440101010103");
        #endregion

        #region NodeDescription Item
        /// <summary>
        /// The node description Item Content Type Id
        /// (Inherit from Translatable Item)   
        /// </summary>
        public static readonly SPContentTypeId NodeDescriptionItemContentTypeId = new SPContentTypeId("0x0100F39089C4394B43D29606F78A48696B44010102");
        #endregion

        #region Translatable Page
        /// <summary>
        /// The Translatable Page Content Type Id
        /// (Inherits from Page)
        /// </summary>
        public static readonly SPContentTypeId TranslatablePageContentTypeId = new SPContentTypeId("0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF3901");
        #endregion

        #region Content Page
        /// <summary>
        /// The Content Page Content Type Id
        /// (Inherit from Translatable Page)
        /// </summary>
        public static readonly SPContentTypeId ContentPageContentTypeId = new SPContentTypeId("0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF390101");
        #endregion

        #region News Page
        /// <summary>
        /// The News Page Content Type Id
        /// (Inherit from Content Page)
        /// </summary>
        public static readonly SPContentTypeId NewsPageContentTypeId = new SPContentTypeId("0x010100C568DB52D9D0A14D9B2FDCC96666E9F2007948130EC3DB064584E219954237AF39010101");
        #endregion
    }
}
