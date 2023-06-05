using App2.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
  public partial class MainPage : MasterDetailPage
  {
    public MainPage()
    {
      InitializeComponent();

      this.Detail = new NavigationPage(new MenuPage());
    }
  }
}
