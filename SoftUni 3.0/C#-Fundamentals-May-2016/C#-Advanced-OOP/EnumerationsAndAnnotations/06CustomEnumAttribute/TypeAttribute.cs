namespace _06CustomEnumAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Enum)]
    public class TypeAttribute : Attribute
    {
        public string Type { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Description}";
        }
    }
}
