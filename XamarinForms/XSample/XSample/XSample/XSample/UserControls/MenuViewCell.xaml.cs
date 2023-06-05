using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XSample.UserControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuViewCell : ViewCell
	{
		public MenuViewCell ()
		{
			InitializeComponent ();
		}
	}
}