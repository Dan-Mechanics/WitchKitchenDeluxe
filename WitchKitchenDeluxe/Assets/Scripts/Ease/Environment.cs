using System;
using System.Collections.Generic;

namespace WitchKitchenDeluxe
{
    public static class Environment<Enum>
    {
        private static readonly Dictionary<Enum, object> dictionary = new();

        public static void Set(Enum key, object value)
            => dictionary[key] = value;

        public static Type Get<Type>(Enum key)
            => (Type)dictionary[key];

        public static void Clear()
            => dictionary.Clear();
    }
}
