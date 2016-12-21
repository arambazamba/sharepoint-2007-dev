using System;
using System.Collections.Generic;
using System.Text;

namespace Integrations
{
    public class DropDownHelper <T>
    {
        private string display;
        private T item;


        /// <summary>
        /// a wraper class for types that show the type name using ToString()-methode
        /// which is not very usefull when binding objects to controls tag property, i. e. combobox ;-)
        /// </summary>
        /// <param name="DisplayName">the value you want to be displaied in the control</param>
        /// <param name="ObjectInstance">the insctance you want to add to the tag property</param>
        public DropDownHelper(string DisplayName, T ObjectInstance)
        {
            Display = DisplayName;
            Item = ObjectInstance;
        }

        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }

        public override string ToString()
        {
            return Display;
        }
    }
}