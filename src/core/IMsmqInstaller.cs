using System;
using System.Threading.Tasks;

namespace System.Messaging
{
    /// <summary>
    /// Represents a class that can create MSMQ Queues.
    /// </summary>
    public interface IMsmqInstaller
    {
        /// <summary>
        /// Adds the MSMQ queues
        /// </summary>
        /// <param name="queueNames">The list of private queues to create</param>
        /// <returns>An instance of <see cref="Task"/></returns>
        Task Install(params string[] queueNames);
    }
}
