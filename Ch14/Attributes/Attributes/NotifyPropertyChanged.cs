using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Attributes
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(
           ref T field,
           T value,
            [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, value))
            {
                return false;
            }

            field = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }

    // This interface is defined by .NET. The book shows it for illustration purposes, but
    // we don't want to define our own version, hence the #if false
#if false
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
#endif
}