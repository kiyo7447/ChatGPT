using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XSample.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PullToRefreshPage : ContentPage
	{
        private ObservableCollection<PullToRefreshDto> _dtos = new ObservableCollection<PullToRefreshDto>();
		public PullToRefreshPage ()
		{
			InitializeComponent ();

            _dtos.Add(new PullToRefreshDto(DateTime.Now.ToString()));
            MyListView.ItemsSource = _dtos;
        }

        private async void MyListView_Refreshing(object sender, EventArgs e)
        {
            await Task.Run(() => System.Threading.Thread.Sleep(3000));
            _dtos.Add(new PullToRefreshDto(DateTime.Now.ToString()));
            MyListView.EndRefresh();
        }
    }

    public class PullToRefreshDto
    {
        public PullToRefreshDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}