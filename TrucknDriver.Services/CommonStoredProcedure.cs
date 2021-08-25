using AutoMapper;
using TrucknDriver.CommonModels;
using TrucknDriver.Entities.Models;
using TrucknDriver.Utilities.ApiResponse;
using TrucknDriver.Utilities.Model.Settings;
using Exceptionless;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Linq;

namespace TrucknDriver.Services
{
    public static class CommonStoredProcedure
    {
        #region
        //private readonly TrucknDriver_LocalContext _dbContext;
        //private readonly IOptions<AppSettings> _appSettings;

        //public CommonStoredProcedure(TrucknDriver_LocalContext dbContext, IOptions<AppSettings> appSettings)
        //{
        //    _dbContext = dbContext;
        //    _appSettings = appSettings;
        //}

        #endregion
        public static DbCommand LoadStoredProcedure(this DbContext context, string storedProcName)
        {
            var cmd = context.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = storedProcName;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            return cmd;
        }

        public static DbCommand LoadStoredProcedureWithSqlParams(this DbCommand cmd, params (string, object)[] nameValues)
        {

            foreach (var pair in nameValues)
            {
                var param = cmd.CreateParameter(); param.ParameterName = pair.Item1; param.Value = pair.Item2 ?? DBNull.Value; cmd.Parameters.Add(param);
            }
            return cmd;
        }


        public static List<T> ExecuteStoredProcedure<T>(this DbCommand command) where T : class
        {
            using (command)
            {
                if (command.Connection.State == System.Data.ConnectionState.Closed)
                    command.Connection.Open();
                try
                {

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.MapToList<T>();
                    }
                }
                finally
                {
                    command.Connection.Close();
                }
            }

        }


        private static List<T> MapToList<T>(this DbDataReader dr)
        {

            var objList = new List<T>(); var props = typeof(T).GetRuntimeProperties();
            var colMapping = dr.GetColumnSchema().Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower())).ToDictionary(key => key.ColumnName.ToLower());
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    T obj = Activator.CreateInstance<T>();
                    foreach (var prop in props)
                    {
                        var val = dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value); prop.SetValue(obj, val == DBNull.Value ? null : val);
                    }
                    objList.Add(obj);
                }
            }
            return objList;
        }
    }
}
