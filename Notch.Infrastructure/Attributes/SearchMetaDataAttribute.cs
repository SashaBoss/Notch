namespace Notch.Infrastructure.Attributes
{
    using System;
    using Dictionaries;

    /// <summary>
    /// Attribute to mark data that will be used for searching with needed information for filtering (column, in/like).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class SearchMetaDataAttribute : Attribute
    {
        private readonly SqlSearchType _sqlSearchType;
        private readonly string _columnName;

        public SearchMetaDataAttribute(string columnName)
        {
            this._columnName = columnName;
            this._sqlSearchType = SqlSearchType.Like;
        }

        public SearchMetaDataAttribute(string columnName, SqlSearchType sqlSearchType)
        {
            this._columnName = columnName;
            this._sqlSearchType = sqlSearchType;
        }

        public SqlSearchType SqlSearchType
        {
            get
            {
                return this._sqlSearchType;
            }
        }

        public string ColumnName
        {
            get
            {
                return this._columnName;
            }
        }
    }
}