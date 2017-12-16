namespace Notch.Infrastructure
{
    /// <summary>
    /// Represents entity service.
    /// </summary>
    public interface IEntityService
    {
        /// <summary>
        /// Converts object of one type to another.
        /// </summary>
        /// <typeparam name="TOut">Converted type.</typeparam>
        /// <param name="value">Object to convert.</param>
        /// <param name="defaultValue">Default value if not converted.</param>
        /// <returns>Converted object.</returns>
        TOut ConvertTo<TOut>(object value, TOut defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        void AssignTo<TIn, TOut>(TIn source, TOut destination);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TOut ConvertTo<TIn, TOut>(TIn source);
    }
}