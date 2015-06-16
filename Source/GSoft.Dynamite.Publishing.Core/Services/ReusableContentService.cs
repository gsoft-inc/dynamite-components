using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using GSoft.Dynamite.Publishing.Contracts.Repositories;
using GSoft.Dynamite.Publishing.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Publishing.Core.Services
{
    /// <summary>
    /// The reusable content service class.
    /// </summary>
    [Obsolete]
    public class ReusableContentService : IReusableContentService
    {
        /// <summary>
        /// The reusable content repository.
        /// </summary>
        private readonly IReusableContentRepository repository;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReusableContentService" /> class.
        /// </summary>
        /// <param name="logger">The Logger</param>
        /// <param name="reusableContentRepository">The reusable content repository.</param>
        public ReusableContentService(ILogger logger, IReusableContentRepository reusableContentRepository)
        {
            this.logger = logger;
            this.repository = reusableContentRepository;
        }

        /// <summary>
        /// Creates the Reusable content.
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="name">The name of the reusable content</param>
        /// <param name="category">The category name</param>
        /// <param name="folderInLayouts">The folder in Layouts ex: "Client.Project/Html"</param>
        /// <param name="overwrite">Overwrite the existing reusable content</param>
        public void CreateReusableContent(SPWeb web, string name, string category, string folderInLayouts, bool overwrite)
        {
            var reusableContent = this.ParseReusableContent(web, name, category, folderInLayouts);
            if (reusableContent == null)
            {
                this.logger.Error("Unable to reusable content because it is null.");
                return;
            }

            var existingItem = this.repository.GetByTitle(web, reusableContent.Title);

            // Delete if overwrite and exist
            if (overwrite && existingItem != null)
            {
                this.repository.Delete(web, existingItem);
                existingItem = null;
            }

            // (Re)create the reusable content
            if (existingItem == null)
            {
                this.repository.Create(web, reusableContent);
                this.logger.Info("Created reusable content with name '{0}'.", reusableContent.Title);
            }
            else
            {
                this.logger.Warn("The reusable content with name '{0}' already exists.", reusableContent.Title);
            }
        }

        /// <summary>
        /// The <c>ReusableHtmlContent</c> by Title.
        /// </summary>
        /// <param name="web">The current web</param>
        /// <param name="reusableContentTitle">The reusable content title</param>
        /// <returns>The reusable content </returns>
        public ReusableHtmlContent GetByTitle(SPWeb web, string reusableContentTitle)
        {
            return this.repository.GetByTitle(web, reusableContentTitle);
        }

        /// <summary>
        /// Gets the reusable contents.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns>A list of reusable content</returns>
        public IList<ReusableHtmlContent> GetReusableContents(SPWeb web)
        {
            return this.repository.GetAll(web);
        }

        private ReusableHtmlContent ParseReusableContent(SPWeb web, string name, string category, string folderInLayouts)
        {
            var contents = string.Empty;

            string pathLayout = SPUtility.GetVersionedGenericSetupPath(string.Format(CultureInfo.InvariantCulture, @"TEMPLATE\LAYOUTS\{0}\{1}.html", folderInLayouts, name), 15);

            if (string.IsNullOrEmpty(pathLayout) || !File.Exists(pathLayout))
            {
                this.logger.Error("Unable to locate file at path '{0}' for reusable content.", pathLayout);
            }
            else
            {
                try
                {
                    using (var fileStream = new FileStream(pathLayout, FileMode.Open, FileAccess.Read))
                    {
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            contents = streamReader.ReadToEnd();
                        }
                    }
                }
                catch (FileNotFoundException ex)
                {
                    this.logger.Error("Unable to get the contents of the file at path '{0}' for reusable content. Error: {1}", folderInLayouts, ex);
                }
                catch (SecurityException ex)
                {
                    this.logger.Error("Unable to get the contents of the file at path '{0}' for reusable content. Error: {1}", folderInLayouts, ex);
                }
                catch (DirectoryNotFoundException ex)
                {
                    this.logger.Error("Unable to get the contents of the file at path '{0}' for reusable content. Error: {1}", folderInLayouts, ex);
                }
            }

            return new ReusableHtmlContent()
            {
                Title = name,
                Content = contents,
                Category = category
            };
        }
    }
}
