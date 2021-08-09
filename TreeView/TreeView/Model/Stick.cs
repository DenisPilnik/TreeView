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
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public static Category CreateTree(int categoriesCount)
        {
            Category category = new Category() { CategoryName = $"Category {categoriesCount + 1}", CategoryColor = "Black" };
            GetRandomNum(random.Next(1, 10)).ToList().ForEach(j => category.Items.Add(new Item() { ItemName = $"Item{j}", ItemColor = "Black" }));
            return category;
        }

        private static int[] GetRandomNum(int ammount)
        {
            return Enumerable.Range(1, 30).OrderBy(x => random.Next()).Take(ammount).ToArray();
        }

        public static Category GetCategory(Category cat, string filter)
        {
            if (String.IsNullOrEmpty(filter))
            {
                cat.Items.ToList().ForEach(i => i.ItemColor = "Black");
                return cat;
            }
            Category category = new Category();
            if (cat.CategoryName.ToLower().Contains(filter))
            {
                category.CategoryColor = "Green";
                cat.Items.ToList().ForEach(i => App.Current.Dispatcher.Invoke(delegate { category.Items.Add(i);}));
            }
            else
            {
                category.CategoryColor = "Black";
                IEnumerable<Item> filteredItems = cat.Items.Where(s => s.ItemName.ToLower().Contains(filter));
                filteredItems.ToList().ForEach(i => App.Current.Dispatcher.Invoke(delegate { category.Items.Add(i); }));
            }
            category.Items.ToList().ForEach(i => i.ItemColor = i.ItemName.ToLower().Contains(filter) ? "Green" : "Black");
            category.CategoryName = cat.CategoryName;
            return category;
        }

        public static bool ExistString(Category cat, string filter)
        {
            return cat.CategoryName.ToLower().Contains(filter) ? true : cat.Items.Any( s =>  s.ItemName.ToLower().Contains(filter));
        }
    }

    public class Category
    {
        public Category()
        {
            Items = new ObservableCollection<Item>();
        }

        private string categoryName;
        private string categoryColor;
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string CategoryColor { get => categoryColor; set => categoryColor = value; }
        public ObservableCollection<Item> Items { get; set; }
    }
    public class Item
    {
        private string itemName { get; set; }
        private string itemColor { get; set; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string ItemColor { get => itemColor; set => itemColor = value; }
    }
}
