using System.Collections.Generic;
using GSoft.Dynamite.Docs.Contracts.Configuration;
using GSoft.Dynamite.Docs.Contracts.Constants;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Docs.Core.Configuration
{
    public class DocsFieldInfoConfig : IDocsFieldInfoConfig
    {
        private readonly DocsFieldInfos docsFieldInfos;

        public DocsFieldInfoConfig(DocsFieldInfos docsFieldInfos)
        {
            this.docsFieldInfos = docsFieldInfos;
        }

        public IList<IFieldInfo> Fields 
        {

            get
            {
                return new List<IFieldInfo>()
                {
                    {this.docsFieldInfos.InternalId()}
                };
            }
        }
    }
}
