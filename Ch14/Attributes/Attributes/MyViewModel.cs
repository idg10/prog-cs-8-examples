namespace Attributes
{
    public class MyViewModel : NotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
    }
}