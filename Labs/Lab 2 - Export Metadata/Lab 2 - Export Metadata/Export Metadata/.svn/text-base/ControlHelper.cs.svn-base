using System;
using System.Collections.Generic;
using System.Text;

namespace Integrations
{
    /// <summary>
    /// a class that holds a key value pair and overrides the to string methode by returning the name
    /// </summary>
    public class ControlHelper
    {
        private Guid id;

        private string name;

        public ControlHelper(string DisplayName, Guid Identfier)
        {
            Name = DisplayName;
            UniqueID = Identfier;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Guid UniqueID
        {
            get { return id; }
            set { id = value; }
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
