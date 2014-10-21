using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Design.Contracts.Configuration;

namespace Dynamite.Demo.Intranet.Core.Configuration
{
    public class DemoDesignConfig
    {
        private IDesignConfig designConfig;

        /// <summary>
        /// Override of design config
        /// </summary>
        /// <param name="designConfig"></param>
        public DemoDesignConfig(IDesignConfig designConfig)
        {
            this.designConfig = designConfig;
        }
    }
}
