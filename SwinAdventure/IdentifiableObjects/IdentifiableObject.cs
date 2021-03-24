using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private readonly List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (string s in idents)
            {
                _identifiers.Add(s.ToLower());
            }
        }

        public Boolean AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstID
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }

                else
                {
                    return "";
                }
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

    }
}
