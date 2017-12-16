namespace Notch.Bootstrap
{
    using System;
    using AutoMapper;
    using Notch.Infrastructure;

    public class ValueConverter : IEntityService
    {
        public TOut ConvertTo<TOut>(object value, TOut defaultValue)
        {
            try
            {
                return Mapper.Map<TOut>(value);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        public void AssignTo<TIn, TOut>(TIn source, TOut destination)
        {
            Mapper.Map<TIn, TOut>(source, destination);
        }

        public TOut ConvertTo<TIn, TOut>(TIn source)
        {
            return Mapper.Map<TOut>(source);
        }
    }
}
