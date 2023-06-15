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
	public partial class PickerPage : ContentPage
	{
		public PickerPage ()
		{
			InitializeComponent ();
		}

        private void MyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = MyPicker.Items[MyPicker.SelectedIndex];
            DisplayAlert("選択されているのは...", val, "OK");
        }
    }
}