using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter player name:");
            string name = Console.ReadLine();
            Console.WriteLine("Describe player:");
            string desc = Console.ReadLine();

            Player Player = new Player(name, desc);
            Item Sword = new Item(new string[] { "Sword" }, "Bronze Sword", 
                "A bronze age sword in the black sea");
            Item Shovel = new Item(new string[] { "Shovel" }, "Golden Shovel", 
                "A golden shovel from animal crossing");

            Player.Inventory.Put(Sword);
            Player.Inventory.Put(Shovel);

            Bag Bag = new Bag(new string[] { "Bag" }, "School Bag", 
                "My favourite school bag");

            Player.Inventory.Put(Bag);

            Item Shield = new Item(new string[] { "Shield" }, "Wooden Shield", 
                "A wooden shield from game of thrones");

            Bag.Inventory.Put(Shield);

            LookCommand Look = new LookCommand();

            string cmd = "";
            while(cmd != "quit")
            {
                Console.WriteLine("Enter Command:");
                cmd = Console.ReadLine();
                Console.WriteLine(Look.Execute(Player, cmd.Split(' ')));
            }
        }
    }
}
