using System;

namespace Mondop.Guard
{
    public static class Ensure
    {
        public static TArg IsNotNull<TArg>(TArg argument, string name)
        {
            if (argument == null)
                throw new ArgumentNullException(name);

            return argument;
        }

        public static string IsNotNullOrEmpty(this string argument,string name)
        {
            if (argument == null)
                throw new ArgumentNullException(name);

            if (string.IsNullOrEmpty(argument))
                throw new ArgumentException($"Empty string not allowed for {name}");

            return argument;
        }

        public static string IsNotNullOrWhiteSpace(this string argument,string name)
        {
            if (argument == null)
                throw new ArgumentNullException(name);

            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentException($"Empty or white space only string not allowed for {name}");

            return argument;
        }
    }
}
