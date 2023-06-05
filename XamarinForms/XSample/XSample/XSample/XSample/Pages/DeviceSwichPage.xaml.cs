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
	public partial class DeviceSwichPage : ContentPage
	{
		public DeviceSwichPage ()
		{
			InitializeComponent ();

            if (Device.RuntimePlatform == Device.iOS)
            { }
            else if (Device.RuntimePlatform == Device.Android)
            {
                MyImage.Source = "a.png";
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                MyImage.Source = @"Images\a.png";
            }
        }
	}
}