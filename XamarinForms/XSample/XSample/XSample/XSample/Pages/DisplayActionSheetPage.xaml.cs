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
	public partial class DisplayActionSheetPage : ContentPage
	{
		public DisplayActionSheetPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var val = await DisplayActionSheet("T1", "B1", "B2", "H1", "H2", "H3");
            await DisplayAlert("選択", val, "OK");
        }
    }
}