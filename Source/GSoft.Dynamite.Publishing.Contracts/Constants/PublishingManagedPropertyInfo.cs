using GSoft.Dynamite.Definitions;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    public static class PublishingManagedPropertyInfo
    {
        /// <summary>
        /// The navigation managed property name
        /// </summary>
        public static readonly ManagedPropertyInfo Navigation = new ManagedPropertyInfo("owstaxIdDynamiteNavigation");

        /// <summary>
        /// The navigation text managed property name
        /// </summary>
        public static readonly ManagedPropertyInfo NavigationText = new ManagedPropertyInfo("DynamiteNavigationOWSTEXT");  
   
        #region SharePoint builtin Managed Properties

        /// <summary>
        /// List item Id
        /// </summary>
        public static readonly ManagedPropertyInfo ListItemId = new ManagedPropertyInfo("ListItemID");

        /// <summary>
        /// ContentTypeId
        /// </summary>
        public static readonly ManagedPropertyInfo ContentTypeId = new ManagedPropertyInfo("ContentTypeId");  

        
   
        #endregion
    }
}
