
using Dapper;

namespace Notch.Data.Dapper
{
    using System;
    using System.Data;
    using System.Reflection;
    using Notch.Infrastructure.Attributes;

    public class ParameterBuilder
    {
        class DynamicParameterItem
        {
            public string Name;
            public object Value;
            public DbType? DbType = default(DbType?);
            public ParameterDirection? Direction = default(ParameterDirection?);
            public int? Size = default(int?);
        }

        /// <summary>
        /// Creates DynamicParameters array for SP from Request model based on <see cref="SqlParamMappingAttribute"/>
        /// </summary>
        /// <param name="model">Model with SP parameters</param>
        /// <returns>Array of DynamicParameters with values</returns>
        public static DynamicParameters BuildParametersFromModel(object model)
        {
            DynamicParameters parameters = new DynamicParameters();
            if (model != null)
            {
                if (model.GetType() == typeof(DynamicParameters))
                {
                    return (DynamicParameters)model;
                }

                PropertyInfo[] props = model.GetType().GetProperties();
                foreach (var property in props)
                {
                    object[] attrs = property.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        SqlParamMappingAttribute paramAttr = attr as SqlParamMappingAttribute;
                        if (paramAttr != null)
                        {
                            DynamicParameterItem newParam = new DynamicParameterItem
                            {
                                Name = paramAttr.ParamName,
                                DbType = (System.Data.DbType?)paramAttr.TargetType
                            };

                            if (paramAttr.Size.HasValue)
                            {
                                newParam.Size = paramAttr.Size.Value;
                            }

                            newParam.Direction = paramAttr.ParamDirection;

                            object value = property.GetValue(model, null);
                            newParam.Value = value ?? DBNull.Value;

                            parameters.Add(newParam.Name, newParam.Value, newParam.DbType, newParam.Direction, newParam.Size);
                        }
                    }
                }
            }

            return parameters;
        }
    }
}