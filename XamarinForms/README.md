

# アプリの説明
* XamarinApp  
自作アプリ（役に立たない。）
* App2  
役に立たない空のサンプル
* App2019  
役に立たない空のサンプル
* XSample  
Udemyの各種サンプル集（レベルは低い）
* Sample14  
XSampleのリソース

# Activity Indicator
```XAML
        <!-- Semi-transparent dark overlay -->
        <BoxView Grid.RowSpan="2" x:Name="overlay" IsVisible="{Binding IsBusy}" Color="#33000000"
                 HorizontalOptions="FillAndExpand" 
                 VerticalOptions="FillAndExpand" />

        <!-- Activity Indicator -->
        <ActivityIndicator Grid.RowSpan="2" x:Name="indicator" IsRunning="{Binding IsBusy}" 
                           IsVisible="{Binding IsBusy}"
                           HorizontalOptions="CenterAndExpand" 
                           VerticalOptions="CenterAndExpand" />



```

```C#
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

```
