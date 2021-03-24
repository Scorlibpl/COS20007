using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory 
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            foreach (Item c in _items)
            {
                if (c.AreYou(id))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item c in _items)
            {
                if (c.AreYou(id))
                {
                    Item Temp = c;
                    _items.Remove(c);
                    return Temp;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item c in _items)
            {
                if (c.AreYou(id))
                {
                    return c;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string ItemOutput = "";
                foreach (Item c in _items)
                {
                    ItemOutput += "\t" + c.ShortDescription + "\n";
                }
                return ItemOutput;
            }
        }
    }
}
