using AutoMapper;
using System.Collections.Generic;

namespace BarkOn.Common.Utility
{
    public static class Extension
    {
        public static TTo MapObject<TFrom, TTo>(this TFrom value)
        {
            return Mapper.Map<TTo>(value);
        }


        public static IEnumerable<TTo> MapObjectList<TFrom, TTo>(this IEnumerable<TFrom> value)
        {
            return Mapper.Map<IEnumerable<TTo>>(value);
        }
    }
}
