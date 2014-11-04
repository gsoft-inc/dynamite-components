using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;

namespace GSoft.Dynamite.Navigation.Contracts.Services
{
    public interface IDynamiteNavigationService
    {
        IList<INavigationNode> GetMenuNodes(SPWeb web, NavigationManagedProperties properties, int max);
    }
}
