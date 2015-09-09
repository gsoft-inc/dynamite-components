using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Lists.Constants;
using GSoft.Dynamite.Publishing.Contracts.Configuration;

namespace GSoft.Dynamite.Publishing.Contracts.Constants
{
    /// <summary>
    /// List definitions for the publishing module
    /// </summary>
    public static class PublishingListInfos
    {
        /// <summary>
        /// The OOTB Pages Library list
        /// </summary>
        public static ListInfo PagesLibrary
        {
            get
            {
                return new ListInfo("Pages", null, null)
                {
                    ListTemplateInfo = BuiltInListTemplates.Pages
                };
            }
        }
    }
}
