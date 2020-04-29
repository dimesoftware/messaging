using System.Diagnostics;
using System.Security.Principal;
using System.Threading.Tasks;

namespace System.Messaging
{
    /// <summary>
    /// Creates and protects MSMQ Queues.
    /// </summary>
    public class MsmqInstaller : IMsmqInstaller
    {
        /// <summary>
        /// Adds the MSMQ queues
        /// </summary>
        /// <param name="queueNames">The list of private queues to create</param>
        /// <returns>An instance of <see cref="Task"/></returns>
        public Task Install(params string[] queueNames)
        {
            foreach (string queue in queueNames)
            {
                try
                {
                    string path = $@"{Environment.MachineName}\private$\{{0}}";
                    MessageQueue messageQueue = CreatePrivate(path, queue);
                    QueueCreationUtils.SetDefaultPermissionsForQueue(messageQueue, WellKnownSidType.WorldSid);
                    QueueCreationUtils.SetDefaultPermissionsForQueue(messageQueue, WellKnownSidType.AnonymousSid);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Creates a private queue on the local machine if it doesn't exist yet
        /// </summary>
        /// <param name="pattern">The path leading to the queue</param>
        /// <param name="name">The name of the queue</param>
        /// <param name="isTransactional">Transactional flag</param>
        /// <returns>An instance of the (new) message queues</returns>
        public MessageQueue CreatePrivate(string pattern, string name, bool isTransactional = true)
        {
            string path = string.Format(pattern, name);
            if (MessageQueue.Exists(path))
                return new MessageQueue(path);

            using (MessageQueue queue = MessageQueue.Create(path, isTransactional))
            {
                string everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null).Translate(typeof(NTAccount)).Value;
                queue.SetPermissions(Environment.UserName, MessageQueueAccessRights.FullControl, AccessControlEntryType.Set);
                queue.SetPermissions(everyone, MessageQueueAccessRights.FullControl, AccessControlEntryType.Set);

                return queue;
            }
        }

        /// <summary>
        /// Creates a public queue on the local machine
        /// </summary>
        /// <param name="hostname">The name of the host</param>
        /// <param name="queueName">The name of the queue</param>
        /// <returns></returns>
        public MessageQueue CreatePublic(string hostname, string queueName)
        {
            string path = $@"{hostname}\{queueName}";
            if (MessageQueue.Exists(path))
                return new MessageQueue(path);

            using (MessageQueue.Create(path))
                return new MessageQueue(path);
        }
    }
}