using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CardViewDemo.Models;

namespace CardViewDemo.ViewModels
{
    public class MyContentPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private MyContentPageModel model;

        public MyContentPageViewModel()
        {
            model = new MyContentPageModel();
        }

        public string Content
        {
            set { SetProperty(ref model.Content, value); }
            get { return model.Content; }
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
