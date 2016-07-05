using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Sautom.DataAccess.StoredProcedures
{
    //from https://github.com/LucBos/CodeFirstStoredProcedures
    public static class DatabaseExtensions
    {
	    public static IEnumerable<TResult> ExecuteStoredProcedure<TResult>(this Database database, IStoredProcedure<TResult> procedure)
        {
            List<SqlParameter> parameters = CreateSqlParametersFromProperties(procedure);

            string format = CreateSpCommand<TResult>(parameters);

            return database.SqlQuery<TResult>(format, parameters.Cast<object>().ToArray());
        }

	    private static List<SqlParameter> CreateSqlParametersFromProperties<TResult>(IStoredProcedure<TResult> procedure)
        {
            Type procedureType = procedure.GetType();
            PropertyInfo[] propertiesOfProcedure = procedureType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            List<SqlParameter> parameters =
                propertiesOfProcedure.Select(propertyInfo => new SqlParameter($"@{(object) propertyInfo.Name}",
                                                                              propertyInfo.GetValue(procedure, new object[] { })))
                    .ToList();
            return parameters;
        }

	    private static string CreateSpCommand<TResult>(List<SqlParameter> parameters)
        {
            string name = typeof(TResult).Name;
            string queryString = $"sp_{name}";
            parameters.ForEach(x => queryString = $"{queryString} {x.ParameterName},");

            return queryString.TrimEnd(',');
        }
    }
}
