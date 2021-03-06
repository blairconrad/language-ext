﻿using System;

namespace LanguageExt
{
    /// <summary>
    /// Some T not initialised
    /// </summary>
    public class SomeNotInitialisedException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public SomeNotInitialisedException(Type type)
            :
            base($"Unitialised Some<{type.Name}>.")
        {
        }
    }

    /// <summary>
    /// Value is none
    /// </summary>
    public class ValueIsNoneException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNoneException()
            : base("Value is none.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNoneException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNoneException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Value is null
    /// </summary>
    public class ValueIsNullException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNullException()
            : base("Value is null.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ValueIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Result is null
    /// </summary>
    public class ResultIsNullException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ResultIsNullException()
            : base("Result is null.  Not allowed with Option<T> or Either<R,L>.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ResultIsNullException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ResultIsNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Option T is none
    /// </summary>
    public class OptionIsNoneException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public OptionIsNoneException()
            : base("Option isn't set.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public OptionIsNoneException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public OptionIsNoneException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Either is not right
    /// </summary>
    public class EitherIsNotRightException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotRightException()
            : base("Either is not right.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotRightException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotRightException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Either is not left
    /// </summary>
    public class EitherIsNotLeftException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotLeftException()
            : base("Either is not left.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotLeftException(string message) : base(message)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public EitherIsNotLeftException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    /// <summary>
    /// Value is bottom
    /// </summary>
    public class BottomException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public BottomException(string type = "Value")
            :
            base($"{type} is in a bottom state and therefore not valid.  This can happen when the value was filterd and the predicate " +
                 "returned false and there was no valid state the value could be in.  If you are going to use the type in a filter " +
                 "you should check if the IsBottom flag is set before use.  This can also happen if the struct wasn't initialised properly and then used.")
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public BottomException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class NotAppendableException : Exception
    {
        public NotAppendableException(Type t)
            : base($"Type '{t.Name}' not appendable: It's neither a CLR numeric-type, a string nor dervied from IAppendable")
        {
        }
    }

    public class NotSubtractableException : Exception
    {
        public NotSubtractableException(Type t)
            : base($"Type '{t.Name}' not subtractable: It's neither a CLR numeric-type, nor dervied from ISubtractable")
        {
        }
    }

    public class NotMultiplicableException : Exception
    {
        public NotMultiplicableException(Type t)
            : base($"Type '{t.Name}' not multiplicable: It's neither a CLR numeric-type, nor dervied from IMultiplicable")
        {
        }
    }

    public class NotDivisibleException : Exception
    {
        public NotDivisibleException(Type t)
            : base($"Type '{t.Name}' not divisible: It's neither a CLR numeric-type, nor dervied from IDivisible")
        {
        }
    }
}
