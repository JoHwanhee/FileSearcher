using System.ComponentModel;
using System.Runtime.CompilerServices;
using FileSearcherWindow.Annotations;
using FileSearcherWindow.Models;
using Component = FileSearchr.Composite.Component;

namespace FileSearcherWindow.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Files _files = new Files();
        public Component RootComponent => _files.Root;

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
