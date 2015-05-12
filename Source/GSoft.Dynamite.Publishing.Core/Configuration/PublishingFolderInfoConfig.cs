using System.Collections.Generic;
using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Folders;
using GSoft.Dynamite.Pages;
using GSoft.Dynamite.Publishing.Contracts.Configuration;
using GSoft.Dynamite.Publishing.Contracts.Constants;

namespace GSoft.Dynamite.Publishing.Core.Configuration
{
    /// <summary>
    /// Configuration of the root folder hierarchies for a list or a library.
    /// Use a folder that encapsulates all items definitions instead of creating items or pages individually
    /// </summary>
    public class PublishingFolderInfoConfig : IPublishingFolderInfoConfig
    {
        private readonly IPublishingPageInfoConfig publishingPageInfoConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="PublishingFolderInfoConfig"/> class.
        /// </summary>
        /// <param name="publishingPageInfoConfig">The publishing page information configuration.</param>
        public PublishingFolderInfoConfig(IPublishingPageInfoConfig publishingPageInfoConfig)
        {
            this.publishingPageInfoConfig = publishingPageInfoConfig;
        }

        /// <summary>
        /// Property that return all the folder hierarchies to create in the publishing module
        /// </summary>
        public IList<FolderInfo> RootFolderHierarchies
        {
            get
            {
                return new List<FolderInfo>()
                {
                    this.ItemPageTemplates,
                    this.CategoryPageTemplates,
                };
            }
        }

        /// <summary>
        /// Property that return all the folder hierarchies used for home pages by language
        /// </summary>
        public IList<FolderInfo> HomePages
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
        /// Gets the item page templates.
        /// </summary>
        /// <value>
        /// The item page templates.
        /// </value>
        public FolderInfo ItemPageTemplates
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;

                folder.Pages = new List<PageInfo>()
                {
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.TargetItemPageTemplate.FileName),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName),
                };

                return folder;
            }
        }

        /// <summary>
        /// Gets the category page templates.
        /// </summary>
        /// <value>
        /// The category page templates.
        /// </value>
        public FolderInfo CategoryPageTemplates
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;

                folder.Pages = new List<PageInfo>()
                {
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogCategoryItemsPageTemplate.FileName)
                };

                return folder;
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
                var folder = PublishingFolderInfos.RootFolderEn;
                var englishHomepage = this.publishingPageInfoConfig.GetPageInfoByFileName("Home");

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
                var folder = PublishingFolderInfos.RootFolderFr;
                var frenchHomepage = this.publishingPageInfoConfig.GetPageInfoByFileName("Accueil");

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
