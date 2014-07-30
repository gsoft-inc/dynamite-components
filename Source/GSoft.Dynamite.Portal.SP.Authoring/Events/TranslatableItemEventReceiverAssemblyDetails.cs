using GSoft.Dynamite.Portal.Contracts.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.Dynamite.Portal.SP.Authoring.Events
{
    /// <summary>
    /// Provides the type information for the TranslatableItemEventReceiver
    /// </summary>
    public class TranslatableItemEventReceiverAssemblyDetails : ITranslatableItemEventReceiverAssemblyDetails
    {
        /// <summary>
        /// The full strong name of the assembly where the event receiver type is located
        /// </summary>
        public string AssemblyFullName
        {
            get 
            {
                return Assembly.GetExecutingAssembly().FullName;
            }
        }

        /// <summary>
        /// The full namespaced type name of the item event receiver type
        /// </summary>
        public string EventReceiverTypeName
        {
            get 
            { 
                return typeof(TranslatableItemEventReceiver).FullName; 
            }
        }
    }
}
