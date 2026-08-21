using System;
using System.Collections.Generic;

namespace WitchKitchenDeluxe
{
    /// <summary>
    /// And then you could make this work with booting up from a txt file 
    /// like with Settings, whereby settings "const" is enforced.
    /// </summary>
    public static class Environment<Enum> 
    {
        private static readonly Dictionary<Enum, string> dictionary = new();

        public static Type Get<Type>(Enum key)
            => (Type)Convert.ChangeType(dictionary[key], typeof(Type));

        public static void Set(Enum key, object value)
            => dictionary[key] = value.ToString();
    }
}
