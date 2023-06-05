using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XSample.Objects;

namespace XSample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();

            var dtos = new List<MenuDto>();
            //dtos.Add(new MenuDto("AAAAA", "aaaaaaaaaaaaaaa", "mail.png"));
            //dtos.Add(new MenuDto("BBBB",
            //    "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccce", "mail.png"));
            dtos.Add(new MenuDto("ControlsPage", "コントロールの一覧", "mail.png"));
            dtos.Add(new MenuDto("CarouselMainPage", 
                "カルーセルページ：左右にスワイプしてページを移動する", "mail.png"));
            dtos.Add(new MenuDto("MessageBoxPage", "メッセージの表示", "mail.png"));
            dtos.Add(new MenuDto("DisplayActionSheetPage", "選択リストから選べる問い合わせ", "mail.png"));
            dtos.Add(new MenuDto("DeviceSwichPage", "デバイスごとの切り替え", "mail.png"));
            dtos.Add(new MenuDto("PageEventPage", "LoadとCloseに代わるもの", "mail.png"));
            dtos.Add(new MenuDto("NoBackButtonPage", "ナビゲーションの戻るボタンを消す", "mail.png"));
            dtos.Add(new MenuDto("ActivityIndicatorPage", "処理中にくるくるまわるやつ", "mail.png"));
            dtos.Add(new MenuDto("PullToRefreshPage", "ListViewを下に引っ張て更新", "mail.png"));
            MyListView.ItemsSource = dtos;
		}

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MenuDto;
            //DisplayAlert(item.Title, item.SubTitle, "OK");

            if (item.Title == "ControlsPage")
            {
                Navigation.PushAsync(new ControlsPage());
            }
            else if (item.Title == "CarouselMainPage")
            {
                Navigation.PushAsync(new CarouselMainPage());
            }
            else if (item.Title == "MessageBoxPage")
            {
                Navigation.PushAsync(new MessageBoxPage());
            }
            else if (item.Title == "DisplayActionSheetPage")
            {
                Navigation.PushAsync(new DisplayActionSheetPage());
            }
            else if (item.Title == "DeviceSwichPage")
            {
                Navigation.PushAsync(new DeviceSwichPage());
            }
            else if (item.Title == "PageEventPage")
            {
                Navigation.PushAsync(new PageEventPage());
            }
            else if (item.Title == "NoBackButtonPage")
            {
                Navigation.PushAsync(new NoBackButtonPage());
            }
            else if (item.Title == "ActivityIndicatorPage")
            {
                Navigation.PushAsync(new ActivityIndicatorPage());
            }
            else if (item.Title == "PullToRefreshPage")
            {
                Navigation.PushAsync(new PullToRefreshPage());
            }
        }
    }
}