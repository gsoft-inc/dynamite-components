using GSoft.Dynamite.ContentTypes;
using GSoft.Dynamite.Fields;
using GSoft.Dynamite.Fields.Types;
using GSoft.Dynamite.Taxonomy;
using System.Collections.Generic;

namespace GSoft.Dynamite.Publishing.Contracts.Stories
{
    /// <summary>
    /// PUB01 configuration.
    /// </summary>
    public interface IPub01Config
    {
        ICollection<IFieldInfo> FieldInfos { get; }

        ICollection<ContentTypeInfo> ContenTypeInfos { get; }

        #region Taxonomy

        /// <summary>
        /// Gets the navigatio term group information.
        /// </summary>
        /// <value>
        /// The navigatio term group information.
        /// </value>
        TermGroupInfo NavigatioTermGroupInfo { get; }

        /// <summary>
        /// Gets the restricted term group information.
        /// </summary>
        /// <value>
        /// The restricted term group information.
        /// </value>
        TermGroupInfo RestrictedTermGroupInfo { get; }

        /// <summary>
        /// Gets the global navigation term set information.
        /// </summary>
        /// <value>
        /// The global navigation term set information.
        /// </value>
        TermSetInfo GlobalNavigationTermSetInfo { get; }

        /// <summary>
        /// Gets the restricted news term set information.
        /// </summary>
        /// <value>
        /// The restricted news term set information.
        /// </value>
        TermSetInfo RestrictedNewsTermSetInfo { get; }

        #endregion

        /// <summary>
        /// Install sequence for PUB01.
        /// </summary>
        void Install();
    }
}
