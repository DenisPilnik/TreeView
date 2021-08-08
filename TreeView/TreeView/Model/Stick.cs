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
    public static class Stick
    {
        public static ObservableCollection<Category> createTree(ObservableCollection<Category> categories)
        {
            ObservableCollection<Category> category = new ObservableCollection<Category>();
            category = categories;
            int numOfItem;
            var random = new Random((int)DateTime.Now.Ticks);
            Category categoryCount = new Category() { categoryName = $"Category {category.Count + 1}", categoryColor = "Black" };
            numOfItem = random.Next(1, 10);
            foreach (int j in GetRandomNum(numOfItem))
            {
                categoryCount.Items.Add(new Item() { itemName = $"Item{j}", itemColor = "Black" });
            }
            App.Current.Dispatcher.Invoke((Action)delegate
            {
                category.Add(categoryCount);
            });
            return category;
        }

        private static int[] GetRandomNum(int ammount)
        {
            /*
             *  Method to Generate pseudo-random items
             */
            var rnd = new Random((int)DateTime.Now.Ticks);
            int num = 0;
            int[] randomNum = new int[ammount];
            for (int i = 0; i < ammount; i++)
            {
                num = rnd.Next(1, 30);
                if (!randomNum.Contains(num))
                    randomNum[i] = num;
                else
                    i--;
            }
            return randomNum;
        }
    }

    public class Category
    {
        public Category()
        {
            Items = new ObservableCollection<Item>();
        }

        public string categoryName { get; set; }
        public string categoryColor { get; set; }
        public ObservableCollection<Item> Items { get; set; }
    }
    public class Item
    {
        public string itemName { get; set; }
        public string itemColor { get; set; }
    }
}
