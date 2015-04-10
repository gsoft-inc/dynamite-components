using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Folders;
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
        /// Default constructor
        /// </summary>
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
                    this.CategoryPageTemplates
                };
            }
        }

        public FolderInfo ItemPageTemplates
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;
                folder.Subfolders = new[]
                {
                    this.FolderTest
                };
                folder.Pages = new[]
                {
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.TargetItemPageTemplate.FileName),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName),
                };

                return folder;
            }
        }

        public FolderInfo CategoryPageTemplates
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;
                folder.Subfolders = new[]
                {
                    this.FolderTest
                };
                folder.Pages = new[]
                {
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogCategoryItemsPageTemplate.FileName)
                };

                return folder;
            }
        }

        public FolderInfo FolderTest
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;
                folder.Subfolders = new[]
                {
                    this.FolderTest2
                };

                return folder;
            }
        }

        public FolderInfo FolderTest2
        {
            get
            {
                var folder = PublishingFolderInfos.ItemPageTemplates;
                folder.Pages = new[]
                {
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.TargetItemPageTemplate.FileName),
                    this.publishingPageInfoConfig.GetPageInfoByFileName(PublishingPageInfos.CatalogItemPageTemplate.FileName)
                };

                return folder;
            }            
        }
    }
}
