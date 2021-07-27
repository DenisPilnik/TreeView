using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView.Model
{
    public class Stick : ObservableObject
    {
        private string head;
        private List<string> items;

        public string Head
        {
            get{
                return head;
            }
            set{
                Set<string>(() => this.Head, ref head, value);
            }
        }

        public List<string> Items
        {
            get
            {
                return items;
            }
            set
            {
                Set<List<string>>(() => this.Items, ref items, value);
            }
        }
    }
}
