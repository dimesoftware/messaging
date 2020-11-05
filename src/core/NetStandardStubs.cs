using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Messaging
{
#if NETSTANDARD2_1

    public enum WellKnownSidType
    {
        WorldSid,
        AnonymousSid
    }

    public enum MessageQueueAccessRights
    {
        FullControl
    }

    public enum AccessControlEntryType
    {
        Set,
        Allow
    }

    public class NTAccount
    {
    }

    public class SecurityIdentifier
    {
        public SecurityIdentifier(WellKnownSidType a, string b)
        {

        }

        public TranslateResult Translate(Type type)
        {
            return new TranslateResult();
        }
    }

    public class TranslateResult
    {
        public string Value { get; set; }
    }

    public class MessageQueue : IDisposable
    {
        public MessageQueue(string path)
        {

        }

        public void SetPermissions(string who, object accessRights, object accessControlEntryType)
        {
        }

        public static bool Exists(string path) => false;

        public static MessageQueue Create(string path, bool isTransactional = false) => new MessageQueue(path);

        public void Dispose()
        {
        }
    }
#endif
}
