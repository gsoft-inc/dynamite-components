using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Contracts.Factories
{
    public interface IPortalPageFactory
    {
        PublishingPage CreateHomePageInstance(SPWeb web, string filename);

        PublishingPage CreateStaticContentPageTemplate(SPWeb web, string filename);

        PublishingPage CreateAllNewsPageInstance(SPWeb web, string filename);

        PublishingPage CreateNewsPageTemplate(SPWeb web, string filename);

        PublishingPage CreateNodeDescriptionPageTemplate(SPWeb web, string filename);

        PublishingPage CreateSearchResultsPageInstance(SPWeb web, string filename);
    }
}
