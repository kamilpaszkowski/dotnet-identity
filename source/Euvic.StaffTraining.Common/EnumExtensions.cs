using System;

namespace Euvic.StaffTraining.Common
{
    public static class EnumExtensions
    {
        public static TOut ToEnum<TOut>(this Enum @enum)
            where TOut : Enum
        {
            return (TOut)Enum.Parse(typeof(TOut), @enum.ToString());
        }
    }
}