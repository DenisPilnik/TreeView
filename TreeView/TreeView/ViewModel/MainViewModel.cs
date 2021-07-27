using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
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

        private ObservableCollection<Stick> stick;

        public MainViewModel()
        {
            LoadTreeCommand = new RelayCommand(LoadTreeMethod);
        }
        
        public ICommand LoadTreeCommand { get; private set; }

        public ObservableCollection<Stick> Tree
        {
            get
            {
                return stick;
            }
        }

        private void LoadTreeMethod()
        {
            stick = Stick.GetSticks();
            
            this.RaisePropertyChanged(() => this.Tree);
        }
    }
}