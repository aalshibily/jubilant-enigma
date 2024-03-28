using Aegis.Core.Domain.Enums;
using Aegis.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aegis.Core.Domain.Entities
{
    public class Joke
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JokeTypeConverter))]
        public JokeType Type { get; set; }
        public string? Setup { get; set; }
        public string? Punchline { get; set; }
        public override bool Equals(object? obj)
        {
            return obj is Joke joke && Id == joke.Id;
        }
        public Joke() : this(0, JokeType.Random, "", "")
        {
        }
        public Joke(int id, JokeType type, string setup, string punchline)
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
