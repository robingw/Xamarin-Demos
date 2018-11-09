using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CardViewDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            contentPage1.SetContent(contentPage1.Title);
            contentPage2.SetContent(contentPage2.Title);
            contentPage3.SetContent(contentPage3.Title);
            contentPage4.SetContent(contentPage4.Title);
        }

        protected override void OnCurrentPageChanged()
        {
            this.Title = CurrentPage.Title;
        }
    }
}