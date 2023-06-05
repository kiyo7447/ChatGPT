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
    public partial class PickerBindablePage : ContentPage
    {
        private ObservableCollection<PickerDto> _dtos = new ObservableCollection<PickerDto>();
        public PickerBindablePage()
        {
            InitializeComponent();

            _dtos.Add(new PickerDto(1, "TEL"));
            _dtos.Add(new PickerDto(2, "FAX"));
            _dtos.Add(new PickerDto(3, "Mail"));
            MyPicker.ItemsSource = _dtos;
        }

        private async void MyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = MyPicker.SelectedItem as PickerDto;
            if(item != null)
            {
                await DisplayAlert("Id", item.Id.ToString(), "OK");
                await DisplayAlert("Name", item.Name.ToString(), "OK");
            }
        }
    }

    public class PickerDto
    {
        public PickerDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}