using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TreeView.Model
{
    public static class Stick
    {
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public static Category CreateTree(int categoriesCount)
        {
            Category category = new Category() { CategoryName = $"Category {categoriesCount + 1}", CategoryExist = false };
            GetRandomNum(random.Next(1, 10)).ToList().ForEach(j => category.Items.Add(new Item() { ItemName = $"Item{j}", ItemExist = false }));
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
                cat.Items.ToList().ForEach(i => i.ItemExist = false);
                return cat;
            }
            Category category = new Category();
            if (cat.CategoryName.ToLower().Contains(filter))
            {
                category.CategoryExist = true;
                cat.Items.ToList().ForEach(i => App.Current.Dispatcher.Invoke(delegate { category.Items.Add(i); }));
            }
            else
            {
                category.CategoryExist = false;
                IEnumerable<Item> filteredItems = cat.Items.Where(s => s.ItemName.ToLower().Contains(filter));
                filteredItems.ToList().ForEach(i => App.Current.Dispatcher.Invoke(delegate { category.Items.Add(i); }));
            }
            category.Items.ToList().ForEach(i => i.ItemExist = i.ItemName.ToLower().Contains(filter));
            category.CategoryName = cat.CategoryName;
            return category;
        }

        public static bool ExistString(Category cat, string filter)
        {
            return cat.CategoryName.ToLower().Contains(filter) ? true : cat.Items.Any(s => s.ItemName.ToLower().Contains(filter));
        }
    }

    public class Category
    {
        public Category()
        {
            Items = new ObservableCollection<Item>();
        }

        private string categoryName;
        private bool categoryExist;
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public bool CategoryExist { get => categoryExist; set => categoryExist = value; }
        public ObservableCollection<Item> Items { get; set; }
    }
    public class Item
    {
        private string itemName { get; set; }
        private bool itemExist { get; set; }
        public string ItemName { get => itemName; set => itemName = value; }
        public bool ItemExist { get => itemExist; set => itemExist = value; }
    }
}
