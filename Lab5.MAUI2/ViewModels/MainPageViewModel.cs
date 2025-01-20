using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using GalaSoft.MvvmLight.Command;
using Lab5.MAUIData.Interfaces;
using Lab5.MAUIData.Models;
using Lab5.MAUI.ViewModels;
using CommunityToolkit.Mvvm.Input;


namespace MauiApp2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataRepository _dataRepository;

        public MainPageViewModel(IDataRepository dataRepository)
        {
            Title = "Loading ...";
            _dataRepository = dataRepository;

            LoadCommand = new RelayCommand(LoadData);
            SelectStudentCommand = new RelayCommand(ShowDetails);
            
            LoadData();
       }

        public async void ShowDetails()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "Department", SelectedDepartment}
            };
            
            await Shell.Current.GoToAsync("//EmployeesPage", navigationParameter);}

        private string _title;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        private Department[] _departments;
        
        public Department[] Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value;
                OnPropertyChanged();
            }
        }
        
        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged();
            }
        }
        
        public ICommand LoadCommand { get; }
        public ICommand SelectStudentCommand { get; }
        public async void LoadData()
        {
            Title = "Loading ...";
            
            var data = await _dataRepository.GetDepartmentsAsync();
            Departments = data;
            Title = "Number of departments: " + data.Length;
        }
    }
}
