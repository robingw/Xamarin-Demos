using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CardViewDemo.Views
{
    public partial class MyContentPage : ContentPage
    {
        public MyContentPage()
        {
            InitializeComponent();
        }

        public void SetContent(string content)
        {
            viewModel.Content = content;
        }

        void TurnToSubPage(object sender, EventArgs e)
        {
            App currentApp = (App)Application.Current;
            currentApp.navigationPage.PushAsync(new MySubPage());
        }
    }
}
