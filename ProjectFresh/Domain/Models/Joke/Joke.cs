namespace ProjectFresh.Domain.Models.Joke
{
    public class Joke
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Setup { get; set; }
        public string Punchline { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is Joke joke && Id == joke.Id;
        }
        public Joke(): this(0, "", "", "")
        {
        }
        public Joke(int id, string type, string setup, string punchline)
        {
            Id = id;
            Type = type;
            Setup = setup;
            Punchline = punchline;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
