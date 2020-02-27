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

        public static TArg Is<TArg>(object argument,string name)
        {
            if (argument is TArg)
                return (TArg)argument;

            throw new ArgumentException($"Unable to cast {name} of type {argument.GetType().FullName} to {typeof(TArg).FullName}");
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
