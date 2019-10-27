using System;

namespace Exceptions.Custom.NotSerializable
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
    }

    public enum DeviceStatus
    {
        Disconnected,
        Initializing,
        Failed,
        Ready
    }
}
