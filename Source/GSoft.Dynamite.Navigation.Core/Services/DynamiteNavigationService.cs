using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.Dynamite.Navigation.Contracts.Services;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Publishing.Navigation;
using Microsoft.SharePoint.Utilities;

namespace GSoft.Dynamite.Navigation.Core.Services
{
    public class DynamiteNavigationService : IDynamiteNavigationService
    {
        private readonly INavigationService navigationService;

        public DynamiteNavigationService(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public IList<INavigationNode> GetMenuNodes(SPWeb web, NavigationManagedProperties properties, int max)
        {
            var nodes = this.navigationService.GetAllNavigationNodes(SPContext.Current.Web, properties);
            return null;
        }
    }
}
