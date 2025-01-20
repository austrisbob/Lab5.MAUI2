using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Services;
using MauiApp2.ViewModels;
using Newtonsoft.Json;

namespace Lab5.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel _viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }
    }

}
