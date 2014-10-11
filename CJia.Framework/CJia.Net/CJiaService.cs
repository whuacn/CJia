using System;
using CJia.Net.Service;

namespace CJia.Net
{
    /// <summary>
    /// Base class for all services that is serviced by IScsServiceApplication.
    /// A class must be derived from ScsService to serve as a SCS service.
    /// </summary>
    public abstract class CJiaService
    {
        /// <summary>
        /// The current client for a thread that called service method.
        /// </summary>
        [ThreadStatic]
        private static IServiceClient _currentClient;

        /// <summary>
        /// Gets the current client which called this service method. 
        /// </summary>
        /// <remarks>
        /// This property is thread-safe, if returns correct client when 
        /// called in a service method if the method is called by SCS system,
        /// else throws exception.
        /// </remarks>
        protected internal IServiceClient CurrentClient
        {
            get
            {
                if (_currentClient == null)
                {
                    throw new Exception("Client channel can not be obtained. CurrentClient property must be called by the thread which runs the service method.");
                }

                return _currentClient;
            }

            internal set
            {
                _currentClient = value;
            }
        }
    }

    /// <summary>
    /// Any SCS Service interface class must has this attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
    public class CJiaServiceAttribute : Attribute
    {
        /// <summary>
        /// Service Version. This property can be used to indicate the code version.
        /// This value is sent to client application on an exception, so, client application can know that service version is changed.
        /// Default value: NO_VERSION.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Creates a new ScsServiceAttribute object.
        /// </summary>
        public CJiaServiceAttribute()
        {
            Version = "NO_VERSION";
        }
    }
}
