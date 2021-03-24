using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" }) {}

        public override string Execute(Player p, string[] text)
        {
            string result;

            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }
            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }
            if (text.Length == 5)
            {
                if (text[3].ToLower() != "in")
                {
                    return "What do you want to look in?";
                }
            }
            if (text.Length == 3)
            {
                result = LookAtIn(text[2], p);
                if (result == "")
                {
                    return "I cannot find the " + text[2];
                }
                else
                {
                    return result;
                }
            }
            else if (text.Length == 5)
            {
                IHaveInventory contain = FetchContainer(p, text[4]);
                if (contain == null)
                {
                    return "I cannot find the " + text[4];
                }
                else
                {
                    result = LookAtIn(text[2], contain);
                    if (result == "")
                    {
                        return "Cannot locate " + text[2] + " in " + text[4];
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            else
            {
                return "I don't know how to look there";
            }
        }

        private IHaveInventory FetchContainer (Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }

        private string LookAtIn (string thingId, IHaveInventory container)
        {
            var result = container.Locate(thingId);
            if (result != null)
            {
                return result.FullDescription;
            }
            else
            {
                return "";
            }
        }
    }
}
