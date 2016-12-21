using System;
using System.Collections.Generic;
using System.Text;

namespace Integrations
{
    /// <summary>
    /// a class that holds a key value pair and overrides the to string methode by returning the name
    /// </summary>
    public class ControlWrapper
    {
        public ControlWrapper(string DisplayName, Guid Identfier)
        {
            Name = DisplayName;
            UniqueID = Identfier;
        }

        public string Name { get; set; }

        public Guid UniqueID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
