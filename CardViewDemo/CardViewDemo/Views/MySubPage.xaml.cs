using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CardViewDemo.Views
{
    public partial class MySubPage : ContentPage
    {
        public MySubPage()
        {
            InitializeComponent();

            App currentApp = (App)Application.Current;
            currentApp.MainPage.Title = Title;
        }
    }
}
