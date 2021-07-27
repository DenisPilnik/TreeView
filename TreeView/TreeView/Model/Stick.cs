using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static ObservableCollection<Stick> GetSticks()
        {
            List<string> testt = new List<string>();
            testt.Add("1");
            testt.Add("2");
            testt.Add("3");
            ObservableCollection<Stick> stick = new ObservableCollection<Stick>();
            for (int i = 0; i < 25; ++i)
            {
                stick.Add(new Stick { 
                    Head = "Some head " + (i + 1).ToString(),
                    Items = testt
                });
            }
           return stick; 
        }
    }
}
