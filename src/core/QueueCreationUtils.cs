using System.Security.Principal;

namespace System.Messaging
{
    public static class QueueCreationUtils
    {
        public static void SetDefaultPermissionsForQueue(MessageQueue queue, WellKnownSidType sid)
        {
            const AccessControlEntryType allow = AccessControlEntryType.Allow;
            queue.SetPermissions(GetGroupName(sid), MessageQueueAccessRights.FullControl, allow);
            queue.SetPermissions(GetGroupName(sid), MessageQueueAccessRights.FullControl, allow);
            queue.SetPermissions(GetGroupName(sid), MessageQueueAccessRights.FullControl, allow);
        }

        private static string GetGroupName(WellKnownSidType wellKnownSidType)
            => new SecurityIdentifier(wellKnownSidType, null).Translate(typeof(NTAccount)).ToString();
    }
}