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
	public partial class MessageBoxPage : ContentPage
	{
		public MessageBoxPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("AAA", "BBBBB", "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var val = await DisplayAlert("AAA", "BBBBB", "OK", "Cancel");
            await DisplayAlert("応答", val.ToString(), "OK");
        }
    }
}