using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace WebShell
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            webView.On<Android>().SetMixedContentMode(MixedContentHandling.AlwaysAllow);
        }
    }
}
