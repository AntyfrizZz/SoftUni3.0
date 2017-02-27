namespace SimpleHttpServer.Models
{
    public class Cookie
    {
        public Cookie() 
            : this(null, null)
        {
        }

        public Cookie(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; }

        public string Value { get; }

        public override string ToString() => $"{this.Name}={this.Value}";
    }
}