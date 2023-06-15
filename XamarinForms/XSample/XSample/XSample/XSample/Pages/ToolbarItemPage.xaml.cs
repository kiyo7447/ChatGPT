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
	public partial class ToolbarItemPage : ContentPage
	{
		public ToolbarItemPage ()
		{
			InitializeComponent ();
		}

        private void AAAToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private void BBBToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}