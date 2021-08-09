using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TreeView.Model;

namespace TreeView.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public ObservableCollection<Category> categories = new ObservableCollection<Category>();
        public ObservableCollection<Category> filteredCategories = new ObservableCollection<Category>();

        public ObservableCollection<Category> Categories
        {
            get
            {
                return String.IsNullOrEmpty(Filter) ? categories : filteredCategories;
            }
        }

        public MainViewModel()
        {
            LoadTreeCommand = new RelayCommand(LoadTreeMethod);
            CheckSelection = new RelayCommand(Check);
        }
        
        public ICommand LoadTreeCommand { get; private set; }
        public ICommand CheckSelection { get; private set; }

        public void Check()
        {
            MessageBox.Show("pracuet");
        }

        private async void LoadTreeMethod()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    App.Current.Dispatcher.Invoke(delegate { categories.Add(Stick.CreateTree(categories.Count));});
                    RaisePropertyChanged(() => Categories);
                }
            });
        }

        private string filter;

        public string Filter { get => filter; set{ filter = value.ToLower(); SearhTree(); } }

        private async void SearhTree()
        {
            filteredCategories.Clear();
            await Task.Run(() =>
            {
                foreach(Category category in categories)
                {
                    if(Stick.ExistString(category, Filter))
                    {
                        App.Current.Dispatcher.Invoke(delegate { filteredCategories.Add(Stick.GetCategory(category, Filter)); });
                        RaisePropertyChanged(() => Categories);
                    }
                }
            });
        }
    }
}