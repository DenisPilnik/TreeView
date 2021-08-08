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
using System.Windows;

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

        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }
        }

        public MainViewModel()
        {
            LoadTreeCommand = new RelayCommand(LoadTreeMethod);
        }
        
        public ICommand LoadTreeCommand { get; private set; }

        private async void LoadTreeMethod()           //Method to create and property change alert
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 25; i++)
                {
                    categories = Stick.createTree(categories);
                    RaisePropertyChanged(() => Categories);
                }
            });
        }

        private string filter;

        public string Filter { get => filter; set { this.filter = value; SearhTree(); } }

        private void SearhTree()
        {
            MessageBox.Show($"Praacuet message {Filter}");
        }
    }
}