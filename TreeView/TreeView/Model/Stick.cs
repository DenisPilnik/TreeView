using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreeView.Model
{
    public class Stick : ObservableObject
    {
        private string head;
        private ObservableCollection<Stick> items;

        public string Head
        {
            get{
                return head;
            }
            set{
                Set<string>(() => this.Head, ref head, value);
            }
        }
        public ObservableCollection<Stick> Items
        {
            get
            {
                return items;
            }
            set
            {
                Set<ObservableCollection<Stick>>(() => this.Items, ref items, value);
            }
        }
        public static ObservableCollection<Stick> GetSticks()
        {
            var rnd = new Random();
            int numOfItem = 0;
            ObservableCollection<Stick> stick = new ObservableCollection<Stick>();
            ObservableCollection<Stick> items = new ObservableCollection<Stick>();
            for (int i = 0; i < 25; ++i)
            {
                numOfItem = rnd.Next(1, 10);
                for(int j = 0; j< numOfItem; j++)
                {
                    items.Add(new Stick { Head = "Item" + rnd.Next(1, 99).ToString() });
                }
                stick.Add(new Stick
                {
                    Head = "Category" + (i + 1).ToString(),
                    Items = items
                });
                items.Clear();
            }
           return stick;
        }

        public static ObservableCollection<Stick> GetFilteredSticks(string filter, ObservableCollection<Stick> stick)
        {
            if (stick == null)
                return null;
            ObservableCollection<Stick> filteredStick = new ObservableCollection<Stick>();
            foreach(Stick st in stick)
            {
                if (st.head.ToLower().Contains(filter.ToLower()))
                {
                    filteredStick.Add(st);
                }
            }
            return filteredStick;
        }
    }
}
