namespace Integrations.Objects
{
    public class ControlWrapper<T>
    {
        public ControlWrapper(string DisplayName, T ObjectInstance)
        {
            Display = DisplayName;
            Item = ObjectInstance;
        }

        public string Display { get; set; }

        public T Item { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}