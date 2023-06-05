using App2019.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2019
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
