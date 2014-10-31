using System.Collections.Generic;
using GSoft.Dynamite.Fields;

namespace GSoft.Dynamite.Navigation.Contracts.Configuration
{
    public interface INavigationFieldInfoConfig
    {
        /// <summary>
        /// Property that return all the base field to create
        /// </summary>
        IList<IFieldInfo> Fields { get; }
    }
}
