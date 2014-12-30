using GSoft.Dynamite.Design.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Example of an override of the design configuration from the design module
    /// </summary>
    public class DemoDesignConfig : IDesignConfig
    {
        private IDesignConfig designConfig;

        /// <summary>
        /// Override of design config
        /// </summary>
        /// <param name="designConfig">The design configuration from the design module</param>
        public DemoDesignConfig(IDesignConfig designConfig)
        {
            this.designConfig = designConfig;
        }

        public string MasterPageHTMLFilename
        {
            get { return this.designConfig.MasterPageHTMLFilename; }
        }

        public string MasterPageMASTERFilename
        {
            get { return this.designConfig.MasterPageMASTERFilename; }
        }

        public string LogoUrl
        {
            get { return this.designConfig.LogoUrl; }
        }

        public string LogoUrlDescription
        {
            get { return this.designConfig.LogoUrlDescription; }
        }

        public string SPColorUrl
        {
            get { return this.designConfig.SPColorUrl; }
        }

        public string SPFontUrl
        {
            get { return this.designConfig.SPFontUrl; }
        }
    }
}
