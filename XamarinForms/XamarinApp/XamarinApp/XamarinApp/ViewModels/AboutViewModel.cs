using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        
            //コマンドPerformNetworkOperation
            PerformNetworkOperation = new Command(async () =>
            {
                //indicatorを表示する。
                IsBusy = true;


                // ここにネットワーク処理を記述
                Console.WriteLine("ネットワーク処理を開始");
                await SomeNetworkOperation();

                //indicatorを非表示にする。
                IsBusy = false;
            });
        }

        public ICommand OpenWebCommand { get; }

        //コマンドPerformNetworkOperation
        public ICommand PerformNetworkOperation { get; }
        public ICommand StopNetworkOperation { get; }

        public async Task SomeNetworkOperation()
        {
            // Simulate a 3 second network operation
            await Task.Delay(3000);
        }

    }
}