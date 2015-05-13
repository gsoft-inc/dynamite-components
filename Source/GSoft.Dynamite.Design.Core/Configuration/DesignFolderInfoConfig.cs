using System.Collections.Generic;
using GSoft.Dynamite.Design.Contracts.Configuration;
using GSoft.Dynamite.Design.Contracts.Constants;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Pages;

namespace GSoft.Dynamite.Design.Core.Configuration
{
    /// <summary>
    /// Configuration of the root folder hierarchies for a list or a library.
    /// Use a folder that encapsulates all items definitions instead of creating items or pages individually
    /// </summary>
    public class DesignFolderInfoConfig : IDesignFolderInfoConfig
    {
        private readonly IDesignPageInfoConfig designPageInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesignFolderInfoConfig"/> class.
        /// </summary>
        /// <param name="designPageInfoConfig">The design page information configuration.</param>
        public DesignFolderInfoConfig(IDesignPageInfoConfig designPageInfoConfig)
        {
            this.designPageInfoConfig = designPageInfoConfig;
        }

        /// <summary>
        /// Property that return all the folder hierarchies to create in the design module
        /// </summary>
        public IList<FolderInfo> RootFolderHierarchies
        {
            get
            {
                return new List<FolderInfo>()
                {
                    this.RootFolderFr,
                    this.RootFolderEn
                };
            }
        }

        /// <summary>
        /// The English folder
        /// </summary>
        /// <returns>A Root FolderInfo for the english language</returns>
        private FolderInfo RootFolderEn
        {
            get
            {
                var folder = DesignFolderInfos.RootFolderEn;
                var englishHomepage = this.designPageInfoConfig.GetPageInfoByFileName("Home");

                folder.Pages = new List<PageInfo>()
                {
                    englishHomepage,
                };
                folder.WelcomePage = englishHomepage;
                folder.Locale = Language.English.Culture;

                return folder;
            }
        }

        /// <summary>
        /// The French folder
        /// </summary>
        /// <returns>A Root FolderInfo for the french language</returns>
        private FolderInfo RootFolderFr
        {
            get
            {
                var folder = DesignFolderInfos.RootFolderFr;
                var frenchHomepage = this.designPageInfoConfig.GetPageInfoByFileName("Accueil");

                folder.Pages = new List<PageInfo>()
                {
                    frenchHomepage,
                };
                folder.WelcomePage = frenchHomepage;
                folder.Locale = Language.French.Culture;

                return folder;
            }
        }
    }
}
