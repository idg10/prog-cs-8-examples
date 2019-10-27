using System;
using System.Runtime.Serialization;

namespace Exceptions.Custom.Serializable
{
    public class DeviceNotReadyException : InvalidOperationException
    {
        public DeviceNotReadyException(DeviceStatus status)
            : this("Device status must be Ready", status)
        {
        }

        public DeviceNotReadyException(string message, DeviceStatus status)
            : base(message)
        {
            Status = status;
        }

        public DeviceNotReadyException(string message, DeviceStatus status,
                                       Exception innerException)
            : base(message, innerException)
        {
            Status = status;
        }

        public DeviceStatus Status { get; }

        public override void GetObjectData(SerializationInfo info,
                                           StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Status", Status);
        }

        protected DeviceNotReadyException(SerializationInfo info,
                                          StreamingContext context)
            : base(info, context)
        {
            Status = (DeviceStatus)info.GetValue("Status", typeof(DeviceStatus));
        }
    }

    public enum DeviceStatus
    {
        Disconnected,
        Initializing,
        Failed,
        Ready
    }
}