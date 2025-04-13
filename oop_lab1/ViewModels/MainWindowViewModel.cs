using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace avalonia_demo8.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private bool _isPaneOpen = true;

        [ObservableProperty]
        private ViewModelBase _currentPage = new HomePageViewModel();

        [ObservableProperty]
        private ListItemTemplate _SelectedListItem;

        partial void OnSelectedListItemChanged(ListItemTemplate? value)
        {
            if (value is null) return;
            var instance = Activator.CreateInstance(value.ModelType);
            if (instance == null) return;
            CurrentPage = (ViewModelBase)instance;
        }

        public ObservableCollection<ListItemTemplate> Items { get; } = new()
        {
            new ListItemTemplate(typeof(HomePageViewModel), "home_regular"),
            new ListItemTemplate(typeof(Task1PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task2PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task3PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task4PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task5PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task6PageViewModel), "people_team_regular"),
            new ListItemTemplate(typeof(Task7PageViewModel), "people_team_regular")
        };

        [RelayCommand]
        private void OpenPane()
        {
            IsPaneOpen = !IsPaneOpen;
        }
    }

    public class ListItemTemplate
    {
        public string Label { get; }
        public Type ModelType { get; }
        public StreamGeometry ListItemIcon { get; }
        public ListItemTemplate(Type type, string IconKey)
        {
            ModelType = type;
            Label = type.Name.Replace("PageViewModel", "");

            Application.Current.TryFindResource(IconKey, out var resource);
            ListItemIcon = (StreamGeometry)resource;
        }
    }


}


