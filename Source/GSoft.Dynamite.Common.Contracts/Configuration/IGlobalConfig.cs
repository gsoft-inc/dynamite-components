using GSoft.Dynamite.Multilingualism.Contracts.Configuration;

namespace GSoft.Dynamite.Common.Contract.Configuration
{
    /// <summary>
    /// Global configuration (multilingual, URLs, etc.) interface.
    /// </summary>
    public interface IGlobalConfig
    {
        string Model { get; }

        /// <summary>
        /// Gets the field prefix.
        /// </summary>
        /// <value>
        /// The field prefix.
        /// </value>
        string FieldPrefix { get; }

        /// <summary>
        /// Gets the multilingualism variations configuration.
        /// </summary>
        /// <value>
        /// The multilingualism variations configuration.
        /// </value>
        IMultilingualismVariationsConfig MultilingualismVariationsConfig { get; }

        /// <summary>
        /// Gets the authoring host URL.
        /// </summary>
        /// <value>
        /// The authoring host URL.
        /// </value>
        string AuthoringHostUrl { get; }

        /// <summary>
        /// Gets the publishing host URL.
        /// </summary>
        /// <value>
        /// The publishing host URL.
        /// </value>
        string PublishingHostUrl { get; }

    }
}
