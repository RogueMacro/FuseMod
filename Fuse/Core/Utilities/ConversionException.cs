using System;

namespace Fuse.Core.Utilities
{
    public class ConversionException : Exception
    {
        public ConversionException(string message) : base(message)
        {
        }

        public ConversionException(object from, Type to) : base($"Could not convert ({from.GetType()}) {from} to {to}")
        {
        }
    }
}