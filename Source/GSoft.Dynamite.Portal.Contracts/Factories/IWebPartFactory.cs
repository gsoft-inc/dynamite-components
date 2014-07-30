using GSoft.Dynamite.Portal.Contracts.WebParts;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Portal.Contracts.Factories
{
    /// <summary>
    /// Interface for WebPart Factory
    /// </summary>
    public interface IWebPartFactory
    {
        /// <summary>
        /// Add a web part in specified page which displays info about current navigation node
        /// </summary>
        /// <param name="listItem">the current page</param>
        /// <param name="webPartZoneName">the web part zone name</param>
        /// <param name="webPartZoneIndex">the web part zone index</param>
        void AddNodeDescriptionWebPart(SPListItem listItem, string webPartZoneName, int webPartZoneIndex);

        IContentBySearchSchedule CreateContentBySearchScheduleWebPart();

        IContextualNavigation CreateContextualNavigationWebPart();

        IChildNodes CreateChildNodesWebPart();

        IResultScriptSchedule CreateResultScriptScheduleWebPart();
    }
}
