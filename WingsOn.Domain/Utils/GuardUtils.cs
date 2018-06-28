using System;
using System.Diagnostics;

namespace WingsOn.Domain.Utils
{
    public static class GuardUtils
    {
        //[DebuggerHidden]
        public static void ArgumentNotLessThan<T>(this T argument, T treshold, string argumentName, string message = "") where T : IComparable<T>
        {
            if (argument.CompareTo(treshold) < 0)
                throw new ArgumentOutOfRangeException(argumentName, message);
        }

        //[DebuggerHidden]
        public static void ArgumentNotNullOrWhitespace(this string argument, string argumentName, string message = "")
        {
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentNullException(argumentName, message);
        }

        //[DebuggerHidden]
        public static void ArgumentNotNull(object argument, string argumentName, string message = "")
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName, message);
        }
    }
}