using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;
using log4net;

namespace ru.xnull.Db
{
    /// <summary>
    /// Класс для работы с базой данных
    /// </summary>
    public abstract class DataBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(DataBase));
        private DbConnection connection;
        private String dataProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="dataProvider">Провайдер данных: System.Data.OleDb, System.Data.Odbc, System.Data.SqlClient</param>
        public DataBase(DbConnection connection, String dataProvider)
        {
            this.connection = connection;
            this.dataProvider = dataProvider;
        }

        /// <summary>
        /// выполнить скуль запрос
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        protected DataTable executeQuery(String query)
        {
            log.Debug("Выполнть SQL запрос");
            DataTable result = new DataTable();
            
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            DbDataAdapter dataAdapter = factory.CreateDataAdapter();

            DbCommand dbCommand = connection.CreateCommand();
            dbCommand.CommandText = query;

            dataAdapter.SelectCommand = dbCommand;
            dataAdapter.Fill(result);            
            return result;
        }
    }
}
