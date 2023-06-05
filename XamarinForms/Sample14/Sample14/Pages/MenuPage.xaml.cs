using App2.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class MenuPage : ContentPage
  {
    public MenuPage()
    {
      InitializeComponent();

      var items = new List<MenuDto>();
      items.Add(new MenuDto(
          "AAA",
          "aaaaaaaaaaaa",
          "mail.png"));
      items.Add(new MenuDto(
          "BBB",
          "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccce!",
          "mail.png"));
      MyListView.ItemsSource = items;
    }

    private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      var item = e.Item as MenuDto;
      DisplayAlert(item.Title, item.SubTitle, "OK");
    }

  }
}