using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.Contracts.Factories
{
    /// <summary>
    /// Provides the assembly and type information for SharePoint the item event receiver class
    /// that needs to be hooked up to the authoring content types.
    /// </summary>
    public interface ITranslatableItemEventReceiverAssemblyDetails
    {
        /// <summary>
        /// The full strong name of the assembly where the event receiver type is located
        /// </summary>
        string AssemblyFullName { get; }

        /// <summary>
        /// The full namespaced type name of the item event receiver type
        /// </summary>
        string EventReceiverTypeName { get; }
    }
}
