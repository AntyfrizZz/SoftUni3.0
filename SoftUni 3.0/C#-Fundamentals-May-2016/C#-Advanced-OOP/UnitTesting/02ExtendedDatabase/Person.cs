namespace _02ExtendedDatabase
{
    public class Person
    {
        public Person(long id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public long Id { get; }
        public string Username { get; }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            return this.Id == other?.Id && this.Username == other.Username;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Username.GetHashCode() ^ 23;
        }
    }
}
