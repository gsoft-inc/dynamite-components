using System;
using System.Collections.Generic;
using System.Linq;
using GSoft.Dynamite.Common.Contracts.Configuration;
using GSoft.Dynamite.Common.Contracts.Constants;
using GSoft.Dynamite.Configuration;
using GSoft.Dynamite.Logging;
using GSoft.Dynamite.Sites;
using GSoft.Dynamite.Taxonomy;

namespace GSoft.Dynamite.Common.Core.Configuration
{
    /// <summary>
    /// Common configuration for taxonomy in components.
    /// </summary>
    public class CommonTaxonomyConfig : ICommonTaxonomyConfig
    {
        /// <summary>
        /// Creates a new instance of <see cref="CommonTaxonomyConfig"/>
        /// </summary>
        /// <param name="siteContext">Minimal information about the current ambient web</param>
        public CommonTaxonomyConfig(ISiteCollectionContext siteContext)
        {
            this.TermStoreInfo = siteContext.ContextTermStore;
        }

        /// <summary>
        /// Current term store. Usually determined through the DefaultSiteCollectionTermStore, which depends on
        /// you having setup your Managed Metadata Service Connection's properties to set it as the 'Default storage
        /// location for column specific term sets'. Alternatively, if you need to support many term stores in your
        /// farm, you can always initialize the root web's property bag with a value for the key 'TermStoreName' - 
        /// that specific term store will then be used.
        /// </summary>
        public TermStoreInfo TermStoreInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the term group information.
        /// </summary>
        /// <value>
        /// The term group information.
        /// </value>
        public IList<TermGroupInfo> TermGroupInfos
        {
            get
            {
                var termGroups = new List<TermGroupInfo>
                {
                    CommonTermGroupInfo.Navigation, 
                    CommonTermGroupInfo.Restricted,
                    CommonTermGroupInfo.Keywords
                };

                // Hook up the ambient default term store to each group (determined through ISiteCollectionContext)
                termGroups.ForEach(tg => tg.TermStore = this.TermStoreInfo);
                return termGroups;
            }
        }

        /// <summary>
        /// Gets the term set information.
        /// NOTE: The first term
        /// </summary>
        /// <value>
        /// The term set information.
        /// </value>
        public IList<TermSetInfo> TermSetInfos
        {
            get
            {
                var navTermGroup = this.GetTermGroupInfoById(CommonTermGroupInfo.Navigation.Id);

                var navEn = CommonTermSetInfo.EnglishNavigation;
                navEn.Group = navTermGroup;
                var navFr = CommonTermSetInfo.FrenchNavigation;
                navFr.Group = navTermGroup;
                var navCtrls = CommonTermSetInfo.NavigationControls;
                navCtrls.Group = navTermGroup;

                return new List<TermSetInfo>
                {
                    navEn,
                    navFr,
                    navCtrls
                };
            }
        }

        /// <summary>
        /// Default TermSet to bind the Navigation Taxonomy field.
        /// </summary>
        public TermSetInfo DefaultNavigationTermSet
        {
            get
            {
                return this.GetTermSetInfoById(CommonTermSetInfo.EnglishNavigation.Id);
            }
        }

        /// <summary>
        /// Gets the term group information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The unique identifier of the term group.</param>
        /// <returns>
        /// The term group information
        /// </returns>
        public TermGroupInfo GetTermGroupInfoById(Guid id)
        {
            return this.TermGroupInfos.Single(termGroup => termGroup.Id.Equals(id));
        }

        /// <summary>
        /// Gets the term set information by identifier from this configuration.
        /// </summary>
        /// <param name="id">The identifier of the term set.</param>
        /// <returns>
        /// The term set information
        /// </returns>
        public TermSetInfo GetTermSetInfoById(Guid id)
        {
            return this.TermSetInfos.Single(termSet => termSet.Id.Equals(id));
        }
    }
}
