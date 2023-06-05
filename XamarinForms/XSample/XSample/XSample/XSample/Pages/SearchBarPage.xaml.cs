﻿using System;
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
	public partial class SearchBarPage : ContentPage
	{
        private ObservableCollection<ProductDto> _dtos = new ObservableCollection<ProductDto>();
		public SearchBarPage ()
		{
			InitializeComponent ();

            _dtos.Add(new ProductDto(1, "ABCDE")); 
            _dtos.Add(new ProductDto(2, "AEEEEEE")); 
            _dtos.Add(new ProductDto(3, "BCCCCCF"));
            MyListView.ItemsSource = _dtos;
		}

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyListView.ItemsSource = GetDto(e.NewTextValue);
        }

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {

        }

        private IEnumerable<ProductDto> GetDto(string searchText = null)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return _dtos;
            }

            return _dtos.Where(x => x.ProductName.Contains(searchText));
        }
    }

    public sealed class ProductDto
    {
        public ProductDto(int id, string productName)
        {
            Id = id;
            ProductName = productName;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}