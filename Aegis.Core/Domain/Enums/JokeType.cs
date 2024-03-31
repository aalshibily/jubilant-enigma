using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Domain.Enums
{
    public enum JokeType : uint
    {
        Random = 100,
        Programming = 200,
        General = 300,
        Knock_knock = 400,
        Dad = 500
    }

    public static class JokeTypeDescriptions
    {
        private static readonly Dictionary<JokeType, string> FriendlyNames = new Dictionary<JokeType, string>()
        {
            { JokeType.Random, "Random" },
            { JokeType.Programming, "Programming" },
            { JokeType.General, "General" },
            { JokeType.Knock_knock, "Knock-knock" },
            { JokeType.Dad, "Dad" }
        };

        public static string GetFriendlyName(this JokeType type)
        {
            if (FriendlyNames.TryGetValue(type, out var friendlyName))
            {
                return friendlyName;
            }

            return "Unknown";
        }
        public static JokeType Reverse(this JokeType type, string look)
        {
            return FriendlyNames.Where(d => d.Value == look).Select(x => x.Key).First();
        }
    }
    
}
