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
	public partial class TalbeViewPage : ContentPage
	{
		public TalbeViewPage ()
		{
			InitializeComponent ();
		}

        private void EntryCell_Completed(object sender, EventArgs e)
        {

        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {

        }
    }
}