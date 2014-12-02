using GSoft.Dynamite.Design.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    /// <summary>
    /// Example of an override of the design configuration from the design module
    /// </summary>
    public class DemoDesignConfig
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
    }
}
