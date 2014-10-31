using System.Collections.Generic;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationManagedNavigationInfoConfig
    {
        IList<ManagedNavigationInfo> NavigationSettings { get; }
    }
}
