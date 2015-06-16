using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Binding;
using GSoft.Dynamite.Caml;
using GSoft.Dynamite.Fields.Constants;
using GSoft.Dynamite.Lists;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Publishing.Contracts.Entities;
using GSoft.Dynamite.Publishing.Contracts.Repositories;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Publishing.Core.Repositories
{
    /// <summary>
    /// The Repository to make transaction with Reusable Content list and item
    /// </summary>
    [Obsolete]
    public class ReusableContentRepository : IReusableContentRepository
    {
        private readonly string ReusableHTML = "ReusableHtml";
        private readonly string ReusableContentListName = "ReusableContent";

        private readonly ICamlBuilder camlBuilder;
        private readonly ISharePointEntityBinder binder;
        private readonly IListLocator listLocator;
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReusableContentRepository" /> class.
        /// </summary>
        /// <param name="camlBuilder">The CAML builder</param>
        /// <param name="entityBinder">The entity binder.</param>
        /// <param name="listLocator">List locator utility</param>
        /// <param name="logger">The logger.</param>
        public ReusableContentRepository(ICamlBuilder camlBuilder, ISharePointEntityBinder entityBinder, IListLocator listLocator, ILogger logger)
        {
            this.camlBuilder = camlBuilder;
            this.binder = entityBinder;
            this.listLocator = listLocator;
            this.logger = logger;
        }

        /// <summary>
        /// Gets the reusable content by title.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="reusableContentTitle">The reusable content title.</param>
        /// <returns>The reusable content</returns>
        public ReusableHtmlContent GetByTitle(SPWeb web, string reusableContentTitle)
        {
            var cultureSufix = CultureInfo.CurrentUICulture.LCID == Language.English.Culture.LCID ? "_EN" : "_FR";
            var listItem = this.GetListItemByTitle(web, reusableContentTitle);

            if (listItem == null)
            {
                listItem = this.GetListItemByTitle(web, reusableContentTitle + cultureSufix);
            }

            if (listItem != null)
            {
                // Bind the properties and return a ReusableContent
                return new ReusableHtmlContent()
                {
                    Title = listItem.Title,
                    Content = (listItem[this.ReusableHTML] ?? string.Empty).ToString()
                };
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <returns>The list of reusable content</returns>
        public IList<ReusableHtmlContent> GetAll(SPWeb web)
        {
            var list = this.listLocator.GetByUrl(web.Site.RootWeb, this.ReusableContentListName);

            var itemCollection = list.Items;

            if (itemCollection.Count > 0)
            {
                return itemCollection.Cast<SPListItem>().Select(item => new ReusableHtmlContent()
                {
                    Title = item.Title,
                    Content = (item[this.ReusableHTML] ?? string.Empty).ToString()
                }).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>The reusable content</returns>
        /// <exception cref="System.NotImplementedException">Not implemented exception</exception>
        public ReusableHtmlContent GetById(SPWeb web, int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the specified web.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="entity">The entity.</param>
        public void Create(SPWeb web, ReusableHtmlContent entity)
        {
            SPList list = this.listLocator.GetByUrl(web.Site.RootWeb, this.ReusableContentListName);
            this.EnsureContentCategory(entity.Category, web);

            var newItem = list.AddItem();

            this.binder.FromEntity((ReusableHtmlContent)entity, newItem);

            newItem.Update();

            // Entity was just created, assign it its new ID
            entity.Id = newItem.ID;
        }

        /// <summary>
        /// Updates the specified web.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException">Not implemented exception</exception>
        public void Update(SPWeb web, ReusableHtmlContent entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Publishes the specified web.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="comment">The comment.</param>
        /// <exception cref="System.NotImplementedException">Not implemented exception</exception>
        public void Publish(SPWeb web, ReusableHtmlContent entity, string comment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Approves the specified web.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="comment">The comment.</param>
        /// <exception cref="System.NotImplementedException">Not implemented exception</exception>
        public void Approve(SPWeb web, ReusableHtmlContent entity, string comment)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified web.
        /// </summary>
        /// <param name="web">The web.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException">Not implemented exception</exception>
        public void Delete(SPWeb web, ReusableHtmlContent entity)
        {
            SPList list = this.listLocator.GetByUrl(web.Site.RootWeb, this.ReusableContentListName);

            var item = this.GetListItemByTitle(web, entity.Title);

            if (item != null)
            {
                item.Delete();
                list.Update();
            }
        }

        /// <summary>
        /// Ensures the Content Category
        /// </summary>
        /// <param name="category">The content category name</param>
        /// <param name="web">The current web.</param>
        private void EnsureContentCategory(string category, SPWeb web)
        {
            var library = this.listLocator.GetByUrl(web.Site.RootWeb, this.ReusableContentListName);

            SPFieldChoice field = null;
            try
            {
                field = library.Fields.GetFieldByInternalName("ContentCategory") as SPFieldChoice;
            }
            catch (ArgumentException ex)
            {
                this.logger.Error("Unable to find the field with internal name 'ContentCategory' on list '{0}'. Error: {1}", library.RootFolder.Url, ex);
            }

            if (field != null)
            {
                if (!field.Choices.Contains(category))
                {
                    field.Choices.Add(category);
                    field.Update();
                }
            }
        }

        private SPListItem GetListItemByTitle(SPWeb web, string reusableContentTitle)
        {
            var list = this.listLocator.GetByUrl(web.Site.RootWeb, this.ReusableContentListName);

            var query = new SPQuery();

            query.Query = this.camlBuilder.Where(this.camlBuilder.Equal(this.camlBuilder.FieldRef(BuiltInFields.TitleName), this.camlBuilder.Value(reusableContentTitle)));
            var itemCollection = list.GetItems(query);

            SPListItem item = null;
            if (itemCollection.Count > 0)
            {
                item = itemCollection[0];
            }

            return item;
        }
    }
}
