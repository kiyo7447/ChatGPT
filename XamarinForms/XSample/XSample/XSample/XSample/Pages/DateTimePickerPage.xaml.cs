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
	public partial class DateTimePickerPage : ContentPage
	{
		public DateTimePickerPage ()
		{
			InitializeComponent ();
		}
	}
}