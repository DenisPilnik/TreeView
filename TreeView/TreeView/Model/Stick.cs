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
        public List<string> FormatedString { get; set; }

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
            
            for (int i = 0; i < 25; ++i)
            {
                ObservableCollection<Stick> items = new ObservableCollection<Stick>();
                numOfItem = rnd.Next(1, 10);
                for(int j = 0; j< numOfItem; j++)
                {
                    items.Add(new Stick { Head = "  • Item" + rnd.Next(1, 99).ToString() });
                }
                stick.Add(new Stick
                {
                    Head = "Category" + (i + 1).ToString(),
                    Items = items
                });
            }
           return stick;
        }

        public static ObservableCollection<Stick> GetFormatedStick(ObservableCollection<Stick> stick)
        {
            if (stick == null)
                return null;
            ObservableCollection<Stick> formatedStik = new ObservableCollection<Stick>();
            foreach(Stick st in stick)
            {
                formatedStik.Add(new Stick { Head = st.Head });
                for (int i = 0; i < st.Items.Count; i++)
                {
                    formatedStik.Add(new Stick { Head = st.Items[i].Head});
                }
            }
            return formatedStik;
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
            if(filteredStick.Count == 0)
            {
                foreach (Stick st in stick)
                {
                    ObservableCollection<Stick> items = new ObservableCollection<Stick>();
                    for (int i = 0; i < st.Items.Count; i++)
                    {
                        if (st.Items[i].Head.ToLower().Contains(filter.ToLower()))
                        {
                            items.Add(new Stick { Head = st.Items[i].Head });
                        }
                    }
                    if(items.Count > 0)
                    {
                        filteredStick.Add(new Stick
                        {
                            Head = st.Head,
                            Items = items
                        });
                    }                   
                }
            }
            return filteredStick;
        }
    }
}
