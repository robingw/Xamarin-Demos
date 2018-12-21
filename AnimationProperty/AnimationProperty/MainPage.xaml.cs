using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationProperty
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Refresh_Clicked(object sender, System.EventArgs e)
        {
            viewModel.Refresh();
        }
    }
}
