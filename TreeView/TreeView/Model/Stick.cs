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
        private string backColor;
        private string foreColor;
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
        public string BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                Set<string>(() => this.BackColor, ref backColor, value);
            }
        }
        public string ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                Set<string>(() => this.ForeColor, ref foreColor, value);
            }
        }
        public static ObservableCollection<Stick> GetSticks(ObservableCollection<Stick> sticks)
        {
            var rnd = new Random();
            int numOfItem = 0;
            ObservableCollection<Stick> stick = new ObservableCollection<Stick>();
            if(sticks != null)
            {
                foreach (Stick st in sticks)
                {
                    stick.Add(st);
                }
            }
            for (int i = 0; i < 25; ++i)
            {
                ObservableCollection<Stick> items = new ObservableCollection<Stick>();
                ObservableCollection<Stick> color = new ObservableCollection<Stick>();
                numOfItem = rnd.Next(1, 10);
                foreach(int num in GetRandomNum(numOfItem))
                {
                    items.Add(new Stick { Head = "• Item" + num.ToString(), ForeColor = "Black" });
                }
                stick.Add(new Stick
                {
                    Head = "Category" + (stick.Count + 1).ToString(),
                    Items = items,
                    ForeColor = "Black"
                });
            }
           return stick;
        }
        private static List<int> GetRandomNum(int ammount)
        {
            var rnd = new Random();
            int num = 0;
            List<int> randomNum = new List<int>();
            for(int i = 0; randomNum.Count != ammount; i++)
            {
                num = rnd.Next(1, 30);
                if (!randomNum.Contains(num))
                    randomNum.Add(num);
            }
            return randomNum;
        }
        public static ObservableCollection<Stick> GetFilteredSticks(string filter, ObservableCollection<Stick> stick)
        {
            if (stick == null)
                return null;
            if (String.IsNullOrEmpty(filter))
                return stick;
            ObservableCollection<Stick> filteredStick = new ObservableCollection<Stick>();
            foreach(Stick st in stick)
            {
                ObservableCollection<Stick> itemsStick = new ObservableCollection<Stick>();
                if (st.head.ToLower().Contains(filter.ToLower()))
                {
                    for (int i = 0; i < st.Items.Count; i++)
                    {
                        if (st.Items[i].Head.ToLower().Contains(filter.ToLower()))
                        {
                            itemsStick.Add(new Stick { Head = st.Items[i].Head, BackColor = "Green", ForeColor = "White" });
                        }
                        else
                        {
                            itemsStick.Add(new Stick { Head = st.Items[i].Head, BackColor = "Black", ForeColor = "White" });
                        }
                    }
                    filteredStick.Add(new Stick { Head = st.Head, BackColor = "Green", ForeColor = "White", Items = itemsStick });
                }
            }
            foreach (Stick st in stick)
            {
                ObservableCollection<Stick> items = new ObservableCollection<Stick>();
                for (int i = 0; i < st.Items.Count; i++)
                {
                    if (st.Items[i].Head.ToLower().Contains(filter.ToLower()))
                    {
                        items.Add(new Stick { Head = st.Items[i].Head, BackColor = "Green", ForeColor = "White" });
                    }
                }
                if (items.Count > 0)
                {
                    bool exist = true;
                    foreach(Stick _st in filteredStick)
                    {
                        if (_st.Head == st.Head)
                        {
                            exist = false;
                        }
                    }
                    if (exist)
                    {
                        filteredStick.Add(new Stick
                        {
                            Head = st.Head,
                            Items = items,
                            BackColor = "Black",
                            ForeColor = "White"
                        });
                    }
                }
            }
            return filteredStick;
        }
    }
}
