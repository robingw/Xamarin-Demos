using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AnimationProperty.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual async Task UpdateModelAsync() { }
        protected virtual async Task ChangeIntPropertyValue(int value, [CallerMemberName] string propertyName = null) { }
        protected virtual async Task ChangeFloatPropertyValue(float value, [CallerMemberName] string propertyName = null) { }

        public void Refresh()
        {
            Task.Run(() => UpdateModelAsync());
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected bool SetAnimationIntProperty(int storage, int value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            Task.Run(async () => {
                while (!Object.Equals(storage, value))
                {
                    await ChangeIntPropertyValue(storage = (storage > value ? storage - 1 : storage + 1), propertyName);
                    OnPropertyChanged(propertyName);
                    Thread.Sleep(50);
                }
            });

            return true;
        }

        protected bool SetAnimationFloatProperty(float storage, float value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            Task.Run(async () => {
                while (!Object.Equals(Math.Round(storage, 2), Math.Round(value, 2)))
                {
                    await ChangeFloatPropertyValue(storage = (storage > value ? storage - 0.01f : storage + 0.01f), propertyName);
                    OnPropertyChanged(propertyName);
                    Thread.Sleep(50);
                }
            });

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
