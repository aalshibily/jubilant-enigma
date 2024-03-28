using System.Collections.Generic;
using System.ComponentModel;

namespace ProjectFresh.Domain.Constants
{
    public enum JokeType:uint
    {
        [Description("Random")]
        Random = 100,
        [Description("Programming")]
        Programming = 200,
        [Description("General")]
        General = 300,
        [Description("Knock-knock")]
        Knock_knock = 400
    }
    public static class JokeTypeExtensions
    {
        private static readonly Dictionary<JokeType, string> JokeMap = new Dictionary<JokeType, string>()
        {
            { JokeType.Random, "Random" },
            { JokeType.Programming, "Programming" },
            { JokeType.General, "General" },
            { JokeType.Knock_knock, "Knock-knock" }
        };
        //Alternative to using description field
        public static string ToStringCustom(this JokeType type)
        {
            var TypeName = JokeMap.GetValueOrDefault(type, "Random");
            return TypeName.Replace('_', '-');
        }
    }
}
