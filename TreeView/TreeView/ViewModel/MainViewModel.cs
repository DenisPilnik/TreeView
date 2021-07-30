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
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private ObservableCollection<Stick> stick;
        private ObservableCollection<Stick> filteredStick;

        public MainViewModel()
        {
            LoadTreeCommand = new RelayCommand(LoadTreeMethod);
        }
        
        public ICommand LoadTreeCommand { get; private set; }

        public ObservableCollection<Stick> Tree
        {
            get
            {
                if (String.IsNullOrEmpty(filter))   // Filter-dependent transmission
                {
                    return stick;
                }
                else
                {
                    return filteredStick;
                }
            }
        }

        private void LoadTreeMethod()           //Method to create and property change alert
        {
            stick = Stick.GetSticks(stick);
            RaisePropertyChanged(() => this.Tree);
        }

        private string filter;

        public string Filter
        {
            get
            {
                return this.filter;
            }
            set
            {
                this.filter = value;
                SearhTree();
            }
        }

        private void SearhTree()                //Method to find Stick with filter and property change alert
        {
            filteredStick = Stick.GetFilteredSticks(filter, stick);
            this.RaisePropertyChanged(() => this.Tree);
        }
    }
}