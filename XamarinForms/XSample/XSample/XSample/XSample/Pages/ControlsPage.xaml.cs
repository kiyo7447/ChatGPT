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
    public partial class ControlsPage : ContentPage
    {
        public ControlsPage()
        {
            InitializeComponent();

            var items = new List<MenuDto>();
            items.Add(new MenuDto("SwitchPage", "Switchの使い方", "mail.png"));
            items.Add(new MenuDto("SwitchBindablePage", "Switchの使い方+バインディング", "mail.png"));
            items.Add(new MenuDto("SliderPage", "Sliderの使い方", "mail.png"));
            items.Add(new MenuDto("StepperPage", "Stepperの使い方", "mail.png"));
            items.Add(new MenuDto("EntryPage", "Entryの使い方", "mail.png"));
            items.Add(new MenuDto("EditorPage", "Editorの使い方", "mail.png"));
            items.Add(new MenuDto("PickerPage", "Pickerはコンボボックスのような感じ", "mail.png"));
            items.Add(new MenuDto("PickerBindablePage", "PickerをIDで識別などのためのバインディング", "mail.png"));
            items.Add(new MenuDto("DateTimePickerPage", "DateTimePickerの使い方", "mail.png"));
            items.Add(new MenuDto("SearchBarPage", "SearchBarの使い方", "mail.png"));
            items.Add(new MenuDto("ToolbarItemPage", "ToolbarItemの使い方", "mail.png"));
            items.Add(new MenuDto("TalbeViewPage", "TalbeViewの使い方", "mail.png"));

            MyListView.ItemsSource = items;
        }

        private void MyListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MenuDto;
            if (item.Title == "SwitchPage")
            {
                Navigation.PushAsync(new SwitchPage());
            }
            else if (item.Title == "SwitchBindablePage")
            {
                Navigation.PushAsync(new SwitchBindablePage());
            }
            else if (item.Title == "SliderPage")
            {
                Navigation.PushAsync(new SliderPage());
            }
            else if (item.Title == "StepperPage")
            {
                Navigation.PushAsync(new StepperPage());
            }
            else if (item.Title == "EntryPage")
            {
                Navigation.PushAsync(new EntryPage());
            }
            else if (item.Title == "EditorPage")
            {
                Navigation.PushAsync(new EditorPage());
            }
            else if (item.Title == "PickerPage")
            {
                Navigation.PushAsync(new PickerPage());
            }
            else if (item.Title == "PickerBindablePage")
            {
                Navigation.PushAsync(new PickerBindablePage());
            }
            else if (item.Title == "DateTimePickerPage")
            {
                Navigation.PushAsync(new DateTimePickerPage());
            }
            else if (item.Title == "SearchBarPage")
            {
                Navigation.PushAsync(new SearchBarPage());
            }
            else if (item.Title == "ToolbarItemPage")
            {
                Navigation.PushAsync(new ToolbarItemPage());
            }
            else if (item.Title == "TalbeViewPage")
            {
                Navigation.PushAsync(new TalbeViewPage());
            }
        }
    }
}