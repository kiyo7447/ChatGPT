using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEventPage : ContentPage
    {
        public PageEventPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            await DisplayAlert("ContentPage_Appearing", "起動時", "OK");
        }

        private async void ContentPage_Disappearing(object sender, EventArgs e)
        {
            await DisplayAlert("ContentPage_Disappearing", "終了時", "OK");
        }
    }
}