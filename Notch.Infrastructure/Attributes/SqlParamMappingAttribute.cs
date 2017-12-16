namespace Notch.Infrastructure.Attributes
{
    using System;
    using System.Data;

    /// <summary>
    /// Attribute to set request model mapping to SQL SP parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SqlParamMappingAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// Parameter type in DB.
        /// </summary>
        private readonly SqlDbType m_targetType = default(SqlDbType);

        /// <summary>
        /// Parameter name in DB.
        /// </summary>
        private readonly string m_paramName = string.Empty;

        /// <summary>
        /// Parameter size in DB.
        /// </summary>
        private readonly int? m_size = null;

        /// <summary>
        /// Parameter direction
        /// </summary>
        private readonly ParameterDirection m_paramDirection = ParameterDirection.Input;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlParamMappingAttribute"/> class
        /// </summary>
        /// <param name="targetType">SQL type of parameter.</param>
        /// <param name="paramName">SP parameter name.</param>
        /// <param name="size">SQL type size.</param>
        /// <param name="paramDirection">SP parameter direction.</param>
        public SqlParamMappingAttribute(SqlDbType targetType, string paramName, int size, ParameterDirection paramDirection = ParameterDirection.Input)
            : this(targetType, paramName, paramDirection)
        {
            this.m_size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlParamMappingAttribute"/> class
        /// </summary>
        /// <param name="targetType">SQL type of parameter.</param>
        /// <param name="paramName">SP parameter name.</param>
        /// <param name="paramDirection">SP parameter direction.</param>
        public SqlParamMappingAttribute(SqlDbType targetType, string paramName, ParameterDirection paramDirection = ParameterDirection.Input)
        {
            this.m_targetType = targetType;
            this.m_paramName = paramName;
            this.m_paramDirection = paramDirection;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets parameter type in sql query
        /// </summary>
        public SqlDbType TargetType
        {
            get { return this.m_targetType; }
        }

        /// <summary>
        /// Gets parameter name in sql query
        /// </summary>
        public string ParamName
        {
            get { return this.m_paramName; }
        }

        /// <summary>
        /// Gets parameter size in sql query
        /// </summary>
        public int? Size
        {
            get { return this.m_size; }
        }

        /// <summary>
        /// Gets parameter direction in sql query
        /// </summary>
        public ParameterDirection ParamDirection
        {
            get { return this.m_paramDirection; }
        }

        #endregion
    }
}
